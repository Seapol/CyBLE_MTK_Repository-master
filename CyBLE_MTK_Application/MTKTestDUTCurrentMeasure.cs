using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using CypressSemiconductor.ChinaManufacturingTest;



namespace CyBLE_MTK_Application
{
    public class MTKTestDUTCurrentMeasure : MTKTest
    {

        private SerialPort MTKSerialPort;
        private SerialPort DUTSerialPort;
        private SerialPort CurtBrdSerialPort;

        EnumPassConOverall conOverall;


        public struct Current
        {
            public double max;
            public double min;
            public double average;
        }

        /// <summary>
        /// Test Parameters
        /// 
        /// </summary>
        /// 

        public double DUTCurrentUpperLimitMilliAmp = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentUpperLimitMilliAmp;
        public double DUTCurrentLowerLimitMilliAmp = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentLowerLimitMilliAmp;
        public double DUTCurrentDeepSleepLimitMilliAmp = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentDeepSleepLimitMilliAmp;

        public string Dmm_Alias = CyBLE_MTK_Application.Properties.Settings.Default.DMM_Alias;
        public string Switch_Alias = CyBLE_MTK_Application.Properties.Settings.Default.Switch_Alias;
        public int DelayBeforeTest = CyBLE_MTK_Application.Properties.Settings.Default.DelayInMSBeforeDUTCurrentMeasure;
        public int DelayAfterTest = CyBLE_MTK_Application.Properties.Settings.Default.DelayInMSBeforeDUTCurrentMeasure;
        public int SamplesCount = CyBLE_MTK_Application.Properties.Settings.Default.SamplesCountForDUTCurrentMeasure;
        public string overallpass_condition = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentMeasureOverallPassCondition;
        public string criterion_per_sample = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentMeasureCriteriaPerSample;

        public int IntervalInMS = CyBLE_MTK_Application.Properties.Settings.Default.IntervalBetweenDUTCurrentMeasure;
        public string curr_unit = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentMeasureUnit;



        //private const UInt16 ERRORCODE_DUTCurrentUpperLimitMilliAmp_Failure = 0xA5FF;
        //private const UInt16 ERRORCODE_DUTCurrentLowerLimitMilliAmp_Failure = 0xA500;
        //private const UInt16 ERRORCODE_DUTCurrentDeepSleepLimitMilliAmp_Failure = 0xA511;

        public static UInt16 ERRORCODE_DUTCurrentMeasureFailure = ECCS.ERRORCODE_DUT_NOT_TEST;

        private string sample_failure_result_message;

        public MTKTestDUTCurrentMeasure() : base()
        {
            Init();
        }

        public MTKTestDUTCurrentMeasure(LogManager Logger)
            : base(Logger)
        {
            Init();
        }

      public MTKTestDUTCurrentMeasure(LogManager Logger, SerialPort MTKPort, SerialPort CurtBrdPort, SerialPort DUTPort)
        : base(Logger, MTKPort, CurtBrdPort, DUTPort)
        {
            MTKSerialPort = MTKPort;
            CurtBrdSerialPort = CurtBrdPort;
            DUTSerialPort = DUTPort;
            Init();
            
        }

        



        private void Init()
        {
            NumberOfDUTs = 8;
            CurrentDUT = 0;
            TestParameterCount = 8;

            if (CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentDeepSleepLimitMilliAmp <= 0)
            {
                DUTCurrentDeepSleepLimitMilliAmp = 0.1;
            }
            else
            {
                DUTCurrentDeepSleepLimitMilliAmp = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentDeepSleepLimitMilliAmp;
            }
            if (CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentLowerLimitMilliAmp <= 0)
            {
                DUTCurrentLowerLimitMilliAmp = 7.0;
            }
            else
            {
                DUTCurrentLowerLimitMilliAmp = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentLowerLimitMilliAmp;
            }
            if (CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentUpperLimitMilliAmp <= 0)
            {
                DUTCurrentUpperLimitMilliAmp = 20.0;
            }
            else
            {
                DUTCurrentUpperLimitMilliAmp = CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentUpperLimitMilliAmp;
            }

            InitializeTestResult();

        }

        public override string GetDisplayText()
        {
            return "MTKTestDUTCurrentMeasure: | Range: " + DUTCurrentLowerLimitMilliAmp + " mA" + "~" + DUTCurrentUpperLimitMilliAmp + " mA | " +
                "Delay: {" + DelayBeforeTest + " ms | " +  DelayAfterTest + " ms} | " +
                "Count of Sampling: " + SamplesCount + " | Sample Interval: " + IntervalInMS + " ms | " + 
                "Pass Conditons: {" + criterion_per_sample +  " | " + overallpass_condition +"}";


        }

