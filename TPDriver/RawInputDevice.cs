namespace SmartTouchpad
{
    internal struct RawInputDevice
    {
        internal HidUsagePage UsagePage;
        internal ushort Usage;
        internal RawInputDeviceFlags Flags;
        internal IntPtr Target;

        public override string ToString()
        {
            return string.Format("{0}/{1}, flags: {2}, target: {3}", (object)this.UsagePage, (object)this.Usage, (object)this.Flags, (object)this.Target);
        }
    }
}
