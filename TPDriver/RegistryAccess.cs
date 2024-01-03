// Decompiled with JetBrains decompiler
// Type: WPFSmartTouchpad.RegistryAccess
// Assembly: SmartTouchpad, Version=1.0.2305.1601, Culture=neutral, PublicKeyToken=null
// MVID: 1C2831E4-F036-4950-937B-1C607555E725
// Assembly location: C:\Program Files (x86)\MSI\Smart Touchpad\SmartTouchpad.exe

using Microsoft.Win32;

namespace SmartTouchpad
{
  internal static class RegistryAccess
  {
    internal static RegistryKey GetDeviceKey(string device)
    {
      string[] strArray = device.Substring(4).Split('#');
      string str1 = strArray[0];
      string str2 = strArray[1];
      string str3 = strArray[2];
      return Registry.LocalMachine.OpenSubKey(string.Format("System\\CurrentControlSet\\Enum\\{0}\\{1}\\{2}", (object) str1, (object) str2, (object) str3));
    }

    internal static string GetClassType(string classGuid)
    {
      RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\" + classGuid);
      return registryKey == null ? string.Empty : (string) registryKey.GetValue("Class");
    }
  }
}
