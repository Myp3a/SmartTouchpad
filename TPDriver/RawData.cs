// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.RawData
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System.Runtime.InteropServices;

namespace SmartTouchpad
{
  [StructLayout(LayoutKind.Explicit)]
  public struct RawData
  {
    [FieldOffset(0)]
    internal Rawmouse mouse;
    [FieldOffset(0)]
    internal Rawkeyboard keyboard;
    [FieldOffset(0)]
    internal Rawhid hid;
  }
}
