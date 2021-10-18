using System;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

namespace CyBLE_MTK_Application
{
    public class HCISupport
    {
        public const byte HCI_UART_PREFIX_COMMAND = 0x01;
        public const byte HCI_UART_PREFIX_ACL_DATA_PKG = 0x02;
        public const byte HCI_UART_PREFIX_SYNC_DATA_PKG = 0x03;
        public const byte HCI_UART_PREFIX_EVENT = 0x04;
        public const byte HCI_UART_PREFIX_WICED_PKG = 0x19;
        public const byte HCI_CONTROL_GROUP_MISC = 0xFF;
        public const byte HCI_CONTROL_COMMAND_CODE_STRLINE = 0x03;
        public const byte HCI_CONTROL_EVENT_CODE_STRLINE = 0x03;

        public const UInt16 HCI_CONTROL_MISC_COMMAND_STRLINE = ((HCI_CONTROL_GROUP_MISC << 8) | HCI_CONTROL_COMMAND_CODE_STRLINE);
        public const UInt16 HCI_CONTROL_MISC_EVENT_STRLINE = ((HCI_CONTROL_GROUP_MISC << 8) | HCI_CONTROL_EVENT_CODE_STRLINE);

        public static string FormatString(byte[] Buf, int Count = -1)
        {
            string s = string.Empty;
            int i = 0;
            if (Count < 0)
            {
                Count = Buf.Length;
            }

            foreach (byte b in Buf)
            {
                if (i >= Count)
                    break;
                s += b.ToString("X02");
                s += " ";
                i++;
            }
            s = s.TrimEnd(' ');

            return s;
        }

        /*
        *   Command and event Templates for transmit test through HCI UART .
        */

        //7.3.2 Reset Command. OpCode = 0x0C03. OGF = 0x03, 0CF = 0x03
        static public byte[] TmplResetCmd = new byte[] { 0x01, 0x03, 0x0c, 0x00 };
        static public byte[] TmplResetCmdCmplEvt = new byte[] { 0x04, 0x0e, 0x04, 0x01, 0x03, 0x0c, 0x00 };

        private const int DefaultReadPkgPrefixTimeout = 20;
        private const int DefaultReadPkgBodyTimeout = 500;  //Wait more time since prefix byte is read.
        private const int DefaultReadExistingTimeout = 50;  //Read existing raw data timeout value.

        public const int DefaultDelayPerCmdLine = 20; //Delay ms after writing.

        static public bool Reset(SerialPort SPort, LogManager Log, object Sender, int retryCount = 0)
        {
            int retry = 0;

            while (retry <= retryCount)
            {
                try
                {
                    if (Log != null)
                        Log.PrintLog(Sender, "Write HCI Cmd (" + SPort.PortName + "): " + HCISupport.FormatString(HCISupport.TmplResetCmd, HCISupport.TmplResetCmd.Length),
                            LogDetailLevel.LogEverything);
                    lock (SPort)
                    {
                        SPort.DiscardInBuffer();
                        SPort.DiscardOutBuffer();
                        SPort.Write(HCISupport.TmplResetCmd, 0, HCISupport.TmplResetCmd.Length);
                    }
                    Thread.Sleep(300);

                    do
                    {
                        /*
                         * When debug 483062, the following test steps always caused HCI-UART returns dozens of messy bytes 
                         * before a correct HCI-RESET-RESPONSE package at the tail.
                         *  1. Power on all DUT with CTS high.
                         *  2. App start
                         *  3. Hard-reset DUT with CTS low.
                         *  4. HCI mode start
                         *  5. Soft-reset DUT --- This issue occured at regular intervals: OK->Error->OK->Error....
                         * 
                         * So adding code to search and return a real package from all return bytes to fix this issue.
                         */
                        byte[] ReadBuf = ReadAPacketUntilTimeout(SPort, Log, Sender, 0x4, 1000, true);

                        if (ReadBuf == null || ReadBuf.Length == 0)
                        {
                            Log.PrintLog(Sender, "Reset (" + SPort.PortName + ") Timeout!", LogDetailLevel.LogRelevant);
                            break;
                        }

                        /*
                         * Should return HCI_EVENT_CMD_CMPL package with 
                         *  Num_HCI_Command_Packets == 1 (WICED_CHIP)
                         *  Num_HCI_Command_Packets == 4 (PSoC 6)
                         */
                        if (
                            (ReadBuf.Length == HCISupport.TmplResetCmdCmplEvt.Length) &&
                            (ReadBuf[1] == 0x0E) && (ReadBuf[2] == 0x04) && //EventCode = 0x0E Size == 0x04
                            (ReadBuf[4] == 0x03) && (ReadBuf[5] == 0x0C) && //OpCode == 0x0C03
                            (ReadBuf[6] == 0x00) //Status == 0x00
                            )
                        {
                            Log.PrintLog(Sender, "Soft-Reset Succ " + SPort.PortName, LogDetailLevel.LogRelevant);
                            return true;
                        }
                    } while (true);
                }
                catch
                {
                }

                retry++;
            }

            Log.PrintLog(Sender, "Soft-Reset Fail " + SPort.PortName, LogDetailLevel.LogRelevant);
            return false;
        }

