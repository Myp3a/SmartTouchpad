using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartTouchpad.JSONSchema;

namespace SmartTouchpad
{
    public partial class MainWindow
    {
        public Element Screenshot
        {
            get => settings.Screenshot; set => settings.Screenshot = value;
        }

        public Element Recording
        {
            get => settings.Recording; set => settings.Recording = value;
        }

        public Element Captures
        {
            get => settings.Captures; set => settings.Captures = value;
        }

        public Element Explorer
        {
            get => settings.Explorer; set => settings.Explorer = value;
        }

        public Element Keyboard
        {
            get => settings.Keyboard; set => settings.Keyboard = value;
        }

        public Element Fan
        {
            get => settings.Fan; set => settings.Fan = value;
        }

        public Element Emoji
        {
            get => settings.Emoji; set => settings.Emoji = value;
        }

        public Element Project
        {
            get => settings.Project; set => settings.Project = value;
        }

        public Element Webcam
        {
            get => settings.Webcam; set => settings.Webcam = value;
        }

        public Element BtDiscovery
        {
            get => settings.BtDiscovery; set => settings.BtDiscovery = value;
        }

        public Element Bluetooth
        {
            get => settings.Bluetooth; set => settings.Bluetooth = value;
        }

        public Element Microphone
        {
            get => settings.Microphone; set => settings.Microphone = value;
        }

        public Element Crosshair
        {
            get => settings.Crosshair; set => settings.Crosshair = value;
        }

        public Element Macro1
        {
            get => settings.Macro1; set => settings.Macro1 = value;
        }

        public Element Macro2
        {
            get => settings.Macro2; set => settings.Macro2 = value;
        }

        public Element Macro3
        {
            get => settings.Macro3; set => settings.Macro3 = value;
        }

        public Element Macro4
        {
            get => settings.Macro4; set => settings.Macro4 = value;
        }

        public Element Macro5
        {
            get => settings.Macro5; set => settings.Macro5 = value;
        }

        public Element MacroBig
        {
            get => settings.MacroBig; set => settings.MacroBig = value;
        }
    }
}
