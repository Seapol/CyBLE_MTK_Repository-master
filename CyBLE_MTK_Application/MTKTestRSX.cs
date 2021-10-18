using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;


namespace CyBLE_MTK_Application
{
    public class MTKTestRSX : MTKTest
    {
        public int ChannelNumber;
        public List<int> ChannelsNumber = new List<int>();
        public int PowerLevel = CyBLE_MTK_Application.Properties.Settings.Default.TXPPowerLevel;
        public int NumOfPackets = CyBLE_MTK_Application.Properties.Settings.Default.TXPNumOfPackets;
        public string DisplayText;
        List<string> TempValues = new List<string>();
        List<string> TempParameters = new List<string>();
        Stopwatch stopwatch = new Stopwatch();
        

        public MTKTestRSX()
            : base()
        {
            Init();
        }

        public MTKTestRSX(LogManager Logger)
            : base(Logger)
        {
            Init();
        }

        public MTKTestRSX(LogManager Logger, SerialPort MTKPort, SerialPort DUTPort)
            : base(Logger, MTKPort, DUTPort)
        {
            Init();
        }

        void Init()
        {

            TestParameterCount = 1;
            this.InitializeTestResult();

        }

        public override string GetDisplayText()
        {
            
            return "Get RSSI: " + DisplayText + String.Format(" | PASS Criterion: {0} |", TestResult.PassCriterion);
        }

        public override string GetTestParameter(int TestParameterIndex)
        {
            switch (TestParameterIndex)
            {
                case 0:

                    //if (ChannelsNumber.Count > 39)
                    //{
                    //    DisplayText = "All Channels";
                    //}
                    //else if (ChannelsNumber.Count > 1)
                    //{
                    //    DisplayText = "Multi-CH @";

                    //    foreach (var item in ChannelsNumber)
                    //    {
                    //        DisplayText += (item + "/");
                    //    }
                    //    //remove the last "/"
                    //    DisplayText.Remove(DisplayText.Length - 1,1);
                    //}
                    //else
                    //{
                    //    DisplayText = "Single CH";
                    //}



                    return DisplayText;
            }
            return base.GetTestParameter(TestParameterIndex);
        }

        public override string GetTestParameterName(int TestParameterIndex)
        {
            switch (TestParameterIndex)
            {
                case 0:
                    return "ChannelNumber";
            }
            return base.GetTestParameterName(TestParameterIndex);
        }

