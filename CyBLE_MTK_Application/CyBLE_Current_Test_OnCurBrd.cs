using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyBLE_MTK_Application
{
    public partial class CyBLE_Current_Test_OnCurBrd : Form
    {

        public static bool[] SW_CH_Closed = new bool[8]
        {
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true
        };

        public CyBLE_Current_Test_OnCurBrd()
        {
            InitializeComponent();
        }

        private void btn_closeAll_Click(object sender, EventArgs e)
        {
            
        }

        private void CyBLE_Current_Test_OnCurBrd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataDataSet.CurrentTest' table. You can move, or remove it, as needed.
            this.currentTestTableAdapter.Fill(this.dataDataSet.CurrentTest);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.currentTestTableAdapter.FillBy(this.dataDataSet.CurrentTest);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
