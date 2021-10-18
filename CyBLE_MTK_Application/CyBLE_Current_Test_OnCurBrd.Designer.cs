namespace CyBLE_MTK_Application
{
    partial class CyBLE_Current_Test_OnCurBrd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CurtBrdserialPort = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CH_SEL_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.btn_openAll = new System.Windows.Forms.Button();
            this.btn_closeAll = new System.Windows.Forms.Button();
            this.SaveExitBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.currentTestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataDataSet = new CyBLE_MTK_Application.dataDataSet();
            this.currentTestTableAdapter = new CyBLE_MTK_Application.dataDataSetTableAdapters.CurrentTestTableAdapter();
            this.dateTimeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cH8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CurtBrdserialPort
            // 
            this.CurtBrdserialPort.BaudRate = 115200;
            this.CurtBrdserialPort.PortName = "COM4";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 665);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1181, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 20);
            this.toolStripStatusLabel1.Text = "CurtBrdSerialPort:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 20);
            this.toolStripStatusLabel2.Text = "COM4";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1181, 665);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.CH_SEL_checkedListBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.SaveExitBtn);
            this.splitContainer2.Panel2.Controls.Add(this.btn_openAll);
            this.splitContainer2.Panel2.Controls.Add(this.btn_closeAll);
            this.splitContainer2.Size = new System.Drawing.Size(191, 665);
            this.splitContainer2.SplitterDistance = 304;
            this.splitContainer2.TabIndex = 1;
            // 
            // CH_SEL_checkedListBox
            // 
            this.CH_SEL_checkedListBox.CheckOnClick = true;
            this.CH_SEL_checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CH_SEL_checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CH_SEL_checkedListBox.FormattingEnabled = true;
            this.CH_SEL_checkedListBox.Items.AddRange(new object[] {
            "CH1",
            "CH2",
            "CH3",
            "CH4",
            "CH5",
            "CH6",
            "CH7",
            "CH8"});
            this.CH_SEL_checkedListBox.Location = new System.Drawing.Point(0, 0);
            this.CH_SEL_checkedListBox.Name = "CH_SEL_checkedListBox";
            this.CH_SEL_checkedListBox.Size = new System.Drawing.Size(191, 304);
            this.CH_SEL_checkedListBox.TabIndex = 0;
            // 
            // btn_openAll
            // 
            this.btn_openAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_openAll.Location = new System.Drawing.Point(21, 101);
            this.btn_openAll.Name = "btn_openAll";
            this.btn_openAll.Size = new System.Drawing.Size(150, 35);
            this.btn_openAll.TabIndex = 1;
            this.btn_openAll.Text = "OPEN All CHs";
            this.btn_openAll.UseVisualStyleBackColor = true;
            // 
            // btn_closeAll
            // 
            this.btn_closeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_closeAll.Location = new System.Drawing.Point(21, 26);
            this.btn_closeAll.Name = "btn_closeAll";
            this.btn_closeAll.Size = new System.Drawing.Size(150, 35);
            this.btn_closeAll.TabIndex = 0;
            this.btn_closeAll.Text = "CLOSE All CHs";
            this.btn_closeAll.UseVisualStyleBackColor = true;
            this.btn_closeAll.Click += new System.EventHandler(this.btn_closeAll_Click);
            // 
            // SaveExitBtn
            // 
            this.SaveExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveExitBtn.Location = new System.Drawing.Point(21, 176);
            this.SaveExitBtn.Name = "SaveExitBtn";
            this.SaveExitBtn.Size = new System.Drawing.Size(150, 35);
            this.SaveExitBtn.TabIndex = 2;
            this.SaveExitBtn.Text = "Save && Exit";
            this.SaveExitBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateTimeStampDataGridViewTextBoxColumn,
            this.cH1DataGridViewTextBoxColumn,
            this.cH2DataGridViewTextBoxColumn,
            this.cH3DataGridViewTextBoxColumn,
            this.cH4DataGridViewTextBoxColumn,
            this.cH5DataGridViewTextBoxColumn,
            this.cH6DataGridViewTextBoxColumn,
            this.cH7DataGridViewTextBoxColumn,
            this.cH8DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.currentTestBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(986, 665);
            this.dataGridView1.TabIndex = 0;
            // 
            // currentTestBindingSource
            // 
            this.currentTestBindingSource.DataMember = "CurrentTest";
            this.currentTestBindingSource.DataSource = this.dataDataSet;
            // 
            // dataDataSet
            // 
            this.dataDataSet.DataSetName = "dataDataSet";
            this.dataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // currentTestTableAdapter
            // 
            this.currentTestTableAdapter.ClearBeforeFill = true;
            // 
            // dateTimeStampDataGridViewTextBoxColumn
            // 
            this.dateTimeStampDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateTimeStampDataGridViewTextBoxColumn.DataPropertyName = "DateTimeStamp";
            this.dateTimeStampDataGridViewTextBoxColumn.HeaderText = "DateTimeStamp";
            this.dateTimeStampDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateTimeStampDataGridViewTextBoxColumn.Name = "dateTimeStampDataGridViewTextBoxColumn";
            this.dateTimeStampDataGridViewTextBoxColumn.Width = 138;
            // 
            // cH1DataGridViewTextBoxColumn
            // 
            this.cH1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH1DataGridViewTextBoxColumn.DataPropertyName = "CH1";
            this.cH1DataGridViewTextBoxColumn.HeaderText = "CH1";
            this.cH1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH1DataGridViewTextBoxColumn.Name = "cH1DataGridViewTextBoxColumn";
            this.cH1DataGridViewTextBoxColumn.Width = 64;
            // 
            // cH2DataGridViewTextBoxColumn
            // 
            this.cH2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH2DataGridViewTextBoxColumn.DataPropertyName = "CH2";
            this.cH2DataGridViewTextBoxColumn.HeaderText = "CH2";
            this.cH2DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH2DataGridViewTextBoxColumn.Name = "cH2DataGridViewTextBoxColumn";
            this.cH2DataGridViewTextBoxColumn.Width = 64;
            // 
            // cH3DataGridViewTextBoxColumn
            // 
            this.cH3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH3DataGridViewTextBoxColumn.DataPropertyName = "CH3";
            this.cH3DataGridViewTextBoxColumn.HeaderText = "CH3";
            this.cH3DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH3DataGridViewTextBoxColumn.Name = "cH3DataGridViewTextBoxColumn";
            this.cH3DataGridViewTextBoxColumn.Width = 64;
            // 
            // cH4DataGridViewTextBoxColumn
            // 
            this.cH4DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH4DataGridViewTextBoxColumn.DataPropertyName = "CH4";
            this.cH4DataGridViewTextBoxColumn.HeaderText = "CH4";
            this.cH4DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH4DataGridViewTextBoxColumn.Name = "cH4DataGridViewTextBoxColumn";
            this.cH4DataGridViewTextBoxColumn.Width = 64;
            // 
            // cH5DataGridViewTextBoxColumn
            // 
            this.cH5DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH5DataGridViewTextBoxColumn.DataPropertyName = "CH5";
            this.cH5DataGridViewTextBoxColumn.HeaderText = "CH5";
            this.cH5DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH5DataGridViewTextBoxColumn.Name = "cH5DataGridViewTextBoxColumn";
            this.cH5DataGridViewTextBoxColumn.Width = 64;
            // 
            // cH6DataGridViewTextBoxColumn
            // 
            this.cH6DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH6DataGridViewTextBoxColumn.DataPropertyName = "CH6";
            this.cH6DataGridViewTextBoxColumn.HeaderText = "CH6";
            this.cH6DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH6DataGridViewTextBoxColumn.Name = "cH6DataGridViewTextBoxColumn";
            this.cH6DataGridViewTextBoxColumn.Width = 64;
            // 
            // cH7DataGridViewTextBoxColumn
            // 
            this.cH7DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH7DataGridViewTextBoxColumn.DataPropertyName = "CH7";
            this.cH7DataGridViewTextBoxColumn.HeaderText = "CH7";
            this.cH7DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH7DataGridViewTextBoxColumn.Name = "cH7DataGridViewTextBoxColumn";
            this.cH7DataGridViewTextBoxColumn.Width = 64;
            // 
            // cH8DataGridViewTextBoxColumn
            // 
            this.cH8DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cH8DataGridViewTextBoxColumn.DataPropertyName = "CH8";
            this.cH8DataGridViewTextBoxColumn.HeaderText = "CH8";
            this.cH8DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cH8DataGridViewTextBoxColumn.Name = "cH8DataGridViewTextBoxColumn";
            this.cH8DataGridViewTextBoxColumn.Width = 64;
            // 
            // CyBLE_Current_Test_OnCurBrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1181, 691);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.Name = "CyBLE_Current_Test_OnCurBrd";
            this.Text = "CyBLE_Current_Test_OnCurBrd";
            this.Load += new System.EventHandler(this.CyBLE_Current_Test_OnCurBrd_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort CurtBrdserialPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckedListBox CH_SEL_checkedListBox;
        private System.Windows.Forms.Button btn_openAll;
        private System.Windows.Forms.Button btn_closeAll;
        private System.Windows.Forms.Button SaveExitBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dataDataSet dataDataSet;
        private System.Windows.Forms.BindingSource currentTestBindingSource;
        private dataDataSetTableAdapters.CurrentTestTableAdapter currentTestTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cH8DataGridViewTextBoxColumn;
    }
}