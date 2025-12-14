#Requires AutoHotkey v2.0.0+
;==============================================================
; OSVersion — Windows version detection helpers based on RtlGetVersion
;
; GitHub: https://github.com/SevenKeyboard/os-version
; Author: SevenKeyboard Ltd. (2025)
; License: The Unlicense
;
; Documentation / References:
;   Update WINVER and _WIN32_WINNT:
;     https://learn.microsoft.com/en-us/cpp/porting/modifying-winver-and-win32-winnt?view=msvc-170
;   versionhelpers.h header:
;     https://learn.microsoft.com/en-us/windows/win32/api/versionhelpers/
;   OSVERSIONINFOEXW structure (winnt.h):
;     https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw
;
;   Basic wrapper for the Windows Version Helper functions
;     https://www.autohotkey.com/boards/viewtopic.php?t=9628
;==============================================================

/*
Example Usage:
    msgBox A_OSVersion

    msgBox OSVersion.MajorVersion "." OSVersion.MinorVersion "." OSVersion.BuildNumber

    msgBox OSVersion.WIN "`n" OSVersion.BUILD

    msgBox "IsWindows10OrGreater: " OSVersion.isWindows10OrGreater()
        . "`nIsWindows11OrGreater: " OSVersion.isWindows11OrGreater()
        . "`nIsWindowsServer: " OSVersion.isWindowsServer()
*/

class VersionManager_OSVersion
{
    static _ := this._init()
    static _init()    {
        global
        OSVERSION_VERSION := "2.0.0"
    }
}
class OSVersion
{
    /*
     *  Update WINVER and _WIN32_WINNT
     * https://learn.microsoft.com/en-us/cpp/porting/modifying-winver-and-win32-winnt?view=msvc-170
     */
    static _WIN32_WINNT_NT4         := 0x0400 ;  // Windows NT 4.0
        ,_WIN32_WINNT_WIN2K         := 0x0500 ;  // Windows 2000
        ,_WIN32_WINNT_WINXP         := 0x0501 ;  // Windows XP
        ,_WIN32_WINNT_WS03          := 0x0502 ;  // Windows Server 2003
        ,_WIN32_WINNT_WIN6          := 0x0600 ;  // Windows Vista
        ,_WIN32_WINNT_VISTA         := 0x0600 ;  // Windows Vista
        ,_WIN32_WINNT_WS08          := 0x0600 ;  // Windows Server 2008
        ,_WIN32_WINNT_LONGHORN      := 0x0600 ;  // Windows Vista
        ,_WIN32_WINNT_WIN7          := 0x0601 ;  // Windows 7
        ,_WIN32_WINNT_WIN8          := 0x0602 ;  // Windows 8
        ,_WIN32_WINNT_WINBLUE       := 0x0603 ;  // Windows 8.1
        ,_WIN32_WINNT_WINTHRESHOLD  := 0x0A00 ;  // Windows 10
        ,_WIN32_WINNT_WIN10         := 0x0A00 ;  // Windows 10

        ,BUILD_TH1      := 10240
        ,BUILD_TH2      := 10586
        ,BUILD_RS1      := 14393
        ,BUILD_RS2      := 15063
        ,BUILD_RS3      := 16299
        ,BUILD_RS4      := 17134
        ,BUILD_RS5      := 17763
        ,BUILD_19H1     := 18362
        ,BUILD_19H2     := 18363
        ,BUILD_20H1     := 19041
        ,BUILD_21H2     := 22000
        ,BUILD_22H2     := 22621

        ,VER_NT_DOMAIN_CONTROLLER   := 0x0000002
        ,VER_NT_SERVER              := 0x0000003
        ,VER_NT_WORKSTATION         := 0x0000001

        ,_:=this._init()

