namespace SevenKeyboard
{
    public static class OSVersion
    {
        public const int BuildWindows10_TH1 = 10240;
        public const int BuildWindows10_TH2 = 10586;
        public const int BuildWindows10_RS1 = 14393;
        public const int BuildWindows10_RS2 = 15063;
        public const int BuildWindows10_RS3 = 16299;
        public const int BuildWindows10_RS4 = 17134;
        public const int BuildWindows10_RS5 = 17763;
        public const int BuildWindows10_19H1 = 18362;
        public const int BuildWindows10_19H2 = 18363;
        public const int BuildWindows10_20H1 = 19041;
        public const int BuildWindows10_20H2 = 19042;
        public const int BuildWindows10_21H1 = 19043;
        public const int BuildWindows10_21H2 = 19044;
        public const int BuildWindows10_22H2 = 19045;
        public const int BuildWindows11_21H2 = 22000;
        public const int BuildWindows11_22H2 = 22621;
        public const int BuildWindows11_23H2 = 22631;
        public const int BuildWindows11_24H2 = 26100;
        public const int BuildWindows11_25H2 = 26200;
        public const int BuildWindows11_26H2 = 26300;
        public const int BuildWindows11_26H1 = 28000;

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
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_TH1);
        }

        public static bool IsWindows10TS2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_TH2);
        }

        public static bool IsWindows10RS1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_RS1);
        }

        public static bool IsWindows10RS2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_RS2);
        }

        public static bool IsWindows10RS3OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, 16259);
        }

        public static bool IsWindows10RS4OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_RS4);
        }

        public static bool IsWindows10RS5OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_RS5);
        }

        public static bool IsWindows1019H1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_19H1);
        }

        public static bool IsWindows1019H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_19H2);
        }

        public static bool IsWindows1020H1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_20H1);
        }

        public static bool IsWindows1020H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_20H2);
        }

        public static bool IsWindows1021H1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_21H1);
        }

        public static bool IsWindows1021H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_21H2);
        }

        public static bool IsWindows1022H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows10_22H2);
        }
        public static bool IsWindows11OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_21H2);
        }

        public static bool IsWindows1121H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_21H2);
        }

        public static bool IsWindows1122H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_22H2);
        }
        public static bool IsWindows1123H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_23H2);
        }

        public static bool IsWindows1124H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_24H2);
        }

        public static bool IsWindows1125H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_25H2);
        }

        public static bool IsWindows1126H2OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_26H2);
        }

        public static bool IsWindows1126H1OrGreater()
        {
            return System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWindows11_26H1);
        }
    }
}