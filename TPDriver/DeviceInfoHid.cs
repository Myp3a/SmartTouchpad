// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.DeviceInfoHid
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

namespace SmartTouchpad
{
  public struct DeviceInfoHid
  {
    public uint VendorID;
    public uint ProductID;
    public uint VersionNumber;
    public ushort UsagePage;
    public ushort Usage;

    public override string ToString()
    {
      return string.Format("HidInfo\n VendorID: {0}\n ProductID: {1}\n VersionNumber: {2}\n UsagePage: {3}\n Usage: {4}\n", (object) this.VendorID, (object) this.ProductID, (object) this.VersionNumber, (object) this.UsagePage, (object) this.Usage);
    }
  }
}
