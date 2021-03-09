using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CyBLE_MTK_Application
{
    public partial class MTKTestRSXDialog : Form
    {
        MTKTestRSX GetRSSI;

        public MTKTestRSXDialog()
        {
            InitializeComponent();
            this.ChannelNumber.SelectedIndex = 0;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            GetRSSI.DisplayText = this.ChannelNumber.SelectedItem.ToString();
            GetRSSI.ChannelsNumber.Clear();
            if (this.ChannelNumber.SelectedIndex > 39)
            {
                if (this.ChannelNumber.SelectedItem.ToString().ToUpper().Contains("ALL"))
                {
                    

                    for (int i = 0; i <= 39; i++)
                    {
                        GetRSSI.ChannelsNumber.Add(i);
                    }
                }
                else
                {

                    string temp = this.ChannelNumber.SelectedItem.ToString().Substring(this.ChannelNumber.SelectedItem.ToString().IndexOf('@')+1);

                    string[] channels = temp.Split('/');

                    try
                    {
                        foreach (var item in channels)
                        {
                            GetRSSI.ChannelsNumber.Add(int.Parse(item));
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    
                }
            }
            else
            {
                GetRSSI.ChannelsNumber.Clear();
                GetRSSI.ChannelNumber = this.ChannelNumber.SelectedIndex;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public MTKTestRSXDialog(MTKTestRSX RSSITest)
            : this()
        {
            GetRSSI = RSSITest;
        }
    }
}
