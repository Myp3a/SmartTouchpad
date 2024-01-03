using SmartTouchpad.Functions;
using System.Runtime.InteropServices;

namespace SmartTouchpad
{
    internal class Slider
    {
        [DllImport("User32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private static void SpeakerVolumeUp()
        {
            keybd_event((byte)175, (byte)0, 0, 0);
            keybd_event((byte)175, (byte)0, 2, 0);
        }

        private static void SpeakerVolumeDown()
        {
            keybd_event((byte)174, (byte)0, 0, 0);
            keybd_event((byte)174, (byte)0, 2, 0);
        }

        public static void SliderUp(MainWindow.VolumeDevice dev)
        {
            switch (dev)
            {
                case MainWindow.VolumeDevice.Speaker:
                    SpeakerVolumeUp(); 
                    break;
                case MainWindow.VolumeDevice.Screen:
                    int currbr = DisplayBrightness.Get();
                    currbr += 5;
                    if (currbr > 100) currbr = 100;
                    DisplayBrightness.Set(currbr);
                    break;
            }
        }

        public static void SliderDown(MainWindow.VolumeDevice dev)
        {
            switch (dev)
            {
                case MainWindow.VolumeDevice.Speaker:
                    SpeakerVolumeDown();
                    break;
                case MainWindow.VolumeDevice.Screen:
                    int currbr = DisplayBrightness.Get();
                    currbr -= 5;
                    if (currbr < 0) currbr = 0;
                    DisplayBrightness.Set(currbr);
                    break;
            }
        }
    }
}
