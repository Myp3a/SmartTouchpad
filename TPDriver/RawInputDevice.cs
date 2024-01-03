// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.RawInputDevice
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System;

namespace SmartTouchpad
{
  internal struct RawInputDevice
  {
    internal HidUsagePage UsagePage;
    internal HidUsage Usage;
    internal RawInputDeviceFlags Flags;
    internal IntPtr Target;

    public override string ToString()
    {
      return string.Format("{0}/{1}, flags: {2}, target: {3}", (object) this.UsagePage, (object) this.Usage, (object) this.Flags, (object) this.Target);
    }
  }
}
