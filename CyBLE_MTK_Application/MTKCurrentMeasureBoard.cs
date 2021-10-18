using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using CypressSemiconductor.ChinaManufacturingTest;

namespace CyBLE_MTK_Application
{
    public class SwitchBoard : Switch
    {
        public SerialPort SPort = null;
        private int ChannelMask = 0;
        private LogManager Log;
        public SwitchBoard(LogManager log)
        {
            Log = log;
        }

        override public bool IsDevReady
        {
            get
            {
                if (SPort != null)
                {
                    return SPort.IsOpen;
                }
                return false;
            }
        }

        public override bool Connect(string ConnectString)
        {
            return IsDevReady;
        }

        public override bool SetRelayWellA(byte RelaySetCh1, byte RelaySetCh2)
        {
            ChannelMask = (((int)RelaySetCh1 | ((int)RelaySetCh2 << 4)) & 0xFF);
            string Command = string.Format("PWR {0}", ChannelMask);
            List<string> temp = new List<string>();
            bool Result = false;
            int retry = 0;

            while (!Result && retry < 2)
            {
                HCISupport.CommandLineRet ret = HCISupport.SendCommandRecvResult(SPort, Log, this, Command, temp, MTKCurrentMeasureBoard.CMDDELAY_PWR, MTKCurrentMeasureBoard.CMDPKG_CNT_PWR);

                switch (ret)
                {
                    case HCISupport.CommandLineRet.ACK:
                        Log.PrintLog(this, string.Format("Command \"{0}\": Succ.", Command), MTKCurrentMeasureBoard.Debug_Level);
                        Result = true;
                        break;
                    default:
                        Log.PrintLog(this, string.Format("Command \"{0}\": Fail with error \"{1}\". Retry {2}", Command, ret.ToString(), retry), LogDetailLevel.LogRelevant);
                        /*
                         * Sometimes, WICED PKG cannot be sent to fw after a long time test. But firmware is running. Software reset could recover from this state.
                         */
                        HCISupport.Reset(SPort, Log, this);
                        retry++;
                        break;
                }
            }

            Thread.Sleep(PowerRelayDelay);
            return Result;
        }

        public int RelayedChannel()
        {
            int DutIndex = 0;
            for (DutIndex = 0; DutIndex < 8; DutIndex++)
            {
                if (((ChannelMask >> DutIndex) & 1) != 0)
                {
                    break;
                }
            }
            return DutIndex;
        }

        public override bool OpenAllSWChannels()
        {
            bool retVal = false;


            byte chmask = 0;
            double current = 0;

            for (int i = 0; i < CyBLE_Current_Test_OnCurBrd.SW_CH_Closed.Length; i++)
            {
                CyBLE_Current_Test_OnCurBrd.SW_CH_Closed[i] = false;

                if (CyBLE_Current_Test_OnCurBrd.SW_CH_Closed[i] == true)
                {
                    chmask |= (byte)(1 << i);
                }
            }

            string msg = "";

            if (MTKCurrentMeasureBoard.Board.SW.SetRelayWellA((byte)(chmask & 0xf), (byte)((chmask & 0xF0) >> 4)))
            {
                retVal = true;
                for (int i = 0; i < 8; i++)
                {
                    int CH = i;
                    current = MTKCurrentMeasureBoard.Board.DMM.MeasureCurrentAVG(CH);
                    //Log.PrintLog(this, string.Format("[CH {0}] {1} mA", CH, current.ToString("F02")), LogDetailLevel.LogEverything);

                    //if (current > 0.1)
                    //{
                    //    retVal = false;
                    //    break;

                    //}

                    msg += string.Format("#{0}", current.ToString("F03"));
                }

                
            }
            Log.PrintLog(this, string.Format("[OpenAllSWChannels]: {0}", msg), LogDetailLevel.LogRelevant);

            return retVal;
        }

