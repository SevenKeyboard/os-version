//==============================================================
// OSVersion — Windows version detection helpers for .NET
//
// GitHub: https://github.com/SevenKeyboard/os-version
// Author: SevenKeyboard Ltd. (2026)
// License: The Unlicense
//
// Documentation / References:
//   Update WINVER and _WIN32_WINNT
//     https://learn.microsoft.com/en-us/cpp/porting/modifying-winver-and-win32-winnt?view=msvc-170
//   versionhelpers.h header
//     https://learn.microsoft.com/en-us/windows/win32/api/versionhelpers/
//   OSVERSIONINFOEXW structure (winnt.h)
//     https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw
//==============================================================

// Example Usage:
//     System.Console.WriteLine(
//         $"{SevenKeyboard.OSVersion.MajorVersion}.{SevenKeyboard.OSVersion.MinorVersion}.{SevenKeyboard.OSVersion.BuildNumber}");
//
//     System.Console.WriteLine($"{SevenKeyboard.OSVersion.Win}\n{SevenKeyboard.OSVersion.Build}");
//
//     System.Console.WriteLine(
//         $"IsWindows10OrGreater: {SevenKeyboard.OSVersion.IsWindows10OrGreater()}\n" +
//         $"IsWindows11OrGreater: {SevenKeyboard.OSVersion.IsWindows11OrGreater()}\n" +
//         $"IsWindowsServer: {SevenKeyboard.OSVersion.IsWindowsServer()}");

using System.Runtime.InteropServices;

namespace SevenKeyboard
{
    public static class OSVersion
    {
        // Update WINVER and _WIN32_WINNT
        // https://learn.microsoft.com/en-us/cpp/porting/modifying-winver-and-win32-winnt?view=msvc-170
        public const ushort _WIN32_WINNT_NT4            = 0x0400; // Windows NT 4.0
        public const ushort _WIN32_WINNT_WIN2K          = 0x0500; // Windows 2000
        public const ushort _WIN32_WINNT_WINXP          = 0x0501; // Windows XP
        public const ushort _WIN32_WINNT_WS03           = 0x0502; // Windows Server 2003
        public const ushort _WIN32_WINNT_WIN6           = 0x0600; // Windows Vista
        public const ushort _WIN32_WINNT_VISTA          = 0x0600; // Windows Vista
        public const ushort _WIN32_WINNT_WS08           = 0x0600; // Windows Server 2008
        public const ushort _WIN32_WINNT_LONGHORN       = 0x0600; // Windows Vista
        public const ushort _WIN32_WINNT_WIN7           = 0x0601; // Windows 7
        public const ushort _WIN32_WINNT_WIN8           = 0x0602; // Windows 8
        public const ushort _WIN32_WINNT_WINBLUE        = 0x0603; // Windows 8.1
        public const ushort _WIN32_WINNT_WINTHRESHOLD   = 0x0A00; // Windows 10
        public const ushort _WIN32_WINNT_WIN10          = 0x0A00; // Windows 10

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

        public const byte VER_NT_DOMAIN_CONTROLLER = 0x0000002;
        public const byte VER_NT_SERVER = 0x0000003;
        public const byte VER_NT_WORKSTATION = 0x0000001;

        // versionhelpers.h
        // https://learn.microsoft.com/en-us/windows/win32/api/versionhelpers/

        public static bool IsWindowsVersionOrGreater(
            int majorVersion,
            int minorVersion,
            int servicePackMajor,
            int buildNumber)
        {
            System.ArgumentOutOfRangeException.ThrowIfNegative(majorVersion);
            System.ArgumentOutOfRangeException.ThrowIfNegative(minorVersion);
            System.ArgumentOutOfRangeException.ThrowIfNegative(servicePackMajor);
            System.ArgumentOutOfRangeException.ThrowIfGreaterThan(servicePackMajor, (int)ushort.MaxValue);
            System.ArgumentOutOfRangeException.ThrowIfNegative(buildNumber);

            if (MajorVersion > majorVersion)
                return true;
            else if (MajorVersion < majorVersion)
                return false;
            if (MinorVersion > minorVersion)
                return true;
            else if (MinorVersion < minorVersion)
                return false;
            if (ServicePackMajor > servicePackMajor)
                return true;
            else if (ServicePackMajor < servicePackMajor)
                return false;
            return BuildNumber >= buildNumber;
        }

