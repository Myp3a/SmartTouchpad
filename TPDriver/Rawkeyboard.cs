// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.Rawkeyboard
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

namespace SmartTouchpad
{
  internal struct Rawkeyboard
  {
    public ushort Makecode;
    public ushort Flags;
    private readonly ushort Reserved;
    public ushort VKey;
    public uint Message;
    public uint ExtraInformation;

    public override string ToString()
    {
      return string.Format("Rawkeyboard\n Makecode: {0}\n Makecode(hex) : {0:X}\n Flags: {1}\n Reserved: {2}\n VKeyName: {3}\n Message: {4}\n ExtraInformation {5}\n", (object) this.Makecode, (object) this.Flags, (object) this.Reserved, (object) this.VKey, (object) this.Message, (object) this.ExtraInformation);
    }
  }
}
