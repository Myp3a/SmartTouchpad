// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.RawInputTouchPad
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SmartTouchpad
{
  internal class RawInputTouchPad
  {
    private readonly object _padLock = new object();
    private readonly Dictionary<IntPtr, KeyPressEvent> _deviceList = new Dictionary<IntPtr, KeyPressEvent>();
    private static InputData _rawBuffer;
    private string sPreviousMessage = "";
    private DateTime dtLatestValidMessageTime = DateTime.Now;

    public int NumberOfKeyboards { get; private set; }

    public event RawInputTouchPad.DeviceEventHandler KeyPressed;

    public RawInputTouchPad(IntPtr hwnd, bool captureOnlyInForeground)
    {
      RawInputDevice[] pRawInputDevice = new RawInputDevice[27];
      pRawInputDevice[0].UsagePage = HidUsagePage.CONSUMER;
      pRawInputDevice[0].Usage = HidUsage.Pointer;
      pRawInputDevice[0].Flags = (RawInputDeviceFlags) ((captureOnlyInForeground ? 0 : 256) | 8192);
      pRawInputDevice[0].Target = hwnd;
      for (int index = 0; index < 27; ++index)
      {
        pRawInputDevice[index].UsagePage = HidUsagePage.CONSUMER;
        pRawInputDevice[index].Flags = (RawInputDeviceFlags) ((captureOnlyInForeground ? 0 : 256) | 8192);
        pRawInputDevice[index].Target = hwnd;
      }
      pRawInputDevice[1].Usage = HidUsage.Keypad;
      pRawInputDevice[2].Usage = HidUsage.TP_Speaker_Volume;
      pRawInputDevice[3].Usage = HidUsage.TP_Microphone_Volume;
      pRawInputDevice[4].Usage = HidUsage.TP_Brightness_Monitor;
      pRawInputDevice[5].Usage = HidUsage.TP_Brightness_Keyboard;
      pRawInputDevice[6].Usage = HidUsage.Consumer;
      pRawInputDevice[7].Usage = HidUsage.TP_Scroll_Bar_Down;
      pRawInputDevice[8].Usage = HidUsage.TP_Capture_Screen;
      pRawInputDevice[9].Usage = HidUsage.TP_Recording;
      pRawInputDevice[10].Usage = HidUsage.TP_High_Light;
      pRawInputDevice[11].Usage = HidUsage.TP_Open_Folder_Of_Image_Captured;
      pRawInputDevice[12].Usage = HidUsage.TP_Keyboard_Lighting_Repeated;
      pRawInputDevice[13].Usage = HidUsage.TP_Cooler_Boost;
      pRawInputDevice[14].Usage = HidUsage.TP_Emoji;
      pRawInputDevice[15].Usage = HidUsage.TP_Switch_Projector;
      pRawInputDevice[16].Usage = HidUsage.TP_Switch_Webcam;
      pRawInputDevice[17].Usage = HidUsage.TP_BT_Matching;
      pRawInputDevice[18].Usage = HidUsage.TP_Switch_BT;
      pRawInputDevice[19].Usage = HidUsage.TP_Switch_Microphone;
      pRawInputDevice[20].Usage = HidUsage.TP_Switch_Crosshair;
      pRawInputDevice[21].Usage = HidUsage.TP_Macro_M1;
      pRawInputDevice[22].Usage = HidUsage.TP_Macro_M2;
      pRawInputDevice[23].Usage = HidUsage.TP_Macro_M3;
      pRawInputDevice[24].Usage = HidUsage.TP_Macro_M4;
      pRawInputDevice[25].Usage = HidUsage.TP_Macro_M5;
      pRawInputDevice[26].Usage = HidUsage.TP_Macro_Menu;
      if (!Win32.RegisterRawInputDevices(pRawInputDevice, (uint) pRawInputDevice.Length, (uint) Marshal.SizeOf<RawInputDevice>(pRawInputDevice[0])))
        throw new ApplicationException("Failed to register raw input device(s).");
    }

    public void EnumerateDevices()
    {
      lock (this._padLock)
      {
        this._deviceList.Clear();
        int num1 = 0;
        KeyPressEvent keyPressEvent1 = new KeyPressEvent();
        keyPressEvent1.DeviceName = "Global Keyboard";
        keyPressEvent1.DeviceHandle = IntPtr.Zero;
        keyPressEvent1.DeviceType = Win32.GetDeviceType(1U);
        keyPressEvent1.Name = "Fake Keyboard. Some keys (ZOOM, MUTE, VOLUMEUP, VOLUMEDOWN) are sent to rawinput with a handle of zero.";
        int num2 = num1;
        int num3 = num2 + 1;
        keyPressEvent1.Source = num2.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        KeyPressEvent keyPressEvent2 = keyPressEvent1;
        this._deviceList.Add(keyPressEvent2.DeviceHandle, keyPressEvent2);
        int num4 = 0;
        uint numberDevices = 0;
        int size1 = Marshal.SizeOf(typeof (Rawinputdevicelist));
        if (Win32.GetRawInputDeviceList(IntPtr.Zero, ref numberDevices, (uint) size1) == 0U)
        {
          IntPtr num5 = Marshal.AllocHGlobal((int) ((long) size1 * (long) numberDevices));
          int rawInputDeviceList = (int) Win32.GetRawInputDeviceList(num5, ref numberDevices, (uint) size1);
          for (int index = 0; (long) index < (long) numberDevices; ++index)
          {
            uint size2 = 0;
            Rawinputdevicelist structure = (Rawinputdevicelist) Marshal.PtrToStructure(new IntPtr(num5.ToInt64() + (long) (size1 * index)), typeof (Rawinputdevicelist));
            int rawInputDeviceInfo1 = (int) Win32.GetRawInputDeviceInfo(structure.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, IntPtr.Zero, ref size2);
            if (size2 > 0U)
            {
              IntPtr num6 = Marshal.AllocHGlobal((int) size2);
              int rawInputDeviceInfo2 = (int) Win32.GetRawInputDeviceInfo(structure.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, num6, ref size2);
              string stringAnsi = Marshal.PtrToStringAnsi(num6);
              if (structure.dwType == 1U || structure.dwType == 2U)
              {
                string deviceDescription = Win32.GetDeviceDescription(stringAnsi);
                KeyPressEvent keyPressEvent3 = new KeyPressEvent()
                {
                  DeviceName = Marshal.PtrToStringAnsi(num6),
                  DeviceHandle = structure.hDevice,
                  DeviceType = Win32.GetDeviceType(structure.dwType),
                  Name = deviceDescription,
                  Source = num3++.ToString((IFormatProvider) CultureInfo.InvariantCulture)
                };
                if (!this._deviceList.ContainsKey(structure.hDevice))
                {
                  ++num4;
                  this._deviceList.Add(structure.hDevice, keyPressEvent3);
                }
              }
              Marshal.FreeHGlobal(num6);
            }
          }
          Marshal.FreeHGlobal(num5);
          this.NumberOfKeyboards = num4;
          return;
        }
      }
      throw new Win32Exception(Marshal.GetLastWin32Error());
    }

    public void ProcessRawInput(IntPtr hdevice, out MainWindow.TouchpadButton touchpadButton)
    {
      touchpadButton = MainWindow.TouchpadButton.None;
      if (this._deviceList.Count == 0)
        return;
      int size = 0;
      Win32.GetRawInputData(hdevice, DataCommand.RID_INPUT, IntPtr.Zero, ref size, Marshal.SizeOf(typeof (Rawinputheader)));
      if (size != Win32.GetRawInputData(hdevice, DataCommand.RID_INPUT, out RawInputTouchPad._rawBuffer, ref size, Marshal.SizeOf(typeof (Rawinputheader))))
        return;
      int vkey = (int) RawInputTouchPad._rawBuffer.data.keyboard.VKey;
      int makecode = (int) RawInputTouchPad._rawBuffer.data.keyboard.Makecode;
      int flags = (int) RawInputTouchPad._rawBuffer.data.keyboard.Flags;
      if (vkey == (int) byte.MaxValue)
        return;
      bool isE0BitSet = (flags & 2) != 0;
      if (!this._deviceList.ContainsKey(RawInputTouchPad._rawBuffer.header.hDevice))
        return;
      KeyPressEvent device;
      lock (this._padLock)
        device = this._deviceList[RawInputTouchPad._rawBuffer.header.hDevice];
      bool flag = (flags & 1) != 0;
      device.KeyPressState = flag ? "BREAK" : "MAKE";
      device.Message = RawInputTouchPad._rawBuffer.data.keyboard.Message;
      device.VKeyName = "A";
      device.VKey = vkey;
      string sMessage = device.Message.ToString("X8");
      if (this.sPreviousMessage == "")
        this.sPreviousMessage = sMessage.Substring(0,6);
      if (this.MessageValidationPass(sMessage))
      {
        if (this.sPreviousMessage.Contains("08"))
          MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Speaker;
        else if (this.sPreviousMessage.Contains("09"))
          MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Microphone;
        else if (this.sPreviousMessage.Contains("0A"))
          MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Screen;
        else if (this.sPreviousMessage.Contains("0B"))
          MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Keyboard;
        if (this.sPreviousMessage.Contains("07"))
          touchpadButton = MainWindow.TouchpadButton.Power;
        else if (this.sPreviousMessage.Contains("0C"))
          touchpadButton = MainWindow.TouchpadButton.VolumeUp;
        else if (this.sPreviousMessage.Contains("0D"))
          touchpadButton = MainWindow.TouchpadButton.VolumeDown;
        else if (this.sPreviousMessage.Contains("0E"))
          touchpadButton = MainWindow.TouchpadButton.CaptureScreen;
        else if (this.sPreviousMessage.Contains("0F"))
          touchpadButton = MainWindow.TouchpadButton.Recording;
        else if (this.sPreviousMessage.Contains("10"))
          touchpadButton = MainWindow.TouchpadButton.HighLight;
        else if (this.sPreviousMessage.Contains("11"))
          touchpadButton = MainWindow.TouchpadButton.OpenFolder;
        else if (this.sPreviousMessage.Contains("12"))
          touchpadButton = MainWindow.TouchpadButton.KeyboardLightingRepeat;
        else if (this.sPreviousMessage.Contains("13"))
          touchpadButton = MainWindow.TouchpadButton.CoolerBoost;
        else if (this.sPreviousMessage.Contains("14"))
          touchpadButton = MainWindow.TouchpadButton.Emoji;
        else if (this.sPreviousMessage.Contains("15"))
          touchpadButton = MainWindow.TouchpadButton.SwitchProjector;
        else if (this.sPreviousMessage.Contains("16"))
          touchpadButton = MainWindow.TouchpadButton.SwitchWebcam;
        else if (this.sPreviousMessage.Contains("17"))
          touchpadButton = MainWindow.TouchpadButton.BTMatching;
        else if (this.sPreviousMessage.Contains("18"))
          touchpadButton = MainWindow.TouchpadButton.SwitchBT;
        else if (this.sPreviousMessage.Contains("19"))
          touchpadButton = MainWindow.TouchpadButton.SwitchMicrophone;
        else if (this.sPreviousMessage.Contains("1A"))
          touchpadButton = MainWindow.TouchpadButton.SwitchCrosshair;
        else if (this.sPreviousMessage.Contains("1B"))
          touchpadButton = MainWindow.TouchpadButton.MacroM1;
        else if (this.sPreviousMessage.Contains("1C"))
          touchpadButton = MainWindow.TouchpadButton.MacroM2;
        else if (this.sPreviousMessage.Contains("1D"))
          touchpadButton = MainWindow.TouchpadButton.MacroM3;
        else if (this.sPreviousMessage.Contains("1E"))
          touchpadButton = MainWindow.TouchpadButton.MacroM4;
        else if (this.sPreviousMessage.Contains("1F"))
          touchpadButton = MainWindow.TouchpadButton.MacroM5;
        else if (this.sPreviousMessage.Contains("23"))
          touchpadButton = MainWindow.TouchpadButton.MacroMenu;
        this.sPreviousMessage = "";
      }
      if (this.KeyPressed == null)
        return;
      this.KeyPressed((object) this, new RawInputEventArg(device));
    }

    private bool MessageValidationPass(string sMessage)
    {
        return sMessage == "0000000B";
    }

    private static int VirtualKeyCorrection(int virtualKey, bool isE0BitSet, int makeCode)
    {
      int num = virtualKey;
      if (RawInputTouchPad._rawBuffer.header.hDevice == IntPtr.Zero)
      {
        if (RawInputTouchPad._rawBuffer.data.keyboard.VKey == (ushort) 17)
          num = 251;
      }
      else
      {
        switch (virtualKey)
        {
          case 16:
            num = makeCode == 54 ? 161 : 160;
            break;
          case 17:
            num = isE0BitSet ? 163 : 162;
            break;
          case 18:
            num = isE0BitSet ? 165 : 164;
            break;
          default:
            num = virtualKey;
            break;
        }
      }
      return num;
    }

    public delegate void DeviceEventHandler(object sender, RawInputEventArg e);
  }
}