        public override string GetTestParameter(int TestParameterIndex)
        {
            switch (TestParameterIndex)
            {
                case 0:
                    return DUTCurrentUpperLimitMilliAmp.ToString();
                case 1:
                    return DUTCurrentLowerLimitMilliAmp.ToString();
                case 2:
                    return DelayBeforeTest.ToString();
                case 3:
                    return DelayAfterTest.ToString();
                case 4:
                    return SamplesCount.ToString();
                case 5:
                    return IntervalInMS.ToString();
                case 6:
                    return criterion_per_sample.ToString();
                case 7:
                    return overallpass_condition.ToString();
            }
            return base.GetTestParameter(TestParameterIndex);
        }

        public override string GetTestParameterName(int TestParameterIndex)
        {
            switch (TestParameterIndex)
            {
                case 0:
                    return "DUTCurrentUpperLimitMilliAmp";
                case 1:
                    return "DUTCurrentLowerLimitMilliAmp";
                case 2:
                    return "DelayBeforeTest";
                case 3:
                    return "DelayAfterTest";
                case 4:
                    return "SamplesCount";
                case 5:
                    return "IntervalInMS";
                case 6:
                    return "criterion_per_sample";
                case 7:
                    return "overallpass_condition";
            }
            return base.GetTestParameterName(TestParameterIndex);
        }

        public override bool SetTestParameter(int TestParameterIndex, string ParameterValue)
        {
            if (ParameterValue == "")
            {
                return false;
            }
            switch (TestParameterIndex)
            {
                case 0:
                    DUTCurrentUpperLimitMilliAmp = double.Parse(ParameterValue);
                    return true;
                case 1:
                    DUTCurrentLowerLimitMilliAmp = double.Parse(ParameterValue);
                    return true;
                case 2:
                    DelayBeforeTest = int.Parse(ParameterValue);
                    return true;
                case 3:
                    DelayAfterTest = int.Parse(ParameterValue);
                    return true;
                case 4:
                    SamplesCount = int.Parse(ParameterValue);
                    return true;
                case 5:
                    IntervalInMS = int.Parse(ParameterValue);
                    return true;
                case 6:
                    criterion_per_sample = ParameterValue;
                    return true;
                case 7:
                    overallpass_condition = ParameterValue;
                    return true;
            }
            return false;
        }





        private MTKTestError RunTestBLE()
        {
            //TO DO something...

            
            return MTKTestError.NoError;
        }


        double current_meas = 0;