        public override bool SetTestParameter(int TestParameterIndex, string ParameterValue)
        {
            if (ParameterValue == "")
            {
                return false;
            }
            DisplayText = ParameterValue;
            ChannelsNumber.Clear();
            switch (TestParameterIndex)
            {
                
                case 0:
                    if (ParameterValue.ToUpper().Contains("ALL"))
                    {
                        for (int i = 0; i <= 39; i++)
                        {
                            ChannelsNumber.Add(i);
                        }
                    }
                    else if (ParameterValue.ToUpper().Contains("MULTI"))
                    {
                        string temp = DisplayText.Substring(DisplayText.IndexOf('@')+1);
                        string[] channels = temp.Split('/');

                        try
                        {
                            foreach (var item in channels)
                            {
                                ChannelsNumber.Add(int.Parse(item));
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        ChannelNumber = int.Parse(ParameterValue.Substring(0,2));
                        ChannelsNumber.Clear();
                    }
                    
                    return true;
            }
            return false;
        }

        private MTKTestError RunTestBLE()
        {/*
            int PercentageComplete = 0;
            int DelayPerCommand = 20, msPerSecond = 1000;
            int TimeForEachPacket = 700;
            int TotalEstTime = ((int)((int)this.NumberOfPackets * TimeForEachPacket) / msPerSecond);
            int TimeSlice = (int)Math.Ceiling((double)TotalEstTime / 100.00);

            MTKTestError CommandRetVal;

            this.Log.PrintLog(this, GetDisplayText(), LogDetailLevel.LogRelevant);

            TestStatusUpdate(MTKTestMessageType.Information, PercentageComplete.ToString() + "%");

            string Command = "DUT 0";
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #1
            Command = "RRS";
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #1
            CommandRetVal = SearchForDUT();
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #2
            Command = "DUT 1";
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #3
            Command = "SPL " + PacketLength.ToString();
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #4
            Command = "SPT " + GetPacketType(PacketType).ToString();
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #5
            Command = "RXP " + this.ChannelNumber.ToString() + " " + this.NumberOfPackets.ToString();
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #6
            Command = "DUT 0";
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #7
            Command = "DCW " + this.NumberOfPackets.ToString();
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Delay
            for (int i = 0; i <= 100; i++)
            {
                TestStatusUpdate(MTKTestMessageType.Information, PercentageComplete.ToString() + "%");
                Thread.Sleep(TimeSlice);
                PercentageComplete++;
            }

            //  Command #8
            CommandRetVal = SearchForDUT();
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #9
            Command = "DUT 1";
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #10
            Command = "PST";
            CommandRetVal = SendCommand(MTKSerialPort, Command, 200);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }
            if (CommandResult == "")
            {
                CommandResult = "0";
            }
            TestResult.Result = CommandResult;
            this.Log.PrintLog(this, "Number of packets received: " + this.CommandResult, LogDetailLevel.LogRelevant);


            //  Command #11
            Command = "DUT 0";
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            TestStatusUpdate(MTKTestMessageType.Complete, "DONE");
            this.Log.PrintLog(this, "Result: DONE", LogDetailLevel.LogRelevant);
*/
            return MTKTestError.NoError;
        }

        private MTKTestError RunTestUART()
        {
            DataHelper dataHelper = new DataHelper(Log);

            int PercentageComplete = 0;
            int DelayPerCommand = 20;//, msPerSecond = 1000;
            //int TimeForEachPacket = 700;
            //int TotalEstTime = ((int)((int)this.NumberOfPackets * TimeForEachPacket) / msPerSecond);
            //int TimeSlice = (int)Math.Ceiling((double)TotalEstTime / 100.00);

            MTKTestError CommandRetVal;

            this.Log.PrintLog(this, GetDisplayText(), LogDetailLevel.LogRelevant);

            TestStatusUpdate(MTKTestMessageType.Information, PercentageComplete.ToString() + "%");

            //  Command #1 //From DUT
            string Command = "RRS";
            CommandRetVal = SendCommand(DUTSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            //  Command #2  //From DUT
            Command = "TXP " + ChannelNumber.ToString() + " " + PowerLevel.ToString() + " " + NumOfPackets.ToString();
            CommandRetVal = SendCommand(DUTSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            Thread.Sleep(100); //wait for DUT TXP transmit completion

            //  Command #3 //From Host
            Command = "RSX " + ChannelNumber.ToString();
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);
            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            
            //  Command #3 //From Host
            Command = "RRS";
            CommandRetVal = SendCommand(MTKSerialPort, Command, DelayPerCommand);

            this.Log.PrintLog(this, String.Format("(DUT#{0}@{1}) Get RSSI Value on CH {2}: {3}", CurrentDUT+1,DUTSerialPort.PortName, ChannelNumber.ToString(),CommandResult), LogDetailLevel.LogRelevant);

            

            if (CommandRetVal != MTKTestError.NoError)
            {
                return CommandRetVal;
            }

            string[] TempValue = new string[CommandResults.Count()];
            string[] TempParameter = new string[CommandResults.Count()];
            string bda = "";
            for (int i = 0; i < CommandResults.Count(); i++)
            {
                TempValue[i] = CommandResults[i];
                TempParameter[i] = "RSSI CH" + ChannelNumber;
                bda += TempValue[i] + " ";
                TempValues.Add(TempValue[i]);
                TempParameters.Add(TempParameter[i]);
            }
            //TestResult.Value = TempValue;
            //TestResult.Parameters = TempParameter;
            

            int CommandResultsValue = int.Parse(CommandResult.Replace("dBm",""));

            dataHelper.AcquireRSSIvalue(ChannelNumber, CommandResultsValue);

            if (CommandResultsValue < CyBLE_MTK_Application.Properties.Settings.Default.CyBLE_RSSI_LowerLimitDBM)
            {
                CommandRetVal = MTKTestError.TestFailed;
                TestStatusUpdate(MTKTestMessageType.Failure, "FAIL->" + bda);
                //TestResult.Result = "FAIL";
                //TestResultUpdate(TestResult);
                this.Log.PrintLog(this, string.Format("Result: FAIL->{0}",bda), LogDetailLevel.LogRelevant);
                return MTKTestError.TestFailed;
            }

            TestStatusUpdate(MTKTestMessageType.Success, "PASS->" + bda);



            return MTKTestError.NoError;
        }

        public override MTKTestError RunTest()
        {
            MTKTestError RetVal = MTKTestError.NoError;
            List<MTKTestError> mTKTestErrors = new List<MTKTestError>();

            mTKTestErrors.Clear();
            TempParameters.Clear();
            TempValues.Clear();

            stopwatch.Restart();

            if (this.DUTConnectionMode == DUTConnMode.BLE)
            {
                RetVal = RunTestBLE();
            }
            else if (this.DUTConnectionMode == DUTConnMode.UART)
            {
                if (ChannelsNumber.Count > 1)
                {
                    foreach (var Channel in ChannelsNumber)
                    {
                        ChannelNumber = Channel;
                        RetVal = RunTestUART();
                        mTKTestErrors.Add(RetVal);
                    }
                }
                else
                {
                    RetVal = RunTestUART();
                    mTKTestErrors.Add(RetVal);
                }

                TestResult.Value = TempValues.ToArray();
                TestResult.Parameters = TempParameters.ToArray();
            }
            else
            {
                stopwatch.Stop();
                return MTKTestError.NoConnectionModeSet;
            }

            foreach (var item in mTKTestErrors)
            {
                switch (item)
                {
                    case MTKTestError.NoError:
                        if (MTKSerialPort.IsOpen)
                        {
                            MTKTestTmplSFCSErrCode = ECCS.ERRORCODE_ALL_PASS;
                        }
                        else
                        {
                            MTKTestTmplSFCSErrCode = ECCS.ERROR_CODE_CAUSED_BY_MTK_TESTER;
                        }
                        
                        break;
                    case MTKTestError.ReceivedNAC:
                        break;
                    case MTKTestError.MissingDUT:
                        break;
                    case MTKTestError.TestFailed:
                        MTKTestTmplSFCSErrCode = ECCS.ERRORCODE_CyBLE_GetRSSI_TEST_FAIL;
                        TestStatusUpdate(MTKTestMessageType.Failure,"Fail");
                        RetVal = MTKTestError.TestFailed;
                        TestResult.Result = "FAIL";
                        TestResultUpdate(TestResult);
                        return RetVal;
                    case MTKTestError.NoConnectionModeSet:
                        break;
                    case MTKTestError.MissingDUTSerialPort:
                        break;
                    case MTKTestError.MissingMTKSerialPort:
                        break;
                    case MTKTestError.UnknownError:
                        break;
                    case MTKTestError.MissingAnritsuSerialPort:
                        break;
                    case MTKTestError.IgnoringDUT:
                        MTKTestTmplSFCSErrCode = ECCS.ERRORCODE_DUT_NOT_TEST;
                        RetVal = MTKTestError.IgnoringDUT;
                        TestResult.Result = "IGNORE";
                        TestResultUpdate(TestResult);
                        return RetVal;
                    case MTKTestError.NotAllDevicesProgrammed:
                        break;
                    case MTKTestError.ProgrammerNotConfigured:
                        break;
                    case MTKTestError.Pending:
                        break;
                    case MTKTestError.ProcessCheckFailure:
                        break;
                    default:
                        MTKTestTmplSFCSErrCode = ECCS.ERRORCODE_CUS_TEST_FAILURE_BUT_UNKNOWN;
                        RetVal = MTKTestError.TestFailed;
                        TestResult.Result = "FAIL";
                        TestResultUpdate(TestResult);
                        return RetVal;
                        
                }


            }

            
            

            
            stopwatch.Stop();
            this.Log.PrintLog(this, string.Format("Perform {0}: {1} secs", DisplayText, stopwatch.Elapsed.TotalMilliseconds / 1000), LogDetailLevel.LogRelevant);
            TestResultUpdate(TestResult);
            return RetVal;
        }

        protected override void InitializeTestResult()
        {
            base.InitializeTestResult();
            TestResult.PassCriterion = string.Format("RSSI value > {0} dBm", CyBLE_MTK_Application.Properties.Settings.Default.CyBLE_RSSI_LowerLimitDBM);
            TestResult.Measured = "N/A";
            CurrentMTKTestType = MTKTestType.MTKTestRSX;

        }
    }
}
