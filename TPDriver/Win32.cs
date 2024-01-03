// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.Win32
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace SmartTouchpad
{
  public static class Win32
  {
    public const int KEYBOARD_OVERRUN_MAKE_CODE = 255;
    public const int WM_APPCOMMAND = 793;
    private const int FAPPCOMMANDMASK = 61440;
    internal const int FAPPCOMMANDMOUSE = 32768;
    internal const int FAPPCOMMANDOEM = 4096;
    public const int WM_KEYDOWN = 256;
    public const int WM_KEYUP = 257;
    internal const int WM_SYSKEYDOWN = 260;
    internal const int WM_INPUT = 255;
    internal const int WM_USB_DEVICECHANGE = 537;
    internal const int VK_SHIFT = 16;
    internal const int RI_KEY_MAKE = 0;
    internal const int RI_KEY_BREAK = 1;
    internal const int RI_KEY_E0 = 2;
    internal const int RI_KEY_E1 = 4;
    internal const int VK_CONTROL = 17;
    internal const int VK_MENU = 18;
    internal const int VK_ZOOM = 251;
    internal const int VK_LSHIFT = 160;
    internal const int VK_RSHIFT = 161;
    internal const int VK_LCONTROL = 162;
    internal const int VK_RCONTROL = 163;
    internal const int VK_LMENU = 164;
    internal const int VK_RMENU = 165;
    internal const int SC_SHIFT_R = 54;
    internal const int SC_SHIFT_L = 42;
    internal const int RIM_INPUT = 0;

    public static int LoWord(int dwValue) => dwValue & (int) ushort.MaxValue;

    public static int HiWord(long dwValue) => (int) (dwValue >> 16) & -61441;

    public static ushort LowWord(uint val) => (ushort) val;

    public static ushort HighWord(uint val) => (ushort) (val >> 16);

    public static uint BuildWParam(ushort low, ushort high) => (uint) high << 16 | (uint) low;

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern int GetRawInputData(
      IntPtr hRawInput,
      DataCommand command,
      out InputData buffer,
      [In, Out] ref int size,
      int cbSizeHeader);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern int GetRawInputData(
      IntPtr hRawInput,
      DataCommand command,
      [Out] IntPtr pData,
      [In, Out] ref int size,
      int sizeHeader);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern uint GetRawInputDeviceInfo(
      IntPtr hDevice,
      RawInputDeviceInfo command,
      IntPtr pData,
      ref uint size);

    [DllImport("user32.dll")]
    private static extern uint GetRawInputDeviceInfo(
      IntPtr hDevice,
      uint command,
      ref DeviceInfo data,
      ref uint dataSize);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern uint GetRawInputDeviceList(
      IntPtr pRawInputDeviceList,
      ref uint numberDevices,
      uint size);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern bool RegisterRawInputDevices(
      RawInputDevice[] pRawInputDevice,
      uint numberDevices,
      uint size);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern IntPtr RegisterDeviceNotification(
      IntPtr hRecipient,
      IntPtr notificationFilter,
      DeviceNotification flags);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool UnregisterDeviceNotification(IntPtr handle);

    public static void DeviceAudit()
    {
      FileStream fileStream = new FileStream("DeviceAudit.txt", FileMode.Create, FileAccess.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream);
      int num1 = 0;
      uint numberDevices = 0;
      int size1 = Marshal.SizeOf(typeof (Rawinputdevicelist));
      if (Win32.GetRawInputDeviceList(IntPtr.Zero, ref numberDevices, (uint) size1) != 0U)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      IntPtr num2 = Marshal.AllocHGlobal((int) ((long) size1 * (long) numberDevices));
      int rawInputDeviceList = (int) Win32.GetRawInputDeviceList(num2, ref numberDevices, (uint) size1);
      for (int index = 0; (long) index < (long) numberDevices; ++index)
      {
        uint size2 = 0;
        Rawinputdevicelist structure = (Rawinputdevicelist) Marshal.PtrToStructure(new IntPtr(num2.ToInt64() + (long) (size1 * index)), typeof (Rawinputdevicelist));
        int rawInputDeviceInfo1 = (int) Win32.GetRawInputDeviceInfo(structure.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, IntPtr.Zero, ref size2);
        if (size2 <= 0U)
        {
          streamWriter.WriteLine("pcbSize: " + (object) size2);
          streamWriter.WriteLine(Marshal.GetLastWin32Error());
          return;
        }
        uint dataSize = (uint) Marshal.SizeOf(typeof (DeviceInfo));
        DeviceInfo data = new DeviceInfo()
        {
          Size = Marshal.SizeOf(typeof (DeviceInfo))
        };
        if (Win32.GetRawInputDeviceInfo(structure.hDevice, 536870923U, ref data, ref dataSize) <= 0U)
        {
          streamWriter.WriteLine(Marshal.GetLastWin32Error());
          return;
        }
        IntPtr num3 = Marshal.AllocHGlobal((int) size2);
        int rawInputDeviceInfo2 = (int) Win32.GetRawInputDeviceInfo(structure.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, num3, ref size2);
        string stringAnsi = Marshal.PtrToStringAnsi(num3);
        if (structure.dwType == 1U || structure.dwType == 2U)
        {
          string deviceDescription = Win32.GetDeviceDescription(stringAnsi);
          KeyPressEvent keyPressEvent = new KeyPressEvent()
          {
            DeviceName = Marshal.PtrToStringAnsi(num3),
            DeviceHandle = structure.hDevice,
            DeviceType = Win32.GetDeviceType(structure.dwType),
            Name = deviceDescription,
            Source = num1++.ToString((IFormatProvider) CultureInfo.InvariantCulture)
          };
          streamWriter.WriteLine(keyPressEvent.ToString());
          streamWriter.WriteLine(data.ToString());
          streamWriter.WriteLine(data.KeyboardInfo.ToString());
          streamWriter.WriteLine(data.HIDInfo.ToString());
          streamWriter.WriteLine("=========================================================================================================");
        }
        Marshal.FreeHGlobal(num3);
      }
      Marshal.FreeHGlobal(num2);
      streamWriter.Flush();
      streamWriter.Close();
      fileStream.Close();
    }

    public static string GetDeviceType(uint device)
    {
      string deviceType;
      switch (device)
      {
        case 0:
          deviceType = "MOUSE";
          break;
        case 1:
          deviceType = "KEYBOARD";
          break;
        case 2:
          deviceType = "HID";
          break;
        default:
          deviceType = "UNKNOWN";
          break;
      }
      return deviceType;
    }

    public static string GetDeviceDescription(string device)
    {
      try
      {
        string str = RegistryAccess.GetDeviceKey(device).GetValue("DeviceDesc").ToString();
        return str.Substring(str.IndexOf(';') + 1);
      }
      catch (Exception ex)
      {
        return "Device is malformed unable to look up in the registry";
      }
    }
  }
}
