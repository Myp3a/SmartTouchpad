// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.KeyPressEvent
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System;

namespace SmartTouchpad
{
  public class KeyPressEvent
  {
    public string DeviceName;
    public string DeviceType;
    public IntPtr DeviceHandle;
    public string Name;
    private string _source;
    public int VKey;
    public string VKeyName;
    public uint Message;
    public string KeyPressState;

    public string Source
    {
      get => this._source;
      set => this._source = string.Format("Keyboard_{0}", (object) value.PadLeft(2, '0'));
    }

    public override string ToString()
    {
      return string.Format("Device\n DeviceName: {0}\n DeviceType: {1}\n DeviceHandle: {2}\n Name: {3}\n", (object) this.DeviceName, (object) this.DeviceType, (object) this.DeviceHandle.ToInt64().ToString("X"), (object) this.Name);
    }
  }
}
