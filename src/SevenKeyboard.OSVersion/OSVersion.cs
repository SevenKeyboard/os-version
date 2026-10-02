namespace SevenKeyboard
{
    public static class OSVersion
    {
        public static bool IsWindowsXPOrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(5, 1);
        }

        public static bool IsWindowsVistaOrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(6, 0);
        }

        public static bool IsWindows7OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(6, 1);
        }

        public static bool IsWindows8OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(6, 2);
        }

        public static bool IsWindows8Point1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(6, 3);
        }

        public static bool IsWindows10OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10);
        }

        public static bool IsWindows10TS1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 10240);
        }

        public static bool IsWindows10TS2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 10586);
        }

        public static bool IsWindows10RS1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 14393);
        }

        public static bool IsWindows10RS2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 15063);
        }

        public static bool IsWindows10RS3OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 16259);
        }

        public static bool IsWindows10RS4OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17134);
        }

        public static bool IsWindows10RS5OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763);
        }

        public static bool IsWindows1019H1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 18362);
        }

        public static bool IsWindows1019H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 18363);
        }

        public static bool IsWindows1020H1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041);
        }

        public static bool IsWindows11OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000);
        }

        public static bool IsWindows1121H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000);
        }

        public static bool IsWindows1122H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22621);
        }
    }
}