        private MTKTestError RunTestUART()
        {
            //TO DO something...
            MTKTestError RetVal = MTKTestError.Pending;

            try
            {
                int CH = (CurrentDUT - 1);

                

                SerialPort SPort = new SerialPort();
                SPort = CurtBrdSerialPort;

                current_meas = 0;

                if (CyBLE_MTK_Application.Properties.Settings.Default.CurrentTestMethod.Contains("MTKCurrentBoard"))
                {
                    try
                    {
                        if (SPort.IsOpen)
                        {
                            SPort.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        Log.PrintLog(this, ex.Message, LogDetailLevel.LogRelevant);
                    }
                    

                    Connect2CurtBrd(SPort);

                    byte chmask = 0;

                    switch (conOverall)
                    {
                        case EnumPassConOverall.ONE_SAMPLE:
                            for (int i = 0; i < SamplesCount; i++)
                            {
                                current_meas = PerformCH_CurrentTest(CyBLE_Current_Test_OnCurBrd.SW_CH_Closed[CurrentDUT]);
                                if (current_meas >= DUTCurrentLowerLimitMilliAmp && current_meas <= DUTCurrentUpperLimitMilliAmp)
                                {
                                    //Pass
                                    break;
                                }

                            }
                            break;
                        case EnumPassConOverall.ALL_SAMPLES:
                            for (int i = 0; i < SamplesCount; i++)
                            {
                                current_meas = PerformCH_CurrentTest(CyBLE_Current_Test_OnCurBrd.SW_CH_Closed[CurrentDUT]);
                                if (current_meas <= DUTCurrentLowerLimitMilliAmp && current_meas >= DUTCurrentUpperLimitMilliAmp)
                                {
                                    //Fail
                                    break;
                                }

                            }
                            break;
                        default:
                            break;
                    }

                    

                    

                    

                }
                else if (CyBLE_MTK_Application.Properties.Settings.Default.CurrentTestMethod.Contains("MTKCurrentBoard"))
                {
                    MTKInstruments.DUTCurrent = MTKInstruments.MeasureChannelCurrent(CurrentDUT);
                }
                else
                {
                    Log.PrintLog(this, "[Warning]: No Available CurrentTestMethod selected!!!", LogDetailLevel.LogRelevant);
                    RetVal = MTKTestError.TestFailed;
                    TestResult.Result = "FAIL";
                    TestResultUpdate(TestResult);
                    TestStatusUpdate(MTKTestMessageType.Failure, "Fail");
                }
                



                return RetVal;

            }
            catch 
            {
                RetVal = MTKTestError.TestFailed;
                TestResult.Result = "FAIL";
                TestResultUpdate(TestResult);
                return RetVal;
            }
            finally
            {
                //Recover all duts' power on after testing.
                if (!MTKInstruments.SwitchAllDutOn())
                {
                    this.Log.PrintLog(this, "Fail to recover power after current test.", LogDetailLevel.LogEverything);
                }

            }




        }

        private double PerformCH_CurrentTest(bool CHstatus)
        {
            byte chmask = 0;
            double current = 0;

            for (int i = 0; i < CyBLE_Current_Test_OnCurBrd.SW_CH_Closed.Length; i++)
            {
                if (CyBLE_Current_Test_OnCurBrd.SW_CH_Closed[i] == true)
                {
                    chmask |= (byte)(1 << i);
                }
            }



            if (MTKCurrentMeasureBoard.Board.SW.SetRelayWellA((byte)(chmask & 0xf), (byte)((chmask & 0xF0) >> 4)))
            {
                //for (int i = 0; i < 8; i++)
                //{
                //    int CH = i;
                //    current = MTKCurrentMeasureBoard.Board.DMM.MeasureCurrentAVG(CH);
                //    Log.PrintLog(this, string.Format("[CH {0}] {1} mA", CH, current.ToString("F02")), LogDetailLevel.LogEverything);
                //}

                current = MTKCurrentMeasureBoard.Board.DMM.MeasureCurrentAVG(CurrentDUT - 1);
                //Log.PrintLog(this, string.Format("[CH {0}] {1} mA", CurrentDUT - 1, current.ToString("F02")), LogDetailLevel.LogRelevant);
            }

            return current;
        }

        private bool Connect2CurtBrd(SerialPort SPort)
        {

            bool retVal = false;

            if (SPort.IsOpen)
            {
                SPort.Close();
            }


            if (MTKCurrentMeasureBoard.Board.Connected())
            {
                MTKCurrentMeasureBoard.Board.SPort.Close();
            }

            SPort.Handshake = Handshake.RequestToSend;
            SPort.BaudRate = 115200;
            SPort.WriteTimeout = 1000;
            SPort.ReadTimeout = 1000;


            try
            {
                SPort.Open();
                List<string> Rets;
                if (HCISupport.Who(SPort, Log, this, out Rets))
                {
                    if (Rets[0] == "HOST" &&
                        Rets[1] == "819")
                    {
                        MTKCurrentMeasureBoard.Board.Connect(SPort);
                        retVal = true;
                    }
                }
                else
                {
                    SPort.Close();
                    MessageBox.Show(SPort.PortName + " - is not MTK-CURRENT-MEASURE-BOARD.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show(SPort.PortName + " - is in use.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private bool DoesSamplePass(double meas)
        {
            sample_failure_result_message = "Fail";

            

            
            if (meas > DUTCurrentLowerLimitMilliAmp)
            {
                if (meas < DUTCurrentUpperLimitMilliAmp)
                {
                    //Pass
                    ERRORCODE_DUTCurrentMeasureFailure = ECCS.ERRORCODE_ALL_PASS;
                    TestResult.Measured += string.Format("#{0}mA", meas.ToString("F02"));
                    return true;
                }
                else
                {
                    //Fail
                    ERRORCODE_DUTCurrentMeasureFailure = ECCS.ERROR_CODE_DMM_HIGH;
                    sample_failure_result_message += string.Format("#{0}mA", meas.ToString("F02"));
                    TestResult.Measured += string.Format("#{0}mA", meas.ToString("F02"));
                    TestStatusUpdate(MTKTestMessageType.Failure, sample_failure_result_message);
                }

            }
            else
            {
                //Fail
                ERRORCODE_DUTCurrentMeasureFailure = ECCS.ERROR_CODE_DMM_LOW;
                sample_failure_result_message += string.Format("#{0}mA", meas.ToString("F02"));
                TestResult.Measured += string.Format("#{0}mA", meas.ToString("F02"));
                TestStatusUpdate(MTKTestMessageType.Failure, sample_failure_result_message);
            }


            MTKTestTmplSFCSErrCode = ERRORCODE_DUTCurrentMeasureFailure;

            return false;
        }

        public override MTKTestError RunTest()
        {
            MTKTestError RetVal = MTKTestError.NoError;

            this.InitializeTestResult();

            TestResult.Measured = " Result: ";

            if (this.DUTConnectionMode == DUTConnMode.BLE)
            {
                RetVal = RunTestBLE();
            }
            else if (this.DUTConnectionMode == DUTConnMode.UART)
            {
                int loop = SamplesCount;

                

                if (overallpass_condition.ToUpper() == EnumPassConOverall.ONE_SAMPLE.ToString())
                {
                    while (loop > 0)
                    {
                        RetVal = RunTestUART();
                        loop--;
                        if (DoesSamplePass(current_meas) && RetVal == MTKTestError.Pending)
                        {
                            RetVal = MTKTestError.NoError;
                            break;
                        }
                        
                    }
                }
                else
                {
                    
                    while (loop > 0)
                    {
                        RetVal = RunTestUART();

                        if (RetVal != MTKTestError.Pending)
                        {
                            RetVal = MTKTestError.TestFailed;
                            break;
                        }

                        loop--;
                        if (!DoesSamplePass(current_meas))
                        {
                            RetVal = MTKTestError.TestFailed;
                            break;
                        }
                        else
                        {
                            TestStatusUpdate(MTKTestMessageType.Success, "Pass: " + (SamplesCount-loop).ToString() + "/" + SamplesCount.ToString());
                            RetVal = MTKTestError.NoError;
                            continue;
                        }
                        
                    }
                }

                TestResultUpdate(TestResult);

                //Overall TestResult
                if (RetVal == MTKTestError.NoError)
                {
                    ERRORCODE_DUTCurrentMeasureFailure = ECCS.ERRORCODE_ALL_PASS;
                    TestStatusUpdate(MTKTestMessageType.Success, "Pass");
                    TestResult.Result = "Pass";
                    
                }
                else
                {
                    TestStatusUpdate(MTKTestMessageType.Failure, "Fail");
                    TestResult.Result = "FAIL";                   
                }

                Log.PrintLog(this, TestResult.Result + " : " + TestResult.Measured, LogDetailLevel.LogRelevant);
                MTKTestTmplSFCSErrCode = ERRORCODE_DUTCurrentMeasureFailure;
            }
            else
            {
                TestStatusUpdate(MTKTestMessageType.Failure, "NoConnectionModeSet");
                return MTKTestError.NoConnectionModeSet;
            }

            TestResultUpdate(TestResult);

            return RetVal;
        }

        protected override void InitializeTestResult()
        {
            base.InitializeTestResult();
            TestResult.PassCriterion = "Limit: " +  + Math.Round(DUTCurrentLowerLimitMilliAmp,3) + "~" + Math.Round(DUTCurrentUpperLimitMilliAmp, 3) + " mA" +"||" + criterion_per_sample +"||"+ overallpass_condition;
            TestResult.Measured = "N/A";
            ERRORCODE_DUTCurrentMeasureFailure = ECCS.ERRORCODE_ALL_PASS;
            sample_failure_result_message = "";

            CurrentMTKTestType = MTKTestType.MTKTestDUTCurrentMeasure;


            

            if (CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentMeasureOverallPassCondition.ToUpper().Contains("ALL"))
            {
                conOverall = EnumPassConOverall.ALL_SAMPLES;
            }
            else if (CyBLE_MTK_Application.Properties.Settings.Default.DUTCurrentMeasureOverallPassCondition.ToUpper().Contains("ONE"))
            {
                conOverall = EnumPassConOverall.ONE_SAMPLE;
            }
            else
            {
                conOverall = EnumPassConOverall.ALL_SAMPLES;
            }


            


        }


    }

    public enum EnumPassConPerSample
    {
        AVERAGE = 0,    //Check average value
        MAX_AND_MIN = 1 //Check Max and Min average
    };

    //public struct Current
    //{
    //    public double average;
    //    public double max;
    //    public double min;

    //    public CurrentUnit unit;


    //}
}
