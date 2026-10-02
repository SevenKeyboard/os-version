namespace SevenKeyboard
{
    public static class OSVersion
    {
        public const int BuildTh1 = 10240;
        public const int BuildTh2 = 10586;
        public const int BuildRs1 = 14393;
        public const int BuildRs2 = 15063;
        public const int BuildRs3 = 16299;
        public const int BuildRs4 = 17134;
        public const int BuildRs5 = 17763;
        public const int Build19H1 = 18362;
        public const int Build19H2 = 18363;
        public const int Build20H1 = 19041;
        public const int BuildWin10_20H2 = 19042;
        public const int BuildWin10_21H1 = 19043;
        public const int BuildWin10_21H2 = 19044;
        public const int BuildWin10_22H2 = 19045;
        public const int Build21H2 = 22000;
        public const int Build22H2 = 22621;
        public const int Build23H2 = 22631;
        public const int Build24H2 = 26100;
        public const int Build25H2 = 26200;
        public const int Build26H2 = 26300;
        public const int Build26H1 = 28000;

        public static int MajorVersion
            => System.Environment.OSVersion.Version.Major;

        public static int MinorVersion
            => System.Environment.OSVersion.Version.Minor;

        public static int BuildNumber
            => System.Environment.OSVersion.Version.Build;

        public static bool IsWindowsXPOrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(5, 1);

        public static bool IsWindowsVistaOrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(6, 0);

        public static bool IsWindows7OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(6, 1);

        public static bool IsWindows8OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(6, 2);

        public static bool IsWindows8Point1OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(6, 3);

        public static bool IsWindows10OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10);

        public static bool IsWindows10TS1OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildTh1);

        public static bool IsWindows10TS2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildTh2);

        public static bool IsWindows10RS1OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildRs1);

        public static bool IsWindows10RS2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildRs2);

        public static bool IsWindows10RS3OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildRs3);

        public static bool IsWindows10RS4OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildRs4);

        public static bool IsWindows10RS5OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildRs5);

        public static bool IsWindows1019H1OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build19H1);

        public static bool IsWindows1019H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build19H2);

        public static bool IsWindows1020H1OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build20H1);

        public static bool IsWindows1020H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWin10_20H2);

        public static bool IsWindows1021H1OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWin10_21H1);

        public static bool IsWindows1021H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWin10_21H2);

        public static bool IsWindows1022H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, BuildWin10_22H2);
        public static bool IsWindows11OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build21H2);

        public static bool IsWindows1121H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build21H2);

        public static bool IsWindows1122H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build22H2);
        public static bool IsWindows1123H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build23H2);

        public static bool IsWindows1124H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build24H2);

        public static bool IsWindows1125H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build25H2);

        public static bool IsWindows1126H2OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build26H2);

        public static bool IsWindows1126H1OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(10, 0, Build26H1);
    }
}