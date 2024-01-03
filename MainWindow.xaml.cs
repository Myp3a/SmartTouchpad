using Newtonsoft.Json;
using SmartTouchpad.Functions;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using static SmartTouchpad.JSONSchema;

namespace SmartTouchpad
{
    public partial class MainWindow : Window, IComponentConnector
    {
        private IntPtr windowHandle = IntPtr.Zero;
        private static RawInputTouchPad _touchpadDriver;
        public static MainWindow.VolumeDevice currentVolumeDevice = MainWindow.VolumeDevice.None;
        private static Settings settings = new Settings();

        public MainWindow()
        {
            try
            {
                settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(@"data.json"));
            } 
            catch {
                File.WriteAllText(@"data.json", JsonConvert.SerializeObject(settings));
            }
            InitializeComponent();
            NotifyIcon ni = new NotifyIcon();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/tp.ico")).Stream;
            ni.Icon = new System.Drawing.Icon(iconStream);
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    Show();
                    WindowState = WindowState.Normal;
                };
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();
            base.OnStateChanged(e);
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.windowHandle = new WindowInteropHelper((Window)this).Handle;
            MainWindow._touchpadDriver = new RawInputTouchPad(this.windowHandle, false);
            MainWindow._touchpadDriver.EnumerateDevices();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            if (!(PresentationSource.FromVisual((Visual)this) is HwndSource hwndSource))
            {
                return;
            }
            hwndSource.AddHook(new HwndSourceHook(this.WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == (int)byte.MaxValue)
            {
                MainWindow.TouchpadButton touchpadButton = MainWindow.TouchpadButton.None;
                MainWindow._touchpadDriver.ProcessRawInput(lParam, out touchpadButton);
                switch (touchpadButton)
                {
                    case MainWindow.TouchpadButton.SpeakerVolume:
                        currentVolumeDevice = VolumeDevice.Speaker;
                        break;
                    case MainWindow.TouchpadButton.MicrophoneVolume:
                        currentVolumeDevice = VolumeDevice.Microphone;
                        break;
                    case MainWindow.TouchpadButton.BrightnessMonitor:
                        currentVolumeDevice = VolumeDevice.Screen;
                        break;
                    case MainWindow.TouchpadButton.BrightnessKeyboard:
                        currentVolumeDevice = VolumeDevice.Keyboard;
                        break;
                    case MainWindow.TouchpadButton.VolumeUp:
                        Slider.SliderUp(currentVolumeDevice);
                        break;
                    case MainWindow.TouchpadButton.VolumeDown:
                        Slider.SliderDown(currentVolumeDevice);
                        break;
                    case MainWindow.TouchpadButton.CaptureScreen:
                        Buttons.BtnClick(Screenshot);
                        break;
                    case MainWindow.TouchpadButton.Recording:
                        Buttons.BtnClick(Recording);
                        break;
                    case MainWindow.TouchpadButton.HighLight:
                        Buttons.BtnClick(Captures);
                        break;
                    case MainWindow.TouchpadButton.OpenFolder:
                        Buttons.BtnClick(Explorer);
                        break;
                        case MainWindow.TouchpadButton.KeyboardLightingRepeat:
                        Buttons.BtnClick(Keyboard);
                        break;
                    case MainWindow.TouchpadButton.CoolerBoost:
                        Buttons.BtnClick(Fan);
                        break;
                    case MainWindow.TouchpadButton.Emoji:
                        Buttons.BtnClick(Emoji);
                        break;
                    case MainWindow.TouchpadButton.SwitchProjector:
                        Buttons.BtnClick(Project);
                        break;
                    case MainWindow.TouchpadButton.SwitchWebcam:
                        Buttons.BtnClick(Webcam);
                        break;
                    case MainWindow.TouchpadButton.BTMatching:
                        Buttons.BtnClick(BtDiscovery);
                        break;
                    case MainWindow.TouchpadButton.SwitchBT:
                        Buttons.BtnClick(Bluetooth);
                        break;
                    case MainWindow.TouchpadButton.SwitchMicrophone:
                        Buttons.BtnClick(Microphone);
                        break;
                    case MainWindow.TouchpadButton.SwitchCrosshair:
                        Buttons.BtnClick(Crosshair);
                        break;
                    case MainWindow.TouchpadButton.MacroM1:
                        Buttons.BtnClick(Macro1);
                        break;
                    case MainWindow.TouchpadButton.MacroM2:
                        Buttons.BtnClick(Macro2);
                        break;
                    case MainWindow.TouchpadButton.MacroM3:
                        Buttons.BtnClick(Macro3);
                        break;
                    case MainWindow.TouchpadButton.MacroM4:
                        Buttons.BtnClick(Macro4);
                        break;
                    case MainWindow.TouchpadButton.MacroM5:
                        Buttons.BtnClick(Macro5);
                        break;
                    case MainWindow.TouchpadButton.MacroMenu:
                        Buttons.BtnClick(MacroBig);
                        break;
                }
            }
            return IntPtr.Zero;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(settings));
        }

        public enum TouchpadButton : uint
        {
            None = 0,
            Power = 7,
            SpeakerVolume = 8,
            MicrophoneVolume = 9,
            BrightnessMonitor = 10, // 0x0000000A
            BrightnessKeyboard = 11, // 0x0000000B
            VolumeUp = 12, // 0x0000000C
            VolumeDown = 13, // 0x0000000D
            CaptureScreen = 14, // 0x0000000E
            Recording = 15, // 0x0000000F
            HighLight = 16, // 0x00000010
            OpenFolder = 17, // 0x00000011
            KeyboardLightingRepeat = 18, // 0x00000012
            CoolerBoost = 19, // 0x00000013
            Emoji = 20, // 0x00000014
            SwitchProjector = 21, // 0x00000015
            SwitchWebcam = 22, // 0x00000016
            BTMatching = 23, // 0x00000017
            SwitchBT = 24, // 0x00000018
            SwitchMicrophone = 25, // 0x00000019
            SwitchCrosshair = 26, // 0x0000001A
            MacroM1 = 27, // 0x0000001B
            MacroM2 = 28, // 0x0000001C
            MacroM3 = 29, // 0x0000001D
            MacroM4 = 30, // 0x0000001E
            MacroM5 = 31, // 0x0000001F
            MacroMenu = 35, // 0x00000023
        }

        public enum VolumeDevice : uint
        {
            None,
            Speaker,
            Microphone,
            Screen,
            Keyboard,
        }
    }
}