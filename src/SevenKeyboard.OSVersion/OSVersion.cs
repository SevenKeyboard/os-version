namespace SevenKeyboard
{
    public static class OSVersion
    {
        public static bool IsWindows10OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10);
        }
    }
}