    static _init()    {
        static STATUS_SUCCESS:=0x00000000
        this._lpVersionInformation:=this.OSVERSIONINFOEXW()
        if (dllCall("Ntdll.dll\RtlGetVersion", "Ptr",this._lpVersionInformation.ptr)==STATUS_SUCCESS)    {
            switch ((this.MajorVersion<<8)|this.MinorVersion)
            {
                case this._WIN32_WINNT_WIN10:
                    if (this.BuildNumber >= this.Build_21H2)
                        this._win:="WIN_11"
                    else
                        this._win:="WIN_10"                
                case this._WIN32_WINNT_WINBLUE:             this._win:="WIN_8.1"
                case this._WIN32_WINNT_WIN8:                this._win:="WIN_8"
                case this._WIN32_WINNT_WIN7:                this._win:="WIN_7"
                case this._WIN32_WINNT_VISTA:               this._win:="WIN_VISTA"
                case this._WIN32_WINNT_WINXP:               this._win:="WIN_XP"
                case this._WIN32_WINNT_WIN2K:               this._win:="WIN_2000"
                case this._WIN32_WINNT_NT4:                 this._win:="WIN_NT4"
                default:                                    this._win:="WIN_UNSUPPORTED"
            }
        }  else  {
            this._win:="WIN_UNSUPPORTED"
        }
        this._build:=""
        switch (this.WIN)
        {
            case "WIN_11":
                if (this.BuildNumber >= this.Build_22H2)
                    this._build:="22H2"
                else if (this.BuildNumber >= this.Build_21H2)
                    this._build:="21H2"
            case "WIN_10":
                if (this.BuildNumber >= this.BUILD_20H1)
                    this._build:="20H1"
                else if (this.BuildNumber >= this.BUILD_19H2)
                    this._build:="19H2"
                else if (this.BuildNumber >= this.BUILD_19H1)
                    this._build:="19H1"
                else if (this.BuildNumber >= this.BUILD_RS5)
                    this._build:="RS5"
                else if (this.BuildNumber >= this.BUILD_RS4)
                    this._build:="RS4"
                else if (this.BuildNumber >= this.BUILD_RS3)
                    this._build:="RS3"
                else if (this.BuildNumber >= this.BUILD_RS2)
                    this._build:="RS2"
                else if (this.BuildNumber >= this.BUILD_RS1)
                    this._build:="RS1"
                else if (this.BuildNumber >= this.BUILD_TH2)
                    this._build:="TH2"
                else if (this.BuildNumber >= this.BUILD_TH1)
                    this._build:="TH1"
        }
    }
    /*
     *  versionhelpers.h header
     * https://learn.microsoft.com/en-us/windows/win32/api/versionhelpers/
     */
    static isWindowsVersionOrGreater(majorVersion, minorVersion, servicePackMajor, buildNumber)    {
        if (this.MajorVersion !== 0)    {
            if (this.MajorVersion > majorVersion)
                return true
            else if (this.MajorVersion < majorVersion)
                return false
            if (this.MinorVersion > minorVersion)
                return true
            else if (this.MinorVersion < minorVersion)
                return false
            if (this.ServicePackMajor > servicePackMajor)
                return true
            else if (this.ServicePackMajor < servicePackMajor)
                return false
            if (this.BuildNumber >= buildNumber)
                return true
        }
        return false
    }
    static isWindowsXPOrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WINXP),this.LOBYTE(this._WIN32_WINNT_WINXP),0,0)
    }
    static isWindowsXPSP1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WINXP),this.LOBYTE(this._WIN32_WINNT_WINXP),1,0)
    }
    static isWindowsXPSP2OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WINXP),this.LOBYTE(this._WIN32_WINNT_WINXP),2,0)
    }
    static isWindowsXPSP3OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WINXP),this.LOBYTE(this._WIN32_WINNT_WINXP),3,0)
    }
    static isWindowsVistaOrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_VISTA),this.LOBYTE(this._WIN32_WINNT_VISTA),0,0)
    }
    static isWindowsVistaSP1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_VISTA),this.LOBYTE(this._WIN32_WINNT_VISTA),1,0)
    }
    static isWindowsVistaSP2OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_VISTA),this.LOBYTE(this._WIN32_WINNT_VISTA),2,0)
    }
    static isWindows7OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN7),this.LOBYTE(this._WIN32_WINNT_WIN7),0,0)
    }
    static isWindows7SP1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN7),this.LOBYTE(this._WIN32_WINNT_WIN7),1,0)
    }
    static isWindows8OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN8),this.LOBYTE(this._WIN32_WINNT_WIN8),0,0)
    }
    static isWindows8Point1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WINBLUE),this.LOBYTE(this._WIN32_WINNT_WINBLUE),0,0)
    }
    static isWindows10OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,0)
    }
    static isWindows10TS1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_TH1)
    }
    static isWindows10TS2OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_TH2)
    }
    static isWindows10RS1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_RS1)
    }
    static isWindows10RS2OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_RS2)
    }
    static isWindows10RS3OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_RS3)
    }
    static isWindows10RS4OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_RS4)
    }
    static isWindows10RS5OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_RS5)
    }
    static isWindows1019H1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_19H1)
    }
    static isWindows1019H2OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_19H2)
    }
    static isWindows1020H1OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_20H1)
    }
    static isWindows11OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_21H2)
    }
    static isWindows1121H2OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_21H2)
    }
    static isWindows1122H2OrGreater()    {
        return this.isWindowsVersionOrGreater(this.HIBYTE(this._WIN32_WINNT_WIN10),this.LOBYTE(this._WIN32_WINNT_WIN10),0,this.BUILD_22H2)
    }
    static isWindowsServer()    {
        static VER_PRODUCT_TYPE:=0x0000080, VER_EQUAL:=1
        return (osvi:=this.OSVERSIONINFOEXW()
            ,osvi.wProductType:=this.VER_NT_WORKSTATION
            ,dwlConditionMask:=dllCall("Kernel32.dll\VerSetConditionMask", "UInt64",0, "UInt",VER_PRODUCT_TYPE, "UChar",VER_EQUAL, "UInt64")
            ,!dllCall("Kernel32.dll\VerifyVersionInfoW", "Ptr",osvi.ptr, "UInt",VER_PRODUCT_TYPE, "UInt64",dwlConditionMask))
    }
    static HIBYTE(w)    { ;  // #define HIBYTE(w) ((BYTE)((((DWORD_PTR)()) >> 8) & 0xff))
        return ((w>>8)&0xFF)
    }
    static LOBYTE(w)    { ;  // #define LOBYTE(w) ((BYTE)(((DWORD_PTR)()) & 0xff))
        return (w&0xFF)
    }
    static WIN          => this._win
    static BUILD        => this._build
    static WINVER               => format("0x{:04X}",(this._lpVersionInformation.dwMajorVersion<<8)|this._lpVersionInformation.dwMinorVersion)
    static OSVersionInfoSize    => this._lpVersionInformation.dwOSVersionInfoSize
    static MajorVersion         => this._lpVersionInformation.dwMajorVersion
    static MinorVersion         => this._lpVersionInformation.dwMinorVersion
    static BuildNumber          => this._lpVersionInformation.dwBuildNumber
    static PlatformId           => this._lpVersionInformation.dwPlatformId
    static CSDVersion           => this._lpVersionInformation.szCSDVersion
    static ServicePackMajor     => this._lpVersionInformation.wServicePackMajor
    static ServicePackMinor     => this._lpVersionInformation.wServicePackMinor
    static SuiteMask            => this._lpVersionInformation.wSuiteMask
    static ProductType          => this._lpVersionInformation.wProductType
    static Reserved             => this._lpVersionInformation.wReserved
    class OSVERSIONINFOEXW
    {
        members:={dwOSVersionInfoSize:{offset:0, type:"UInt"}
            ,dwMajorVersion:{offset:4, type: "UInt"}
            ,dwMinorVersion:{offset:8,type:"UInt"}
            ,dwBuildNumber:{offset:12,type:"UInt"}
            ,dwPlatformId:{offset:16,type:"UInt"}
            ,szCSDVersion:{offset:20}
            ,wServicePackMajor:{offset:276,type:"UShort"}
            ,wServicePackMinor:{offset:278,type:"UShort"}
            ,wSuiteMask:{offset:280,type:"UShort"}
            ,wProductType:{offset:282,type:"UChar"}
            ,wReserved:{offset:283,type:"UChar"}}
        __new()    {
            this.structure:=buffer(284,0), this.ptr:=this.structure.ptr
            this.dwOSVersionInfoSize:=284
            return this
        }
        __get(name, params)    {
            if (this.members.hasProp(name))
                return numGet(this.ptr, this.members.%name%.offset, this.members.%name%.type)
            return ""
        }
        __set(name, param, value)     {
            if (name!=="members")    {
                if (this.members.hasProp(name))
                    numPut(this.members.%name%.type, value, this.ptr, this.members.%name%.offset)
            }
            this.defineProp(name, {value:value})
        }
        dwOSVersionInfoSize    {
            get => numGet(this.ptr, this.members.dwOSVersionInfoSize.offset, this.members.dwOSVersionInfoSize.type)
            set => numPut(this.members.dwOSVersionInfoSize.type, value, this.ptr, this.members.dwOSVersionInfoSize.offset)
        }
        szCSDVersion     {
            get => strGet(this.ptr+this.members.szCSDVersion.offset,, "UTF-16")
            set  {
                if (127<(len:=strLen(value)))
                    value:=subStr(value,1,len:=127)
                strPut(value, this.ptr+this.aMembers.szCSDVersion.offset, len+1, "UTF-16")
            }
        }
    }
    /*
     *  OSVERSIONINFOEXW structure (winnt.h)
     * https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw
     */
}