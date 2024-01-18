namespace SmartTouchpad
{
    [Flags]
    internal enum RawInputDeviceFlags
    {
        NONE = 0x00000000,
        REMOVE = 0x00000001,
        EXCLUDE = 0x00000010,
        PAGEONLY = 0x00000020,
        NOLEGACY = 0x00000030,
        INPUTSINK = 0x00000100,
        CAPTUREMOUSE = 0x00000200,
        NOHOTKEYS = 0x00000200,
        APPKEYS = 0x00000400,
        EXINPUTSINK = 0x00001000,
        DEVNOTIFY = 0x00002000,
    }
}
