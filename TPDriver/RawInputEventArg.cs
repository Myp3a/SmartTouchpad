// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.RawInputEventArg
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System;

namespace SmartTouchpad
{
  public class RawInputEventArg : EventArgs
  {
    public RawInputEventArg(KeyPressEvent arg) => this.KeyPressEvent = arg;

    public KeyPressEvent KeyPressEvent { get; private set; }
  }
}
