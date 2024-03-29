Release notes:
2021-10-18 (v4.6.0)
1.Test development for CyBLE Current Test on MTK-CURRENT-MEASUREMENT-BOARD V2.0

2021-03-06 (v4.5.0)
1.Test development for CyBLE RSSI 

2020-08-06 (v4.4.0)
1.Add Feature to support Fittec MES System ver 1.0

2019-05-15 (v4.3.7)
1.Fix the exception throw out when STC test get null commandresult

2019-05-15 (v4.3.6)
1.Shopfloor Server Connection Check and Permission Check improvement

2019-05-10 (v4.3.5)
1.Speed up STC test
2.Retry STC test

2019-04-25 (v4.3.4)
1.Change the buttons of MTKPSoCProgrammerDialog to "Connect/Disconnect" and "Close" so as to allow user to disconnect the specific PSoCProgrammer when he wants to ignore the programming.
2.fix the focus problem of Select DUTInfoDataGridView.Rows[0] when all tests finished
3.fix the problem of wrongly test result and error code when ignoring 1st/final test socket

2019-04-19 (v4.3.3)
1.Initially use CyBLE_MTK_Application.Properties.Settings.Default.MTKHostSerialPort as MTKSerialPortDialog.DeviceSerialPort.PortName and try to open it during App Starting.


2019-04-04 (v4.3.2)
1.Fix the bug that ProgAllatBegin must run at DUT#1 thread
2.Fix the bug that ProgAllatEnd must run at final row of DUTDataGridView thread
3.Select DUTInfoDataGridView.Rows[0] when all tests finished

2019-04-01 (v4.3.1)
1.Change MTKRecord.Test_Code from int to string
2.More SQL DB Table name to <add key="Table Name" value="MTKTestInfo2019_R01" />

