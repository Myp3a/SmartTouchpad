// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.RawInputDeviceFlags
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using System;

namespace SmartTouchpad
{
  [Flags]
  internal enum RawInputDeviceFlags
  {
    NONE = 0,
    REMOVE = 1,
    EXCLUDE = 16, // 0x00000010
    PAGEONLY = 32, // 0x00000020
    NOLEGACY = PAGEONLY | EXCLUDE, // 0x00000030
    INPUTSINK = 256, // 0x00000100
    CAPTUREMOUSE = 512, // 0x00000200
    NOHOTKEYS = CAPTUREMOUSE, // 0x00000200
    APPKEYS = 1024, // 0x00000400
    EXINPUTSINK = 4096, // 0x00001000
    DEVNOTIFY = 8192, // 0x00002000
  }
}
