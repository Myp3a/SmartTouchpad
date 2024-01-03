// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.DeviceInfo
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System.Runtime.InteropServices;

namespace SmartTouchpad
{
  [StructLayout(LayoutKind.Explicit)]
  public struct DeviceInfo
  {
    [FieldOffset(0)]
    public int Size;
    [FieldOffset(4)]
    public int Type;
    [FieldOffset(8)]
    public DeviceInfoMouse MouseInfo;
    [FieldOffset(8)]
    public DeviceInfoKeyboard KeyboardInfo;
    [FieldOffset(8)]
    public DeviceInfoHid HIDInfo;

    public override string ToString()
    {
      return string.Format("DeviceInfo\n Size: {0}\n Type: {1}\n", (object) this.Size, (object) this.Type);
    }
  }
}
