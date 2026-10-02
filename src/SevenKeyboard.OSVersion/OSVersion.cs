namespace SevenKeyboard
{
    public static class OSVersion
    {
        public static bool IsWindows10OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10);
        }

        public static bool IsWindows11OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000);
        }
    }
}