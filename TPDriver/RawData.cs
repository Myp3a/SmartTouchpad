using System.Runtime.InteropServices;

namespace SmartTouchpad
{
    [StructLayout(LayoutKind.Explicit)]
    public struct RawData
    {
        [FieldOffset(0)]
        internal Rawkeyboard keyboard;
    }
}
