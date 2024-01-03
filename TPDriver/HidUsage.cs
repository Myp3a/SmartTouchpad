// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.HidUsage
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

namespace SmartTouchpad
{
  public enum HidUsage : ushort
  {
    Undefined = 0,
    Consumer_Volume = 1,
    Pointer = 1,
    Mouse = 2,
    Joystick = 4,
    Gamepad = 5,
    Keyboard = 6,
    Keypad = 7,
    TP_Power = 7,
    TP_Speaker_Volume = 8,
    TP_Microphone_Volume = 9,
    TP_Brightness_Monitor = 10, // 0x000A
    TP_Brightness_Keyboard = 11, // 0x000B
    Consumer = 12, // 0x000C
    TP_Scroll_Bar_Up = 12, // 0x000C
    TP_Scroll_Bar_Down = 13, // 0x000D
    TP_Capture_Screen = 14, // 0x000E
    TP_Recording = 15, // 0x000F
    TP_High_Light = 16, // 0x0010
    TP_Open_Folder_Of_Image_Captured = 17, // 0x0011
    TP_Keyboard_Lighting_Repeated = 18, // 0x0012
    TP_Cooler_Boost = 19, // 0x0013
    TP_Emoji = 20, // 0x0014
    TP_Switch_Projector = 21, // 0x0015
    TP_Switch_Webcam = 22, // 0x0016
    TP_BT_Matching = 23, // 0x0017
    TP_Switch_BT = 24, // 0x0018
    TP_Switch_Microphone = 25, // 0x0019
    TP_Switch_Crosshair = 26, // 0x001A
    TP_Macro_M1 = 27, // 0x001B
    TP_Macro_M2 = 28, // 0x001C
    TP_Macro_M3 = 29, // 0x001D
    TP_Macro_M4 = 30, // 0x001E
    TP_Macro_M5 = 31, // 0x001F
    TP_Macro_Menu = 35, // 0x0023
    PageDown = 78, // 0x004E
    SystemControl = 128, // 0x0080
    Tablet = 128, // 0x0080
  }
}
