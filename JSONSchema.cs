using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTouchpad
{
    public class JSONSchema
    {
        public class Settings
        {
            public Element Screenshot { get; set; } = new Element();
            public Element Recording { get; set; } = new Element();
            public Element Captures { get; set; } = new Element();
            public Element Explorer { get; set; } = new Element();
            public Element Keyboard { get; set; } = new Element();
            public Element Fan { get; set; } = new Element();
            public Element Emoji { get; set; } = new Element();
            public Element Project { get; set; } = new Element();
            public Element Webcam { get; set; } = new Element();
            public Element BtDiscovery { get; set; } = new Element();
            public Element Bluetooth { get; set; } = new Element();
            public Element Microphone { get; set; } = new Element();
            public Element Crosshair { get; set; } = new Element();
            public Element Macro1 { get; set; } = new Element();
            public Element Macro2 { get; set; } = new Element();
            public Element Macro3 { get; set; } = new Element();
            public Element Macro4 { get; set; } = new Element();
            public Element Macro5 { get; set; } = new Element();
            public Element MacroBig { get; set; } = new Element();
        }

        public class Element
        {
            public int Action { get; set; } = 0;
            public List<int> Keys { get; set; } = new List<int>();
            public string Path { get; set; } = "";
            public string Args { get; set; } = "";
        }
    }
}
