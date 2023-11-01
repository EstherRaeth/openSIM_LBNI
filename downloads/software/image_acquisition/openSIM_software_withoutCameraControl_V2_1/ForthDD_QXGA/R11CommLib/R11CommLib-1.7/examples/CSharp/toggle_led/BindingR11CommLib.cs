using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

using ForthDD.Comm.Binding;
using System.Diagnostics;

namespace ForthDD.R11.Binding
{
    class R11CommLib
    {
#if WIN64 // Defined in Project Properties for x64 Platform only (Build -> Conditional compilation symbols).
        const string LIB_LOCATION = "R11CommLib-1.7-x64.dll";
#else
        const string LIB_LOCATION = "R11CommLib-1.7-x86.dll";
#endif

        /* ----------------------------------------------------------------
         * If dll and C# versions have same parameter list, they can't have 
         * same name as well. The function name, as exported by the dll, is
         * assumed to be the same as the function name used in C#, unless
         * specified otherwise, using the 'EntryPoint' option.
         * ----------------------------------------------------------------*/

        /* ----------------------------------------------------------------
         * CommLib functions
         * ----------------------------------------------------------------*/

        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_LibGetVersion(IntPtr verStr, byte maxLen);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_ExcGetMsg(IntPtr msg);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_DevEnumerateComPorts(IntPtr devList, IntPtr devCount);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_DevEnumerateWinUSB(IntPtr guid, IntPtr devList, IntPtr devCount);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_DevOpenComPort(IntPtr portName, UInt16 timeout, UInt32 baudRate, bool doResync);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_DevOpenWinUSB(IntPtr devPath, UInt16 timeout);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "FDD_DevSetTimeout")]
        static extern FDD_RESULT FDD_DevSetTimeout_dll(UInt16 timeout);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_DevGetTimeout(IntPtr timeout);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_FlashRead(IntPtr buffer, UInt16 offset, UInt16 length);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT FDD_FlashWrite(IntPtr buffer, UInt16 offset, UInt16 length);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "FDD_DevClose")]
        static extern FDD_RESULT FDD_DevClose_dll();

        /* ----------------------------------------------------------------
         * R11CommLib functions
         * ----------------------------------------------------------------*/

        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_LibGetVersion(IntPtr verStr, byte maxLen);                                                          // 3.1
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetBoardType(IntPtr boardType);                                                               // 3.2
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcSysReboot")]
        static extern FDD_RESULT R11_RpcSysReboot_dll();                                                                                 // 3.3
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetStoredChecksum(UInt16 bpIndex, IntPtr bpChecksum);                                         // 3.4
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetCalculatedChecksum(UInt16 bpIndex, IntPtr bpChecksum);                                     // 3.5
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetBitplaneCount(IntPtr bpCount);                                                             // 3.6
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcSysReloadRepertoire")]
        static extern FDD_RESULT R11_RpcSysReloadRepertoire_dll();                                                                       // 3.7
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetRepertoireName(IntPtr repName, byte maxLen);                                               // 3.8
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcSysSaveSettings")]
        static extern FDD_RESULT R11_RpcSysSaveSettings_dll();                                                                           // 3.9
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetDaughterboardType(IntPtr dbType);                                                          // 3.10
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetADC(byte adcChannel, IntPtr adcValue);                                                     // 3.11
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetBoardID(IntPtr boardId);                                                                   // 3.12
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetDisplayType(IntPtr dispType);                                                              // 3.13
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcSysGetSerialNum(IntPtr serialNum);                                                               // 3.14
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcMicroGetCodeTimestamp(IntPtr timestamp, byte maxLen);                                            // 3.15
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcMicroGetCodeVersion(IntPtr version);                                                             // 3.16
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcFlashEraseBlock")]
        static extern FDD_RESULT R11_RpcFlashEraseBlock_dll(UInt32 page);                                                                // 3.17
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcRoGetCount(IntPtr roCount);                                                                      // 3.18
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcRoGetSelected(IntPtr roIndex);                                                                   // 3.19
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcRoGetDefault(IntPtr roIndex);                                                                    // 3.20
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcRoSetSelected")]
        static extern FDD_RESULT R11_RpcRoSetSelected_dll(UInt16 roIndex);                                                               // 3.21
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcRoSetDefault")]
        static extern FDD_RESULT R11_RpcRoSetDefault_dll(UInt16 roIndex);                                                                // 3.22
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcRoGetActivationType(IntPtr actType);                                                             // 3.23
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcRoGetActivationState(IntPtr actState);
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcRoActivate")]
        static extern FDD_RESULT R11_RpcRoActivate_dll();                                                                                // 3.24
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcRoDeactivate")]
        static extern FDD_RESULT R11_RpcRoDeactivate_dll();                                                                              // 3.25
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcRoGetName(UInt16 roIndex, IntPtr roName, byte maxLen);                                           // 3.26
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcLedSet")]
        static extern FDD_RESULT R11_RpcLedSet_dll(byte value);                                                                          // 3.27
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcLedGet")]
        static extern FDD_RESULT R11_RpcLedGet_dll(IntPtr value);                                                                        // 3.28
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcFlipTpSet")]
        static extern FDD_RESULT R11_RpcFlipTpSet_dll(byte value);                                                                       // 3.29
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcFlipTpGet")]
        static extern FDD_RESULT R11_RpcFlipTpGet_dll(IntPtr value);                                                                     // 3.30
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_RpcMaintLedSet")]
        static extern FDD_RESULT R11_RpcMaintLedSet_dll(bool ledEnable);                                                                 // 3.31
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_RpcMaintLedGet(IntPtr ledEnable);                                                                   // 3.32
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_DevGetProgress(IntPtr pro);                                                                         // 3.33
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_FlashRead(IntPtr buffer, UInt16 offset, UInt16 length);                                             // 3.34
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi)]
        static extern FDD_RESULT R11_FlashWrite(IntPtr buffer, UInt16 offset, UInt16 length);                                            // 3.35
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_FlashBurn")]
        static extern FDD_RESULT R11_FlashBurn_dll(UInt32 page);                                                                         // 3.36
        [DllImport(LIB_LOCATION, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "R11_FlashGrab")]
        static extern FDD_RESULT R11_FlashGrab_dll(UInt32 page);                                                                         // 3.37

        /* ----------------------------------------------------------------
         * CommLib/R11CommLib structures and consts
         * ----------------------------------------------------------------*/

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct Dev
        {
            public IntPtr id;
            public IntPtr next;
        }

        const Int16 MAX_LEN = 128;
        const string R11_WINUSB_GUID = "54ED7AC9-CC23-4165-BE32-79016BAFB950";

        /* ----------------------------------------------------------------
         * Exception handling
         * ----------------------------------------------------------------*/

        static void throwException(string functionName, Object result)
        {
            String message = string.Format("{0} failed. Error={1}", functionName, result);
            throw new System.InvalidOperationException(message);
        }

        static void checkResult(FDD_RESULT result)
        {
            if (result != FDD_RESULT.FDD_SUCCESS)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                throwException(sf.GetMethod().Name, result);
            }
        }

        /* ----------------------------------------------------------------
         * Support code
         * ----------------------------------------------------------------*/

        class Pinner : IDisposable
        {
            GCHandle pinnedArray;
            protected Object obj;

            public Pinner(Object obj)
            {
                this.obj = obj;
                pinnedArray = GCHandle.Alloc(obj, GCHandleType.Pinned);
            }
            public static implicit operator IntPtr(Pinner ap)
            {
                return ap.pinnedArray.AddrOfPinnedObject();
            }
            public void Dispose()
            {
                pinnedArray.Free();
            }
        }

        class GenericPinner<T> : Pinner where T : new()
        {
            public GenericPinner(Object obj) : base(obj) { }
            public GenericPinner() : base(newObject()) { }

            private static Object newObject()
            {
                T t = new T();
                Object tempObj = t;
                return tempObj;
            }

            public static implicit operator T(GenericPinner<T> ap)
            {
                return (T)ap.obj;
            }
        }

        /* ================================================================
         * Wrappers for CommLib functions
         * ================================================================*/

        public static String FDD_LibGetVersion()                                // 5.1
        {
            byte[] buffer = new byte[MAX_LEN];
            String str = "";

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = FDD_LibGetVersion(bufferP, (byte)MAX_LEN);
                checkResult(r);
                str = Marshal.PtrToStringAnsi(bufferP);
            }

            return str;
        }

        public static String FDD_ExcGetMsg()                                    // 5.2
        {
            byte[] buffer = new byte[MAX_LEN];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = FDD_ExcGetMsg(bufferP);
                checkResult(r);
                String str = Marshal.PtrToStringAnsi(bufferP);
                return str;
            }
        }

        public static List<String> FDD_DevEnumerateComPorts()                   // 5.3
        {
            var portIDList = new List<String>();

            IntPtr[] devPP = new IntPtr[1];     // In C, devPP is a Dev**
            UInt16[] devCountP = new UInt16[1];

            using (Pinner devAP = new Pinner(devPP))
            using (Pinner devCountAP = new Pinner(devCountP))
            {
                FDD_RESULT r = FDD_DevEnumerateComPorts(devAP, devCountAP);
                checkResult(r);

                UInt16 devCount = devCountP[0];
                IntPtr devP = devPP[0];     // In C, devP is a Dev*

                for (int i = 0; i < devCount; i++)
                {
                    Dev dev = (Dev)Marshal.PtrToStructure(devP, typeof(Dev));
                    string portID = Marshal.PtrToStringAnsi(dev.id);
                    portIDList.Add(portID);
                    devP = dev.next;
                }
            }

            return portIDList;
        }

        public static List<String> FDD_DevEnumerateWinUSB()                     // 5.5
        {
            var portIDList = new List<String>();

            IntPtr[] devPP = new IntPtr[1];     // In C, devPP is a Dev**
            UInt16[] devCountP = new UInt16[1];
            byte[] bGuid = Encoding.ASCII.GetBytes(R11_WINUSB_GUID);

            using (Pinner devAP = new Pinner(devPP))
            using (Pinner devCountAP = new Pinner(devCountP))
            using (Pinner bGuidAP = new Pinner(bGuid))
            {
                FDD_RESULT r = FDD_DevEnumerateWinUSB(bGuidAP, devAP, devCountAP);
                checkResult(r);

                UInt16 devCount = devCountP[0];
                IntPtr devP = devPP[0];         // In C, devP is a Dev*

                for (int i = 0; i < devCount; i++)
                {
                    Dev dev = (Dev)Marshal.PtrToStructure(devP, typeof(Dev));
                    string portID = Marshal.PtrToStringAnsi(dev.id);
                    portIDList.Add(portID);
                    devP = dev.next;
                }
            }

            return portIDList;
        }

        public static void FDD_DevOpenComPort(string portName, 
            UInt16 timeout, UInt32 baudRate, bool doResync)                     // 5.6
        {
            byte[] bPortName = Encoding.ASCII.GetBytes(portName);

            using (Pinner bpnPinner = new Pinner(bPortName))
            {
                FDD_RESULT r = FDD_DevOpenComPort(bpnPinner, timeout, baudRate, doResync);
                checkResult(r);
            }
        }

        public static void FDD_DevOpenWinUSB(string devPath, UInt16 timeout)    // 5.8
        {
            byte[] bDevPath = Encoding.ASCII.GetBytes(devPath);

            using (Pinner bdpPinner = new Pinner(bDevPath))
            {
                FDD_RESULT r = FDD_DevOpenWinUSB(bdpPinner, timeout);
                checkResult(r);
            }
        }

        public static void FDD_DevSetTimeout(UInt16 timeout)                    // 5.9
        {
            FDD_RESULT r = FDD_DevSetTimeout_dll(timeout);
            checkResult(r);
        }

        public static UInt16 FDD_DevGetTimeout()                                // 5.10
        {
            using (GenericPinner<UInt16> timeout = new GenericPinner<UInt16>())
            {
                FDD_RESULT r = FDD_DevGetTimeout(timeout);
                checkResult(r);
                return timeout;
            }
        }

        public static void FDD_DevClose()                                       // 5.11
        {
            FDD_RESULT r = (FDD_RESULT)FDD_DevClose_dll();
            checkResult(r);
        }

        public static byte[] FDD_FlashRead(UInt16 offset, UInt16 length)        // 5.12
        {
            byte[] buffer = new byte[length];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = FDD_FlashRead(bufferP, offset, length);
                checkResult(r);
                return buffer;
            }
        }

        public static void FDD_FlashWrite(byte[] buffer, UInt16 offset)         // 5.13
        {
            int length = buffer.Length;

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = FDD_FlashWrite(bufferP, offset, (UInt16)length);
                checkResult(r);
            }
        }

        /* ================================================================
         * Wrappers for R11CommLib functions
         * ================================================================*/

        public static String R11_LibGetVersion()                                 // 3.1
        {
            byte[] buffer = new byte[MAX_LEN];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = R11_LibGetVersion(bufferP, (byte)MAX_LEN);
                checkResult(r);
                String str = Marshal.PtrToStringAnsi(bufferP);
                return str;
            }
        }

        public static byte R11_RpcSysGetBoardType()                              // 3.2
        {
            byte[] type = new byte[1];

            using (Pinner typeP = new Pinner(type))
            {
                FDD_RESULT r = R11_RpcSysGetBoardType(typeP);
                checkResult(r);
            }
            return type[0];
        }

        public static void R11_RpcSysReboot()                                    // 3.3
        {
            FDD_RESULT r = R11_RpcSysReboot_dll();
            checkResult(r);
        }

        public static UInt32 R11_RpcSysGetStoredChecksum(UInt16 bpIndex)         // 3.4
        {
            using (GenericPinner<UInt32> checksum = new GenericPinner<UInt32>())
            {
                FDD_RESULT r = R11_RpcSysGetStoredChecksum(bpIndex, checksum);
                checkResult(r);
                return checksum;
            }
        }

        public static UInt32 R11_RpcSysGetCalculatedChecksum(UInt16 bpIndex)     // 3.5
        {
            using (GenericPinner<UInt32> checksum = new GenericPinner<UInt32>())
            {
                FDD_RESULT r = R11_RpcSysGetCalculatedChecksum(bpIndex, checksum);
                checkResult(r);
                return checksum;
            }
        }

        public static UInt32 R11_RpcSysGetBitplaneCount()                        // 3.6
        {
            using (GenericPinner<UInt32> bpCount = new GenericPinner<UInt32>())
            {
                FDD_RESULT r = R11_RpcSysGetBitplaneCount(bpCount);
                checkResult(r);
                return bpCount;
            }
        }

        public static void R11_RpcSysReloadRepertoire()                          // 3.7
        {
            FDD_RESULT r = R11_RpcSysReloadRepertoire_dll();
            checkResult(r);
        }

        public static String R11_RpcSysGetRepertoireName()                       // 3.8
        {
            byte[] buffer = new byte[MAX_LEN];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = R11_RpcSysGetRepertoireName(bufferP, (byte)MAX_LEN);
                checkResult(r);
                String str = Marshal.PtrToStringAnsi(bufferP);
                return str;
            }
        }

        public static void R11_RpcSysSaveSettings()                              // 3.9
        {
            FDD_RESULT r = R11_RpcSysSaveSettings_dll();
            checkResult(r);
        }

        public static byte R11_RpcSysGetDaughterboardType()                      // 3.10
        {
            using (GenericPinner<byte> dbType = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcSysGetDaughterboardType(dbType);
                checkResult(r);
                return dbType;
            }
        }

        public static UInt16 R11_RpcSysGetADC(byte adcChannel)                   // 3.11
        {
            using (GenericPinner<UInt16> adcValue = new GenericPinner<UInt16>())
            {
                FDD_RESULT r = R11_RpcSysGetADC(adcChannel, adcValue);
                checkResult(r);
                return adcValue;
            }
        }

        public static byte R11_RpcSysGetBoardID()                                // 3.12
        {
            using (GenericPinner<byte> boardId = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcSysGetBoardID(boardId);
                checkResult(r);
                return boardId;
            }
        }

        public static byte R11_RpcSysGetDisplayType()                            // 3.13
        {
            using (GenericPinner<byte> dispType = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcSysGetDisplayType(dispType);
                checkResult(r);
                return dispType;
            }
        }

        public static UInt32 R11_RpcSysGetSerialNum()                            // 3.14
        {
            using (GenericPinner<UInt32> sn = new GenericPinner<UInt32>())
            {
                FDD_RESULT r = R11_RpcSysGetSerialNum(sn);
                checkResult(r);
                return sn;
            }
        }

        public static String R11_RpcMicroGetCodeTimestamp()                      // 3.15
        {
            byte[] buffer = new byte[MAX_LEN];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = R11_RpcMicroGetCodeTimestamp(bufferP, (byte)MAX_LEN);
                checkResult(r);
                String str = Marshal.PtrToStringAnsi(bufferP);
                return str;
            }
        }

        public static UInt16[] R11_RpcMicroGetCodeVersion()                      // 3.16
        {
            UInt16[] buffer = new UInt16[4];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = R11_RpcMicroGetCodeVersion(bufferP);
                checkResult(r);
                return buffer;
            }
        }

        public static void R11_RpcFlashEraseBlock(UInt32 page)                   // 3.17
        {
            FDD_RESULT r = R11_RpcFlashEraseBlock_dll(page);
            checkResult(r);
        }

        public static UInt16 R11_RpcRoGetCount()                                 // 3.18
        {
            using (GenericPinner<UInt16> roCount = new GenericPinner<UInt16>())
            {
                FDD_RESULT r = R11_RpcRoGetCount(roCount);
                checkResult(r);
                return roCount;
            }
        }

        public static UInt16 R11_RpcRoGetSelected()                              // 3.19
        {
            using (GenericPinner<UInt16> roIndex = new GenericPinner<UInt16>())
            {
                FDD_RESULT r = R11_RpcRoGetSelected(roIndex);
                checkResult(r);
                return roIndex;
            }
        }

        public static UInt16 R11_RpcRoGetDefault()                               // 3.20
        {
            using (GenericPinner<UInt16> roIndex = new GenericPinner<UInt16>())
            {
                FDD_RESULT r = R11_RpcRoGetDefault(roIndex);
                checkResult(r);
                return roIndex;
            }
        }

        public static void R11_RpcRoSetSelected(UInt16 roIndex)                  // 3.21
        {
            FDD_RESULT r = R11_RpcRoSetSelected_dll(roIndex);
            checkResult(r);
        }

        public static void R11_RpcRoSetDefault(UInt16 roIndex)                   // 3.22
        {
            FDD_RESULT r = R11_RpcRoSetDefault_dll(roIndex);
            checkResult(r);
        }

        public static byte R11_RpcRoGetActivationType()                          // 3.23
        {
            using (GenericPinner<byte> actType = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcRoGetActivationType(actType);
                checkResult(r);
                return actType;
            }
        }

        public static byte R11_RpcRoGetActivationState()
        {
            using (GenericPinner<byte> actState = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcRoGetActivationState(actState);
                checkResult(r);
                return actState;
            }
        }

        public static void R11_RpcRoActivate()                                   // 3.24
        {
            FDD_RESULT r = R11_RpcRoActivate_dll();
            checkResult(r);
        }

        public static void R11_RpcRoDeactivate()                                 // 3.25
        {
            FDD_RESULT r = R11_RpcRoDeactivate_dll();
            checkResult(r);
        }

        public static String R11_RpcRoGetName(UInt16 roIndex)                    // 3.26
        {
            byte[] buffer = new byte[MAX_LEN];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = R11_RpcRoGetName(roIndex, bufferP, (byte)MAX_LEN);
                checkResult(r);
                String str = Marshal.PtrToStringAnsi(bufferP);
                return str;
            }
        }
        
        public static void R11_RpcLedSet(byte value)                             // 3.27
        {
            FDD_RESULT r = R11_RpcLedSet_dll(value);
            checkResult(r);
        }

        public static byte R11_RpcLedGet()                                       // 3.28
        {
            using (GenericPinner<byte> value = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcLedGet_dll(value);
                checkResult(r);
                return value;
            }
        }

        public static void R11_RpcFlipTpSet(byte value)                          // 3.29
        {
            FDD_RESULT r = R11_RpcFlipTpSet_dll(value);
            checkResult(r);
        }

        public static byte R11_RpcFlipTpGet()                                    // 3.30
        {
            using (GenericPinner<byte> value = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcFlipTpGet_dll(value);
                checkResult(r);
                return value;
            }
        }

        public static void R11_RpcMaintLedSet(bool value)                        // 3.31
        {
            FDD_RESULT r = R11_RpcMaintLedSet_dll(value);
            checkResult(r);
        }

        public static bool R11_RpcMaintLedGet()                                  // 3.32
        {
            using (GenericPinner<byte> value = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_RpcMaintLedGet(value);
                checkResult(r);

                switch(value)
                {
                    case 0:     return false;
                    case 1:     return true;
                    default:    throwException(new StackTrace().GetFrame(0).GetMethod().Name, "Invalid board response"); return false;
                }
            }
        }

        public static byte R11_DevGetProgress()                                  // 3.33
        {
            using (GenericPinner<byte> progress = new GenericPinner<byte>())
            {
                FDD_RESULT r = R11_DevGetProgress(progress);
                checkResult(r);
                return progress;
            }
        }

        public static byte[] R11_FlashRead(UInt16 offset, UInt16 length)         // 3.34
        {
            byte[] buffer = new byte[length];

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = R11_FlashRead(bufferP, offset, length);
                checkResult(r);
                return buffer;
            }
        }

        public static void R11_FlashWrite(byte[] buffer, UInt16 offset)          // 3.35
        {
            int length = buffer.Length;

            using (Pinner bufferP = new Pinner(buffer))
            {
                FDD_RESULT r = R11_FlashWrite(bufferP, offset, (UInt16)length);
                checkResult(r);
            }
        }

        public static void R11_FlashBurn(UInt32 page)                            // 3.36
        {
            FDD_RESULT r = R11_FlashBurn_dll(page);
            checkResult(r);
        }

        public static void R11_FlashGrab(UInt32 page)                            // 3.37
        {
            FDD_RESULT r = R11_FlashGrab_dll(page);
            checkResult(r);
        }
    }
}