        public override bool CloseAllSWChannels()
        {
            bool retVal = false;


            byte chmask = 0;
            double current = 0;

            for (int i = 0; i < CyBLE_Current_Test_OnCurBrd.SW_CH_Closed.Length; i++)
            {
                CyBLE_Current_Test_OnCurBrd.SW_CH_Closed[i] = true;

                if (CyBLE_Current_Test_OnCurBrd.SW_CH_Closed[i] == true)
                {
                    chmask |= (byte)(1 << i);
                }
            }

            string msg = "";

            if (MTKCurrentMeasureBoard.Board.SW.SetRelayWellA((byte)(chmask & 0xf), (byte)((chmask & 0xF0) >> 4)))
            {
                retVal = true;
                for (int i = 0; i < 8; i++)
                {
                    int CH = i;
                    current = MTKCurrentMeasureBoard.Board.DMM.MeasureCurrentAVG(CH);
                    //Log.PrintLog(this, string.Format("[CH {0}] {1} mA", CH, current.ToString("F02")), LogDetailLevel.LogEverything);

                    //if (current < 0.1 && CyBLE_MTK.DUTsTestFlag[i])
                    //{
                    //    retVal = false;
                        

                    //}

                    msg += string.Format("#{0}", current.ToString("F03"));
                }


            }

            Log.PrintLog(this, string.Format("[CloseAllSWChannels]: {0}", msg), LogDetailLevel.LogRelevant);

            return retVal;
        }


        public override string ToString()
        {
            return "#SwitchBoard" + SPort.PortName;
        }
    }

    public class MultiMeterBoard : MultiMeter
    {
        public SerialPort SPort;
        public SwitchBoard Associated_SW;

        private LogManager Log;
        public MultiMeterBoard(LogManager log)
        {
            Log = log;
        }

        override public bool IsDevReady
        {
            get
            {
                if (SPort != null)
                {
                    return SPort.IsOpen;
                }
                return false;
            }
        }

        override public bool Connect(string ConnectString)
        {
            return (IsDevReady);
        }

        override public bool IsMTKCurrentMeasureBoard()
        {
            return true;
        }

