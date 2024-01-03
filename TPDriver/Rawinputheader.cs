// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.Rawinputheader
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System;

namespace SmartTouchpad
{
  public struct Rawinputheader
  {
    public uint dwType;
    public uint dwSize;
    public IntPtr hDevice;
    public IntPtr wParam;

    public override string ToString()
    {
      return string.Format("RawInputHeader\n dwType : {0}\n dwSize : {1}\n hDevice : {2}\n wParam : {3}", (object) this.dwType, (object) this.dwSize, (object) this.hDevice, (object) this.wParam);
    }
  }
}
