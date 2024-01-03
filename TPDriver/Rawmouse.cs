// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.Rawmouse
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System.Runtime.InteropServices;

namespace SmartTouchpad
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct Rawmouse
  {
    [FieldOffset(0)]
    public ushort usFlags;
    [FieldOffset(4)]
    public uint ulButtons;
    [FieldOffset(4)]
    public ushort usButtonFlags;
    [FieldOffset(6)]
    public ushort usButtonData;
    [FieldOffset(8)]
    public uint ulRawButtons;
    [FieldOffset(12)]
    public int lLastX;
    [FieldOffset(16)]
    public int lLastY;
    [FieldOffset(20)]
    public uint ulExtraInformation;
  }
}