        public Current MeasureCurrent(int Channel)
        {
            Current cur = new Current();

            cur.max = cur.average = cur.min = 0;

            if (Channel > 7 || Channel < 0)
            {
                return cur;
            }

            string Command = string.Format("RDV {0}", Channel);
            List<string> temp = new List<string>();

            HCISupport.CommandLineRet ret = HCISupport.SendCommandRecvResult(SPort, Log, this, Command, temp, MTKCurrentMeasureBoard.CMDDELAY_RDV, MTKCurrentMeasureBoard.CMDPKG_CNT_RDV);

            switch (ret)
            {
                case HCISupport.CommandLineRet.ACK:
                    string[] CommandResults = temp.ToArray();
                    try
                    {
                        char[] DelimiterChars = { ' ' };
                        string[] voltages = temp[0].Split(DelimiterChars);
                        if (voltages.Length == 3)
                        {
                            cur.average = Math.Round((float)int.Parse(voltages[0]) / MTKCurrentMeasureBoard.RESISTANCE_OF_MTK_CURRENT_MEASURE, 2);
                            //For MTK Current Measure Board, min or max voltage are insignificance. To make them been misunderstood, use average instead of them.
                            /*
                            cur.min = Math.Round((float)int.Parse(voltages[1]) / MTKCurrentMeasureBoard.RESISTANCE_OF_MTK_CURRENT_MEASURE, 2);
                            cur.max = Math.Round((float)int.Parse(voltages[2]) / MTKCurrentMeasureBoard.RESISTANCE_OF_MTK_CURRENT_MEASURE, 2);
                            */
                            cur.min = cur.max = cur.average;

                            Log.PrintLog(this, string.Format("Command \"{0}\": Succ. Current = ({1}, {2}, {3}) mA", Command, cur.average, cur.min, cur.max), MTKCurrentMeasureBoard.Debug_Level);
                            return cur;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.PrintLog(this, ex.Message, LogDetailLevel.LogRelevant);
                    }

                    string result = "";
                    foreach (string s in CommandResults)
                    {
                        result += " " + s;
                    }
                    Log.PrintLog(this, string.Format("Command \"{0}\": Response format error. (\"{1}\")", Command, result), LogDetailLevel.LogRelevant);
                    break;

                default:
                    Log.PrintLog(this, string.Format("Command \"{0}\": Response error \"{1}\".", Command, ret.ToString()), LogDetailLevel.LogRelevant);
                    break;
            }
            cur.max = cur.average = cur.min = 0;
            return cur;
        }

        public double MeasureCurrentAVG(int Channel)
        {
            double cur = 0.0;


            if (Channel > 7 || Channel < 0)
            {
                return cur;
            }

            string Command = string.Format("RDV {0}", Channel);
            List<string> temp = new List<string>();

            HCISupport.CommandLineRet ret = HCISupport.SendCommandRecvResult(SPort, Log, this, Command, temp, MTKCurrentMeasureBoard.CMDDELAY_RDV, MTKCurrentMeasureBoard.CMDPKG_CNT_RDV);

            switch (ret)
            {
                case HCISupport.CommandLineRet.ACK:
                    string[] CommandResults = temp.ToArray();
                    try
                    {
                        char[] DelimiterChars = { ' ' };
                        string[] voltages = temp[0].Split(DelimiterChars);
                        if (voltages.Length == 3)
                        {
                            cur = Math.Round((float)int.Parse(voltages[0]) / MTKCurrentMeasureBoard.RESISTANCE_OF_MTK_CURRENT_MEASURE, 2);
                            //For MTK Current Measure Board, min or max voltage are insignificance. To make them been misunderstood, use average instead of them.
                            /*
                            cur.min = Math.Round((float)int.Parse(voltages[1]) / MTKCurrentMeasureBoard.RESISTANCE_OF_MTK_CURRENT_MEASURE, 2);
                            cur.max = Math.Round((float)int.Parse(voltages[2]) / MTKCurrentMeasureBoard.RESISTANCE_OF_MTK_CURRENT_MEASURE, 2);
                            */
                            

                            Log.PrintLog(this, string.Format("Command \"{0}\": Succ. AVG Current = ({1}) mA", Command, cur), MTKCurrentMeasureBoard.Debug_Level);
                            return cur;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.PrintLog(this, ex.Message, LogDetailLevel.LogRelevant);
                    }

                    string result = "";
                    foreach (string s in CommandResults)
                    {
                        result += " " + s;
                    }
                    Log.PrintLog(this, string.Format("Command \"{0}\": Response format error. (\"{1}\")", Command, result), LogDetailLevel.LogRelevant);
                    break;

                default:
                    Log.PrintLog(this, string.Format("Command \"{0}\": Response error \"{1}\".", Command, ret.ToString()), LogDetailLevel.LogRelevant);
                    break;
            }
            cur = 0;
            return cur;
        }

        override public Current MeasureChannelCurrent(int MeasureMs)
        {
            int Channel = Associated_SW.RelayedChannel();
            if (Channel > 7 || Channel < 0)
            {
                return base.MeasureChannelCurrent(MeasureMs);
            }

            return MeasureCurrent(Channel);
        }

        public override string ToString()
        {
            return "#MultiMeterBoard" + SPort.PortName;
        }
    }

    public class MTKCurrentMeasureBoard
    {
        public const LogDetailLevel Debug_Level = LogDetailLevel.LogRelevant;
        public const int CMDPKG_CNT_PWR = 1;
        public const int CMDPKG_CNT_RDV = 2;
        public const int CMDDELAY_PWR = 500;
        public const int CMDDELAY_RDV = 1000;
        public const int RESISTANCE_OF_MTK_CURRENT_MEASURE = 10;
        public SerialPort SPort = null;
        public MultiMeterBoard DMM = null;
        public SwitchBoard SW = null;
        public LogManager Log;
        

        public MTKCurrentMeasureBoard()
        {
            Log = new LogManager();
        }

        static public MTKCurrentMeasureBoard Board = new MTKCurrentMeasureBoard();

        public bool Connect(SerialPort SerialPort)
        {
            if (SPort == SerialPort)
                return true;
            
            DMM = new MultiMeterBoard(Log);
            SW = new SwitchBoard(Log);
            DMM.SPort = SerialPort;
            SW.SPort = SerialPort;
            DMM.Associated_SW = SW;
            if (DMM.Connect(SerialPort.ToString()) && SW.Connect(SerialPort.ToString()))
            {
                SPort = SerialPort;
                SW.PowerRelayDelay = 100;
                DMM.SetCurrentUnit("ms");
                return true;
            }
            
            DMM = null;
            SW = null;
            SPort = null;
            return false;
        }

        public bool Connected()
        {
            if (SPort != null)
                return SPort.IsOpen;
            return false;
        }
    }
}
