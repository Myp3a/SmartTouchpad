// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.DeviceInfoKeyboard
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

namespace SmartTouchpad
{
  public struct DeviceInfoKeyboard
  {
    public uint Type;
    public uint SubType;
    public uint KeyboardMode;
    public uint NumberOfFunctionKeys;
    public uint NumberOfIndicators;
    public uint NumberOfKeysTotal;

    public override string ToString()
    {
      return string.Format("DeviceInfoKeyboard\n Type: {0}\n SubType: {1}\n KeyboardMode: {2}\n NumberOfFunctionKeys: {3}\n NumberOfIndicators {4}\n NumberOfKeysTotal: {5}\n", (object) this.Type, (object) this.SubType, (object) this.KeyboardMode, (object) this.NumberOfFunctionKeys, (object) this.NumberOfIndicators, (object) this.NumberOfKeysTotal);
    }
  }
}