2019-03-15 (v4.3.0)
1.Extend storing data in SQL Server as below
CREATE TABLE [dbo].[MTKTestInfo2019_R01](
	[Serial_NO] [nvarchar](50) NOT NULL,
	[Model_Name] [nvarchar](50) NOT NULL,
	[Test_Mstation] [nvarchar](50) NOT NULL,
	[Test_Code] [int] NOT NULL,
	[TesterID] [nvarchar](50) NOT NULL,
	[SocketNo] [nvarchar](50) NOT NULL,
	[MFI_ID] [nvarchar](50) NULL,
	[Test_Log] [nvarchar](MAX) NULL,
	[Test_Result] [nvarchar](50) NOT NULL,
	[Remarks] [nvarchar](50) NULL,
	[Test_Date] [date] NOT NULL,
	[Test_Time] [time](7) NOT NULL,
	[Test_HourCntOfDay] [int] NOT NULL,
	[PSoCProgrammingResultAtBegin] [nvarchar](50) NULL,
    [PSoCProgrammingResultAtEnd] [nvarchar](50) NULL,
    [STCTestCycleTime][nvarchar](10) NULL,
    [CUSTOM_CMD_READ_GPIO_1][nvarchar](50) NULL,
    [CUSTOM_CMD_READ_OPEN_GPIO_2][nvarchar](50) NULL,
    [CUSTOM_CMD_READ_FW_VERSION_11][nvarchar](50) NULL,
    [TestProgramRunCycleTimeForBatch][nvarchar](10) NULL,

2019-03-08 (v4.2.5)
1.Add Timer for RunTestProgram to evaluate the cycle time for the batch of DUTs testing.
2.TestStatusLabel only show PASS when the test program ran to the final DUT and final test and finally all passed.


2019-03-08 (v4.2.4)
1.Move ConnectionString from JsonConfig to AppSettingsConfig so as to able to modify it in UI.
2.SQLServerConnectionConfigurationDialog supports the above function.

2019-02-21 (v4.2.3)
1.Add AppSettings for PSoC Programmer Address Save.
2.Add Connect() before PermissionCheck to save time for shopfloor access.

2019-03-06 (v4.2.2)
1.Add UI buttion in the CyBLEMTKMainForm to switch on/off the SQLDatabaseEnable.

2019-02-21 (v4.2.1)
1.Fix the status display in the DUTInfoDataGridView and TestProgramDataGridView when statusOnError event happened like MissingMTKHostSerialPort Error.
2.Fix the problem When remote DB is not available, the connection.open would throw exception that caused the program stop to finish the whole process.
3.Change the messagebox of Serial Com port connection unable to open with more detailed information from system.exception.


2019-02-18 (v4.2.0)
1.Add new feature of SWJ shopfloor Microsoft SQL 2017 Server Database to backup the test information and test log onto SQL server. 

2018-12-26 (v4.1.0)
1.Add new feature of SWJ shopfloor Access Database to backup the test information and test log onto server with mdb file.

2018-11-06 (v4.0.7)
1.Push to GitHub Repository of CyBLE_MTK_Development_Repository-master
2.Move AppReleaseNotes to Readme.txt
3.Truncate different model name from SN string for different factory
4.Degrade .NET Framework Platform from 4.7.1 to 4.0 so as to be compatible with old computers
5.DUTCurrentMeasureTest is mature
6.DUT Test log is good

2018-10-25 (v4.0.6)
1.change the length of Model from 8 to 9.
2.When IgnoreDUT by robot, skip to RunAllTests()

2018-08-02 (v4.0.5)
1.Improve the display on the TestProgramDataGridView status when running test.


2018-08-01 (v4.0.4)
1.Replace Permission error Messagebox with log print
2.fix the error code assignment for 9100 permission error
3.Trim (remove) all the useless characters from the robot message to get the serial numbers but return the message to robot with original format (including useful and useless characters).
	a. useless characters could be { '\n', '\r', ' ', '\0', '@', '$', '%', '^', '&', '*', '+', '-' }.

2018-07-27 (v4.0.3)
1. Add the new feature of ReopenDutSerialPortIfMissing
2. Add the new feature of ReopenMTKHostSerialPortIfMissing

2018-07-26 (v4.0.2)
1. fix the bug about the error code assignment incorrectly for ProgramAllatEnd Failure and test result wrong.
2. Add retry up to 10 times for UART Capture Dump for check information after programming

2018-07-23 (v4.0.1)
1. fix the bug about error code for delay is not ALL_PASS but test ignored which casued the final error code is 0001
2. Add RedirectTheFirstFinalRowIndexfromDUTInfoDataGridView() in the CyBLEMTKMainForm whenever click TestRunStopButton before everything test
	a.To get the first and final row form DUTInfoDataGridView
	b.Let ProgramAllatBegin and ProgramAllatEnd work correctly
	c.This added feature allows user to no need to configure actual 1st row and final row in the DUTInfoDataGridView in some scenario
3. Add a reminder Messagebox for missing test althrough Test result pass

2017-11-15 (v1.4.2):
1.Add DUTCurrentMeasureDialog
	a. Able to config settings of DUTCurrentMeasureDialog
2.Add Switch_Config_Dialog in the CyBLEMTKMainForm's menustrip --> Tool --> Devices Setup for DUTCurrentMeasure
	a. Able to config Switch Matrix's alias and try to connect
	b. Able to save the alias
2.Add DMM_Config_Dialog in the CyBLEMTKMainForm's menustrip --> Tool --> Devices Setup for DUTCurrentMeasure
	a. Able to config DMM's alias and try to connect
	b. Able to save the alias





Release version: 3.0.0.*				
1.Support tripple mode shopfloor i.e. sigma, fittec and local
	a.config SFCSInterface in the application test settings file to switch mode
	b.when local, it support test long run mode and record the test log into local.csv
2.Add new test of DUTCurrentMeasure which is using U3606A and U2751A and related wiring on fixture
3.Support bi-mode for manual and auto (robot TCP communication)
4.Support the functionality of "save test log for each day" on the method of GenerateTestResultsFileName
5.Offer pass yield chart for test data anaylsis


What's Ok but no try in actual environment
1.Support tripple mode shopfloor i.e. sigma, fittec and local
4.Support the functionality of "save test log for each day" on the method of GenerateTestResultsFileName
5.Offer pass yield chart for test data anaylsis


What's in progress
2.Add new test of DUTCurrentMeasure which is using U3606A and U2751A and related wiring on fixture
3.Support bi-mode for manual and auto (robot TCP communication)
	a.able to get message from TCP tool
	b.able to send back message to TCP tool
	c.able to auto-loop


Known issue:
 3.Support bi-mode for manual and auto (robot TCP communication)
	a.unable to set the ignored DUT according to the TCP message (flag status)
	b.hasn't compatible with manual mode (need keep original functions)



Inheritage from:
CyBLE MTK Application (manual) version v1.4.2.*

======================================================
=============	Definitions&Agreements	 =============
======================================================

TesterID Format

ComputerName(Prefix 6 chars + 1 char)	+	"_"		+	TestHeadID(e.g.fixture ID or/and POGO module ID)

Example: TesterA_01


MessageFromRobot has the following constraints
1.Single string message without any space or special char (except for separated char #)
	For example: A1B012011000317261G1GK1#A2B012011000317261G1GA0#A3B012011000317251EI0A0#A4B012011000317261G1G71#A5B012011000317261G1D61#A6B012011000317261G1G60#A7B012011000317251EHI41#A8B012011000317261G1DE1#


2.The length of DUT serial number is variable. Able to compatible with different module with different length (but same module should has same length of SN)
3.1st char of each segment indicates the tester ID
4.2nd char of each segment indicates the socket#
5.Last 2nd char of each segment indicates the dedicated socket is ok for test or ignore test result
	a.if ignore test result, please set all 1s (i.e. 111111111111111111) for the serial number (the length should be same as others or predefined)


MessageToRobot has the following constraints
1.Same length with MessageFromRobot if non SendWrongBack
2.If robot received no message exceeds timeout, it means MTK is not started due to some reasons. 
Robot just wait some time for retry. If retry failure, just set alarm to inform machine stop.
Need engineer to handle it.
3.If robot received the message of SendWrongBack (i.e.****SendWrongBack****), it means the MessageFromRobot is invalid which could voliate the above constraints.
Robot can resend the MessageFromRobot. if still get the message of SendWrongBack, just set alarm to inform machine stop. 
Need engineer to handle it.

======================================================
=============			END	     		 =============
======================================================


