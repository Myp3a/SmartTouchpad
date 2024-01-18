using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SmartTouchpad
{
    internal class RawInputTouchPad
    {
        private readonly List<IntPtr> _deviceList = new List<IntPtr>();
        private static InputData _rawBuffer;
        private string sPreviousMessage = "";

        public RawInputTouchPad(IntPtr hwnd, bool captureOnlyInForeground)
        {
            // https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/hid-architecture#hid-clients-supported-in-windows
            // This is a Consumer controls device
            RawInputDevice[] pRawInputDevice = new RawInputDevice[1];
            pRawInputDevice[0].UsagePage = HidUsagePage.CONSUMER;
            pRawInputDevice[0].Usage = 0x01;
            pRawInputDevice[0].Flags = captureOnlyInForeground ? RawInputDeviceFlags.NONE : RawInputDeviceFlags.INPUTSINK;
            pRawInputDevice[0].Target = hwnd;
            if (!Win32.RegisterRawInputDevices(pRawInputDevice, (uint)pRawInputDevice.Length, (uint)Marshal.SizeOf<RawInputDevice>(pRawInputDevice[0])))
                throw new ApplicationException("Failed to register raw input device(s).");
        }

        public void EnumerateDevices()
        {
            this._deviceList.Clear();
            uint deviceCount = 0;
            int size1 = Marshal.SizeOf(typeof(Rawinputdevicelist));
            if (Win32.GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, (uint)size1) == 0U)
            {
                IntPtr num5 = Marshal.AllocHGlobal((int)((long)size1 * (long)deviceCount));
                int rawInputDeviceList = (int)Win32.GetRawInputDeviceList(num5, ref deviceCount, (uint)size1);
                for (int index = 0; (long)index < (long)deviceCount; ++index)
                {
                    uint deviceInfoSize = 0;
                    Rawinputdevicelist structure = (Rawinputdevicelist)Marshal.PtrToStructure(new IntPtr(num5.ToInt64() + (long)(size1 * index)), typeof(Rawinputdevicelist));
                    int rawInputDeviceInfo1 = (int)Win32.GetRawInputDeviceInfo(structure.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, IntPtr.Zero, ref deviceInfoSize);
                    if (deviceInfoSize > 0U)
                    {
                        IntPtr num6 = Marshal.AllocHGlobal((int)deviceInfoSize);
                        int rawInputDeviceInfo2 = (int)Win32.GetRawInputDeviceInfo(structure.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, num6, ref deviceInfoSize);
                        string stringAnsi = Marshal.PtrToStringAnsi(num6);
                        if (structure.dwType == 2U && stringAnsi.Contains("HID#MSNB0001"))
                        {
                            if (!this._deviceList.Contains(structure.hDevice))
                            {
                                this._deviceList.Add(structure.hDevice);
                            }
                        }
                        Marshal.FreeHGlobal(num6);
                    }
                }
                Marshal.FreeHGlobal(num5);
                return;
            }
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void ProcessRawInput(IntPtr hdevice, out MainWindow.TouchpadButton touchpadButton)
        {
            touchpadButton = MainWindow.TouchpadButton.None;
            if (this._deviceList.Count == 0)
                return;
            int size = 0;
            Win32.GetRawInputData(hdevice, DataCommand.RID_INPUT, IntPtr.Zero, ref size, Marshal.SizeOf(typeof(Rawinputheader)));
            if (size != Win32.GetRawInputData(hdevice, DataCommand.RID_INPUT, out RawInputTouchPad._rawBuffer, ref size, Marshal.SizeOf(typeof(Rawinputheader))))
                return;
            if (!this._deviceList.Contains(RawInputTouchPad._rawBuffer.header.hDevice))
                return;
            uint message = RawInputTouchPad._rawBuffer.data.keyboard.Message;
            if (message == 0xC00000B) message = 0x0C0B;
            if (message == 0xD00000B) message = 0x0D0B;
            string sMessage = message.ToString("X4");
            if (this.IsKeyUp(sMessage))
            {
                switch (this.sPreviousMessage)
                {
                    case "07":
                        touchpadButton = MainWindow.TouchpadButton.Power;
                        break;
                    case "08":
                        MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Speaker;
                        break;
                    case "09":
                        MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Microphone;
                        break;
                    case "0A":
                        MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Screen;
                        break;
                    case "0B":
                        MainWindow.currentVolumeDevice = MainWindow.VolumeDevice.Keyboard;
                        break;
                    case "0C":
                        touchpadButton = MainWindow.TouchpadButton.VolumeUp;
                        break;
                    case "0D":
                        touchpadButton = MainWindow.TouchpadButton.VolumeDown;
                        break;
                    case "0E":
                        touchpadButton = MainWindow.TouchpadButton.CaptureScreen;
                        break;
                    case "0F":
                        touchpadButton = MainWindow.TouchpadButton.Recording;
                        break;
                    case "10":
                        touchpadButton = MainWindow.TouchpadButton.HighLight;
                        break;
                    case "11":
                        touchpadButton = MainWindow.TouchpadButton.OpenFolder;
                        break;
                    case "12":
                        touchpadButton = MainWindow.TouchpadButton.KeyboardLightingRepeat;
                        break;
                    case "13":
                        touchpadButton = MainWindow.TouchpadButton.CoolerBoost;
                        break;
                    case "14":
                        touchpadButton = MainWindow.TouchpadButton.Emoji;
                        break;
                    case "15":
                        touchpadButton = MainWindow.TouchpadButton.SwitchProjector;
                        break;
                    case "16":
                        touchpadButton = MainWindow.TouchpadButton.SwitchWebcam;
                        break;
                    case "17":
                        touchpadButton = MainWindow.TouchpadButton.BTMatching;
                        break;
                    case "18":
                        touchpadButton = MainWindow.TouchpadButton.SwitchBT;
                        break;
                    case "19":
                        touchpadButton = MainWindow.TouchpadButton.SwitchMicrophone;
                        break;
                    case "1A":
                        touchpadButton = MainWindow.TouchpadButton.SwitchCrosshair;
                        break;
                    case "1B":
                        touchpadButton = MainWindow.TouchpadButton.MacroM1;
                        break;
                    case "1C":
                        touchpadButton = MainWindow.TouchpadButton.MacroM2;
                        break;
                    case "1D":
                        touchpadButton = MainWindow.TouchpadButton.MacroM3;
                        break;
                    case "1E":
                        touchpadButton = MainWindow.TouchpadButton.MacroM4;
                        break;
                    case "1F":
                        touchpadButton = MainWindow.TouchpadButton.MacroM5;
                        break;
                    case "23":
                        touchpadButton = MainWindow.TouchpadButton.MacroMenu;
                        break;
                }
                this.sPreviousMessage = "";
            }
            this.sPreviousMessage = sMessage.Substring(0, 2);
        }

        private bool IsKeyUp(string sMessage)
        {
            return sMessage == "000B";
        }
    }
}