        public static bool IsWindowsXPOrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(5, 1);

        public static bool IsWindowsXPSP1OrGreater()
            => IsWindowsVersionOrGreater(
                HIBYTE(_WIN32_WINNT_WINXP),
                LOBYTE(_WIN32_WINNT_WINXP),
                1,
                0);

        public static bool IsWindowsXPSP2OrGreater()
            => IsWindowsVersionOrGreater(
                HIBYTE(_WIN32_WINNT_WINXP),
                LOBYTE(_WIN32_WINNT_WINXP),
                2,
                0);

        public static bool IsWindowsXPSP3OrGreater()
            => IsWindowsVersionOrGreater(
                HIBYTE(_WIN32_WINNT_WINXP),
                LOBYTE(_WIN32_WINNT_WINXP),
                3,
                0);

        public static bool IsWindowsVistaOrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(6, 0);

        public static bool IsWindowsVistaSP1OrGreater()
            => IsWindowsVersionOrGreater(
                HIBYTE(_WIN32_WINNT_VISTA),
                LOBYTE(_WIN32_WINNT_VISTA),
                1,
                0);

        public static bool IsWindowsVistaSP2OrGreater()
            => IsWindowsVersionOrGreater(
                HIBYTE(_WIN32_WINNT_VISTA),
                LOBYTE(_WIN32_WINNT_VISTA),
                2,
                0);

        public static bool IsWindows7OrGreater()
            => System.OperatingSystem.IsWindowsVersionAtLeast(6, 1);

        public static bool IsWindows7SP1OrGreater()
            => IsWindowsVersionOrGreater(
                HIBYTE(_WIN32_WINNT_WIN7),
                LOBYTE(_WIN32_WINNT_WIN7),
                1,
                0);

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

        public static bool IsWindowsServer()
        {
            switch (ProductType)
            {
                case VER_NT_WORKSTATION:
                    return false;

                case VER_NT_DOMAIN_CONTROLLER:
                case VER_NT_SERVER:
                    return true;

                default:
                    throw new System.InvalidOperationException("Unknown Windows product type.");
            }
        }

        public static byte HIBYTE(ushort w)
            => (byte)((w >> 8) & 0xFF);

        public static byte LOBYTE(ushort w)
            => (byte)(w & 0xFF);

        public static string Win
        {
            get
            {
                switch (WinVer)
                {
                    case _WIN32_WINNT_WIN10:
                        if (BuildNumber >= Build21H2)
                            return "WIN_11";
                        return "WIN_10";
                    case _WIN32_WINNT_WINBLUE:
                        return "WIN_8.1";
                    case _WIN32_WINNT_WIN8:
                        return "WIN_8";
                    case _WIN32_WINNT_WIN7:
                        return "WIN_7";
                    case _WIN32_WINNT_VISTA:
                        return "WIN_VISTA";
                    case _WIN32_WINNT_WINXP:
                        return "WIN_XP";
                    case _WIN32_WINNT_WIN2K:
                        return "WIN_2000";
                    case _WIN32_WINNT_NT4:
                        return "WIN_NT4";
                    default:
                        return "WIN_UNSUPPORTED";
                }
            }
        }

