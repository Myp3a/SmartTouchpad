// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.DeviceInfoMouse
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

namespace SmartTouchpad
{
  public struct DeviceInfoMouse
  {
    public uint Id;
    public uint NumberOfButtons;
    public uint SampleRate;
    public bool HasHorizontalWheel;

    public override string ToString()
    {
      return string.Format("MouseInfo\n Id: {0}\n NumberOfButtons: {1}\n SampleRate: {2}\n HorizontalWheel: {3}\n", (object) this.Id, (object) this.NumberOfButtons, (object) this.SampleRate, (object) this.HasHorizontalWheel);
    }
  }
}
