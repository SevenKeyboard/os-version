//==============================================================
// OSVersion — Windows version detection helpers for .NET
//
// GitHub: https://github.com/SevenKeyboard/os-version
// Author: SevenKeyboard Ltd. (2026)
// License: The Unlicense
//
// Documentation / References:
//   Update WINVER and _WIN32_WINNT:
//     https://learn.microsoft.com/en-us/cpp/porting/modifying-winver-and-win32-winnt?view=msvc-170
//   versionhelpers.h header:
//     https://learn.microsoft.com/en-us/windows/win32/api/versionhelpers/
//   OSVERSIONINFOEXW structure (winnt.h):
//     https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw
//==============================================================

// Example Usage:
//     System.Console.WriteLine(
//         $"{SevenKeyboard.OSVersion.MajorVersion}.{SevenKeyboard.OSVersion.MinorVersion}.{SevenKeyboard.OSVersion.BuildNumber}");
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
        public const ushort _WIN32_WINNT_NT4          = 0x0400; // Windows NT 4.0
        public const ushort _WIN32_WINNT_WIN2K        = 0x0500; // Windows 2000
        public const ushort _WIN32_WINNT_WINXP        = 0x0501; // Windows XP
        public const ushort _WIN32_WINNT_WS03         = 0x0502; // Windows Server 2003
        public const ushort _WIN32_WINNT_WIN6         = 0x0600; // Windows Vista
        public const ushort _WIN32_WINNT_VISTA        = 0x0600; // Windows Vista
        public const ushort _WIN32_WINNT_WS08         = 0x0600; // Windows Server 2008
        public const ushort _WIN32_WINNT_LONGHORN     = 0x0600; // Windows Vista
        public const ushort _WIN32_WINNT_WIN7         = 0x0601; // Windows 7
        public const ushort _WIN32_WINNT_WIN8         = 0x0602; // Windows 8
        public const ushort _WIN32_WINNT_WINBLUE      = 0x0603; // Windows 8.1
        public const ushort _WIN32_WINNT_WINTHRESHOLD = 0x0A00; // Windows 10
        public const ushort _WIN32_WINNT_WIN10        = 0x0A00; // Windows 10

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

        public static int MajorVersion
            => System.Environment.OSVersion.Version.Major;

        public static int MinorVersion
            => System.Environment.OSVersion.Version.Minor;

        public static int BuildNumber
            => System.Environment.OSVersion.Version.Build;

        public static byte ProductType
            => NativeVersionInfo.Value.wProductType;

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