        // Return the highest known numeric threshold, not an exact release identity.
        public static string Build
        {
            get
            {
                switch (Win)
                {
                    case "WIN_11":
                        if (BuildNumber >= Build26H1)
                            return "26H1";
                        if (BuildNumber >= Build26H2)
                            return "26H2";
                        if (BuildNumber >= Build25H2)
                            return "25H2";
                        if (BuildNumber >= Build24H2)
                            return "24H2";
                        if (BuildNumber >= Build23H2)
                            return "23H2";
                        if (BuildNumber >= Build22H2)
                            return "22H2";
                        if (BuildNumber >= Build21H2)
                            return "21H2";
                        return "";

                    case "WIN_10":
                        if (BuildNumber >= BuildWin10_22H2)
                            return "22H2";
                        if (BuildNumber >= BuildWin10_21H2)
                            return "21H2";
                        if (BuildNumber >= BuildWin10_21H1)
                            return "21H1";
                        if (BuildNumber >= BuildWin10_20H2)
                            return "20H2";
                        if (BuildNumber >= Build20H1)
                            return "20H1";
                        if (BuildNumber >= Build19H2)
                            return "19H2";
                        if (BuildNumber >= Build19H1)
                            return "19H1";
                        if (BuildNumber >= BuildRs5)
                            return "RS5";
                        if (BuildNumber >= BuildRs4)
                            return "RS4";
                        if (BuildNumber >= BuildRs3)
                            return "RS3";
                        if (BuildNumber >= BuildRs2)
                            return "RS2";
                        if (BuildNumber >= BuildRs1)
                            return "RS1";
                        if (BuildNumber >= BuildTh2)
                            return "TH2";
                        if (BuildNumber >= BuildTh1)
                            return "TH1";
                        return "";

                    default:
                        return "";
                }
            }
        }

        public static int WinVer
            => (MajorVersion << 8) | MinorVersion;

        public static int OSVersionInfoSize
            => (int)NativeVersionInfo.Value.dwOSVersionInfoSize;

        public static int MajorVersion
            => System.Environment.OSVersion.Version.Major;

        public static int MinorVersion
            => System.Environment.OSVersion.Version.Minor;

        public static int BuildNumber
            => System.Environment.OSVersion.Version.Build;

        public static int PlatformId
            => (int)NativeVersionInfo.Value.dwPlatformId;

        public static string CSDVersion
            => NativeVersionInfo.Value.szCSDVersion;

        public static int ServicePackMajor
            => NativeVersionInfo.Value.wServicePackMajor;

        public static int ServicePackMinor
            => NativeVersionInfo.Value.wServicePackMinor;

        public static ushort SuiteMask
            => NativeVersionInfo.Value.wSuiteMask;

        public static byte ProductType
            => NativeVersionInfo.Value.wProductType;

        public static byte Reserved
            => NativeVersionInfo.Value.wReserved;

        // Query only when native information is requested; initialization failures stay in this type.
        private static class NativeVersionInfo
        {
            public static readonly OSVERSIONINFOEXW Value;

            static NativeVersionInfo()
            {
                if (!TryGetVersionInfo(out OSVERSIONINFOEXW versionInfo))
                    throw new System.InvalidOperationException("Failed to query Windows version information.");

                Value = versionInfo;
            }
        }

        [DllImport("ntdll.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int RtlGetVersion(ref OSVERSIONINFOEXW versionInfo);

        private static bool TryGetVersionInfo(out OSVERSIONINFOEXW versionInfo)
        {
            const int STATUS_SUCCESS = 0x00000000;

            versionInfo = new OSVERSIONINFOEXW();
            versionInfo.dwOSVersionInfoSize = (uint)Marshal.SizeOf<OSVERSIONINFOEXW>();

            return RtlGetVersion(ref versionInfo) == STATUS_SUCCESS;
        }

        // OSVERSIONINFOEXW
        // https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct OSVERSIONINFOEXW
        {
            public uint dwOSVersionInfoSize;
            public uint dwMajorVersion;
            public uint dwMinorVersion;
            public uint dwBuildNumber;
            public uint dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public ushort wServicePackMajor;
            public ushort wServicePackMinor;
            public ushort wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
    }
}