        static public bool SendCommand(SerialPort SPort, LogManager Log, object Sender, string Command, out List<string> CommandResults, int WaitTimeMS, int MaxPkgCnt = 0xFF)
        {
            CommandResults = new List<string>();
            try
            {
                if (SendCommandRecvResult(SPort, Log, Sender, Command, CommandResults, WaitTimeMS, MaxPkgCnt) == CommandLineRet.ACK)
                {
                    
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        static public int WhoCnt = 0;
        static public bool Who(SerialPort SPort, LogManager Log, object Sender, out List<string> CmdResults)
        {
            string cmd = "WHO";
            //Log.PrintLog(Sender, "WHO_Command[" + WhoCnt.ToString() + "]", LogDetailLevel.LogRelevant);
            WhoCnt++;
            /* 
             * If watch-dog-reset MTKHost, command may be blocked and then sent to MTKHost by Windows autometically. 
             * So wait more time for firmware ready is a good idea.
             */
            return SendCommand(SPort, Log, Sender, cmd, out CmdResults, 1000, 2);
        }

        public enum CommandLineRet { PortErr, NoResp, ACK, NAC, RespFmtErr };
        static public CommandLineRet SendCommandRecvResult(SerialPort SPort, LogManager Log, object Sender, string Command, List<string> CommandResults, int WaitTimeMS, int MaxPkgCnt = 0xFF)
        {
            char[] DelimiterChars = { '\n', '\r' };

            try
            {
                SPort.DiscardInBuffer();
                SPort.DiscardOutBuffer();

                Log.PrintLog(Sender, "Command (" + SPort.PortName + "): " + Command, LogDetailLevel.LogEverything);
                

                WriteCmdLine(SPort, Command, Log, Sender, 0);

                string OuputACKNAC = ReadExistingString(SPort, Log, Sender, WaitTimeMS, MaxPkgCnt);

                if (OuputACKNAC == null)
                {
                    Log.PrintLog(Sender, "No response to Command: " + Command, LogDetailLevel.LogRelevant);
                    return CommandLineRet.NoResp;
                }
                else if (OuputACKNAC.Length == 0)
                {
                    Log.PrintLog(Sender, "Empty response to Command: " + Command, LogDetailLevel.LogEverything);
                    return CommandLineRet.NoResp;
                }

                string[] Output = OuputACKNAC.Split(DelimiterChars);

                for (int i = 0; i < Output.Count(); i++)
                {
                    /*
                     * 06/13/2017
                     *  Firmware released before today returns "NAK" instead of "NAC". "NAK" is a spelling error.
                     *  So WICED MTK treats "NAK" as "NAC".
                     */
                    if ((Output[i] != "") && (Output[i] != "ACK") && (Output[i] != "NAC") && (Output[i] != "NAK"))
                    {
                        CommandResults.Add(Output[i]);
                    }
                }

                if (Output[0] == "ACK")
                {
                    return CommandLineRet.ACK;
                }
                else if (Output[0] == "NAC" || Output[0] == "NAK")
                {
                    Log.PrintLog(Sender, "Received \"NAC\" to command: " + Command, LogDetailLevel.LogRelevant);
                    return CommandLineRet.NAC;
                }
                else
                {
                    Log.PrintLog(Sender, "No \"ACK\" or \"NAC\" to command: " + Command + " But returns:" + OuputACKNAC, LogDetailLevel.LogRelevant);
                    return CommandLineRet.RespFmtErr;
                }
            }
            catch
            {
                Log.PrintLog(Sender, "Received \"NAC\" to command: " + Command, LogDetailLevel.LogRelevant);
                return CommandLineRet.PortErr;
            }
        }

        static public bool WriteCmdLine(SerialPort SPort, string Command, LogManager Log, object Sender, int WaitTimeMS = DefaultDelayPerCmdLine)
        {
            char[] chars = Command.ToCharArray();
            byte[] payload = new byte[chars.Length + 2];
            int i = 0;
            //Convert to ansi bytes
            foreach (char c in chars)
            {
                payload[i] = (byte)c;
                i++;
            }

            payload[i] = 0xA; //'\n'
            payload[i + 1] = 0;

            return WriteWicedPkg(SPort, HCI_CONTROL_MISC_COMMAND_STRLINE, payload, 0, (UInt16)payload.Length, Log, Sender, WaitTimeMS);
        }

        private static char[] StringEvtTrimChars = new char[] { '\r', ' ', '\0' };

        /*
         * MaxPkgCnt is to specify the count of WICED packets used to wrap string returned from fw.
         * Because of the limitation of command line comunication protocol between app and fw, there is no signature 
         * to indicate no more msg. So a fixed "WaitMs" at least must wait before return.
         * So, to accerate executing, this routinue can also return on received MaxPkgCnt WICED packets. But pkg count must
         * be synchronized with fw developer. It is not a good solution, only to reduce time on current released OSRAM firmware. 
         */
        static public string ReadExistingString(SerialPort SPort, LogManager Log, object Sender, int WaitMs = 100, int MaxPkgCnt = 0xFF)
        {
            string result = "";

            while (true)
            {
                byte[] evt = ReadAPacketUntilTimeout(SPort, Log, Sender, HCI_UART_PREFIX_WICED_PKG, WaitMs);

                if (evt == null)
                {
                    //Error happened
                    return null;
                }
                else if (evt.Length >= 5)
                {
                    int i;
                    UInt16 code = BitConverter.ToUInt16(evt, 1);
                    string strEvt = "";

                    for (i = 5; i < evt.Length; i++)
                    {
                        if (evt[i] == 0)
                            break;
                        char c = (char)evt[i];
                        strEvt += c.ToString();
                    }
                    if (code == HCI_CONTROL_MISC_COMMAND_STRLINE)
                    {
                        MaxPkgCnt--;
                        result += strEvt.Trim(StringEvtTrimChars);
                        if (MaxPkgCnt == 0)
                        {
                            Log.PrintLog(Sender, "ReturnStrOnPkgCnt: " + (result.Replace('\n', ' ')).Replace('\r', ' '), LogDetailLevel.LogEverything);
                            return result;
                        }
                    }
                    else if (Log != null)
                    {
                        Log.PrintLog(Sender, "WTrace: " + strEvt, LogDetailLevel.LogEverything);
                    }
                }
                else
                {
                    Log.PrintLog(Sender, "ReturnStr: " + (result.Replace('\n', ' ')).Replace('\r', ' '), LogDetailLevel.LogEverything);
                    return result;
                }
            }
        }

        static public byte[] ReadAPacketUntilTimeout(SerialPort SPort, LogManager Log, object Sender, UInt32 PkgPrefix, int WaitingMilliseconds, bool PickPkgFromStuff = false)
        {
            DateTime start = DateTime.Now;
            int remainTime = WaitingMilliseconds;

            do
            {
                byte[] evt = ReadPkg(SPort, Log, Sender, remainTime < DefaultReadPkgPrefixTimeout ? remainTime : DefaultReadPkgPrefixTimeout, PickPkgFromStuff ? PkgPrefix : 0);

                if (evt == null)
                {
                    return null;
                }

                if ((evt.Length > 0 && evt[0] == PkgPrefix) || PkgPrefix == 0)
                {
                    return evt;
                }

                remainTime = WaitingMilliseconds - (int)(DateTime.Now.Subtract(start).TotalMilliseconds);

            } while (remainTime > 0);

            if (Log != null && Log.LogDetails >= LogDetailLevel.LogEverything)
            {
                remainTime = WaitingMilliseconds - remainTime;

                string timestr = remainTime.ToString() + " (" + WaitingMilliseconds.ToString() + ") ms";

                if (PkgPrefix == HCI_UART_PREFIX_EVENT)
                    Log.PrintLog(Sender, "No HCI Event in " + timestr, LogDetailLevel.LogRelevant);
                else if (PkgPrefix == HCI_UART_PREFIX_WICED_PKG)
                    Log.PrintLog(Sender, "No WICED Pkg in " + timestr, LogDetailLevel.LogRelevant);
                else
                    Log.PrintLog(Sender, "No RAW Pkg in " + timestr, LogDetailLevel.LogRelevant);
            }
            return new byte[0];
        }

        static public bool WriteWicedPkg(SerialPort SPort, UInt16 Cmd, byte[] Payload, int Offset, UInt16 Len, LogManager Log, object Sender, int WaitTimeMS)
        {
            int header = 0;

            if (Len == 0 && Payload != null)
            {
                Len = (UInt16)(Payload.Length - Offset);
            }

            byte[] data = new byte[Len + 5];

            data[header++] = HCI_UART_PREFIX_WICED_PKG;
            data[header++] = (byte)(Cmd & 0xff);
            data[header++] = (byte)((Cmd >> 8) & 0xff);
            data[header++] = (byte)(Len & 0xff);
            data[header++] = (byte)((Len >> 8) & 0xff);

            if (Len > 0)
            {
                System.Buffer.BlockCopy(Payload, Offset, data, header, Len);
            }

            try
            {
                lock (SPort)
                {
                    SPort.DiscardOutBuffer();
                    if (Log != null)
                        Log.PrintLog(Sender, "Write WICED PKG (" + SPort.PortName + "): " + HCISupport.FormatString(data, data.Length),
                            LogDetailLevel.LogEverything);
                    SPort.Write(data, 0, data.Length);
                }
                if (WaitTimeMS > 0)
                    Thread.Sleep(WaitTimeMS);
            }
            catch (Exception ex)
            {
                if (Log != null)
                    Log.PrintLog(Sender, "Exception on Writing UART " + ex.ToString(), LogDetailLevel.LogRelevant);

                throw ex;
            }

            return true;
        }

        /*
        * 0 <= return < count: Timeout
        * Through exception of SerialPort.Read();
        */
        static private int ReadBytesUntilTimeout(SerialPort SPort, LogManager Log, object Sender, byte[] buffer, int offset, int count, int WaitingMilliseconds)
        {
            DateTime start = DateTime.Now;
            int read = 0;
            int remainTime = WaitingMilliseconds;
            int readTimeoutSaved = SPort.ReadTimeout;
            if (buffer.Length < offset + count)
            {
                lock (SPort)
                {
                    SPort.DiscardInBuffer();
                }
                return 0;
            }
            do
            {
                try
                {
                    lock (SPort)
                    {
                        SPort.ReadTimeout = remainTime;
                        read += SPort.Read(buffer, read + offset, count - read);
                    }
                }
                catch (System.TimeoutException)
                {
                    SPort.ReadTimeout = readTimeoutSaved;
                }
                catch (Exception ex)
                {
                    SPort.ReadTimeout = readTimeoutSaved;
                    if (Log != null)
                        Log.PrintLog(Sender, "Exception on reading UART (" + SPort.PortName + ", " + WaitingMilliseconds.ToString() + " ms) : " + ex.ToString(), LogDetailLevel.LogRelevant);

                    throw ex;
                }

                if (read >= count)
                {
                    return count;
                }

                remainTime = (WaitingMilliseconds - (int)(DateTime.Now.Subtract(start).TotalMilliseconds));

            } while (remainTime > 0);

            /*
            remainTime = WaitingMilliseconds - remainTime;

            if (Log != null)
                Log.PrintLog(Sender, "Timeout! Read " + count.ToString() + " bytes in " + WaitingMilliseconds.ToString() + " ms. (But"
                    + read.ToString() + " bytes, " + remainTime.ToString() + " ms)", LogDetailLevel.LogEverything);
            */
            return read;
        }
        /*
        *Read bytes by prefix byte.
        * Paramters:
        *   ReadPrefixByteTimeout: Milliseconds wait for the first byte
        *   TheLastPkgPrefix: Try to find the last packet starts with "TheLastPkgPrefix" from over-read bytes.
        * Return:
        *   byte[0]: Timeout, No entire event was read.
        *   null: Serial Port Error
        */
        static private byte[] ReadPkg(SerialPort SPort, LogManager Log, object Sender, int ReadPrefixByteTimeout, UInt32 TheLastPkgPrefix)
        {
            int read = 0;
            byte[] eventBuf = new byte[1024];
            int totalSize = -1; //Read existing by default
            int errCode = 1;
            bool searchPkg = false;
            try
            {
                //Read the first byte which represents the package type.
                read = ReadBytesUntilTimeout(SPort, Log, Sender, eventBuf, read, 1, ReadPrefixByteTimeout);
                if (read == 1)
                {
                    errCode = 2;
                    switch (eventBuf[0])
                    {
#if false
                        case HCI_UART_PREFIX_VS_EVENT:
                            read += ReadBytesUntilTimeout(SPort, Log, Sender, eventBuf, read, 1, HCISupport.DefaultReadPkgBodyTimeout);
                            if (read == 2)
                            {
                                totalSize = eventBuf[1] + read;
                                errCode = 0;
                            }
                            break;
#endif
                        case HCI_UART_PREFIX_EVENT:
                            read += ReadBytesUntilTimeout(SPort, Log, Sender, eventBuf, read, 2, HCISupport.DefaultReadPkgBodyTimeout);
                            if (read == 3)
                            {
                                totalSize = eventBuf[2] + read;
                                errCode = 0;
                            }
                            break;

                        case HCI_UART_PREFIX_WICED_PKG:
                            read += ReadBytesUntilTimeout(SPort, Log, Sender, eventBuf, read, 4, HCISupport.DefaultReadPkgBodyTimeout);
                            if (read == 5)
                            {
                                totalSize = BitConverter.ToInt16(eventBuf, 3) + read;
                                errCode = 0;
                            }
                            break;

                        default:
                            totalSize = -1; //read existing
                            errCode = 0;
                            break;
                    }
                }
                else
                {
                    return new byte[0];
                }

                //Read existing
                if (totalSize == -1)
                {
                    read += ReadBytesUntilTimeout(SPort, Log, Sender, eventBuf, read, eventBuf.Length - read, HCISupport.DefaultReadExistingTimeout);
                    totalSize = read;
                    searchPkg = (TheLastPkgPrefix == HCI_UART_PREFIX_EVENT || TheLastPkgPrefix == HCI_UART_PREFIX_WICED_PKG);
                }
                else if (totalSize > read)
                {
                    //Have to read all remaining bytes until timeout.
                    read += ReadBytesUntilTimeout(SPort, Log, Sender, eventBuf, read, totalSize - read, HCISupport.DefaultReadPkgBodyTimeout);
                }
            }
            catch
            {
                return null;
            }

            if (read == totalSize)
            {
                errCode = 0;
            }

            if (errCode != 0)
            {
                //Drop an error package
                if (Log != null && ReadPrefixByteTimeout > 0)
                    Log.PrintLog(Sender, "Error! Discard an unkown pkg from UART (" + SPort.PortName + " ErrCode = " + errCode.ToString() + "): " + HCISupport.FormatString(eventBuf, read), LogDetailLevel.LogRelevant);
                totalSize = 0;
                return null;
            }
            else if (Log != null)
            {
                Log.PrintLog(Sender, "Read a Pkg (" + SPort.PortName + "): " + HCISupport.FormatString(eventBuf, read) + "...", LogDetailLevel.LogEverything);
            }

            if (searchPkg)
            {
                int pkgLen = 0;
                int pkgStart = 0;
                /* Search and return a packet */
                for (; pkgStart < read - 1; pkgStart++)
                {
                    if (eventBuf[pkgStart] == HCI_UART_PREFIX_EVENT)
                    {
                        if ((pkgStart + 2) < read)
                        {
                            pkgLen = eventBuf[pkgStart + 2] + 3;
                            if (pkgLen == (read - pkgStart)) //Only catch the event at the tail
                            {
                                break;
                            }
#if false
                            else
                            {
                                Log.PrintLog(Sender, "EVENT_NOT_AT_TAIL: " + HCISupport.FormatString(eventBuf, read), LogDetailLevel.LogRelevant);
                            }
#endif
                        }
                    }
                    else if (eventBuf[pkgStart] == HCI_UART_PREFIX_WICED_PKG)
                    {
                        if ((pkgStart + 5) < read)
                        {
                            pkgLen = BitConverter.ToInt16(eventBuf, pkgStart + 3) + 5;
                            if (pkgLen == (read - pkgStart)) //Only catch the event at the tail
                            {
                                break;
                            }
#if false
                            else
                            {
                                Log.PrintLog(Sender, "EVENT_NOT_AT_TAIL: " + HCISupport.FormatString(eventBuf, read), LogDetailLevel.LogRelevant);
                            }
#endif
                        }
                    }
                    pkgLen = 0;
                }

                if (pkgLen > 0)
                {
                    read = pkgLen;
                    totalSize = read;
                    byte[] tmp = new byte[pkgLen];
                    System.Buffer.BlockCopy(eventBuf, pkgStart, tmp, 0, pkgLen);
                    eventBuf = tmp;
                    Log.PrintLog(Sender, "Found a pkg at " + pkgStart + "th byte: " + HCISupport.FormatString(eventBuf,
#if true
                            read)
#else
                            read > 16 ? 16 : read) + "..."
#endif
                        , LogDetailLevel.LogRelevant);
                    return eventBuf;
                }
            }

            if (read != eventBuf.Length)
            {
                byte[] tmp = new byte[read];
                if (read > 0)
                    System.Buffer.BlockCopy(eventBuf, 0, tmp, 0, read);
                eventBuf = tmp;
            }

            return eventBuf;
        }

        public const int DefaultDelayPerHCICommand = 20;
        public const int DefaultHCICmdRspTimeout = 500;
      
    }
}
