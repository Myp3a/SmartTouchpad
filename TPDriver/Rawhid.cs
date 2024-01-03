// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.Rawhid
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

namespace SmartTouchpad
{
  internal struct Rawhid
  {
    public uint dwSizHid;
    public uint dwCount;
    public byte bRawData;

    public override string ToString()
    {
      return string.Format("Rawhib\n dwSizeHid : {0}\n dwCount : {1}\n bRawData : {2}\n", (object) this.dwSizHid, (object) this.dwCount, (object) this.bRawData);
    }
  }
}
