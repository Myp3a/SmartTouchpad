using System.Runtime.InteropServices;

namespace SmartTouchpad
{
    public static class Win32
    {

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern int GetRawInputData(
          IntPtr hRawInput,
          DataCommand command,
          out InputData buffer,
          [In, Out] ref int size,
          int cbSizeHeader);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern int GetRawInputData(
          IntPtr hRawInput,
          DataCommand command,
          [Out] IntPtr pData,
          [In, Out] ref int size,
          int sizeHeader);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern uint GetRawInputDeviceInfo(
          IntPtr hDevice,
          RawInputDeviceInfo command,
          IntPtr pData,
          ref uint size);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern uint GetRawInputDeviceList(
          IntPtr pRawInputDeviceList,
          ref uint numberDevices,
          uint size);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern bool RegisterRawInputDevices(
          RawInputDevice[] pRawInputDevice,
          uint numberDevices,
          uint size);
    }
}
