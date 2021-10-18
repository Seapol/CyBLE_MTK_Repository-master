using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CyBLE_MTK_Application
{
    public class DataHelper
    {
        DataTable dataTableRSSI = new DataTable();
        DataTable dataTableRSSILimits = new DataTable();
        DataTable dataTableCurrent = new DataTable();
        DataTable dataTableCurrentLimits = new DataTable();
        LogManager Log = new LogManager();


        public DataHelper(LogManager log)
        {
            Log = log;

            InitdataTable();
        }

        private void InitdataTable()
        {
            dataDataSet dataSet = new dataDataSet();

            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                if (dataSet.Tables[i].TableName == "CurrentTest")
                {
                    dataTableCurrent = dataSet.Tables[i].Clone();
                }
                else if (dataSet.Tables[i].TableName == "CurrentTestLimits")
                {
                    dataTableCurrentLimits = dataSet.Tables[i].Clone();
                }
                else if (dataSet.Tables[i].TableName == "RSSITest")
                {
                    dataTableRSSI = dataSet.Tables[i].Clone();
                }
                else if (dataSet.Tables[i].TableName == "RSSITestLowLimits")
                {
                    dataTableRSSILimits = dataSet.Tables[i].Clone();
                }
            }

            
        }

        public void AcquireRSSIvalue(int CH, int measuredValue)
        {

        }
    }
}
