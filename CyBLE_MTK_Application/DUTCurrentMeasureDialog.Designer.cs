namespace CyBLE_MTK_Application
{
    partial class DUTCurrentMeasureDialog
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
            this.OKbtn_DUTCurrentMeasureDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownUpperlimit = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLowerlimit = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelayBeforeTest = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSampleCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSampleInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCalcTimePerSample = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownDelayAfterTest = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_criteria_per_sample = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_overall_condition = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpperlimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowerlimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBeforeTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalcTimePerSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayAfterTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKbtn_DUTCurrentMeasureDialog
            // 
            this.OKbtn_DUTCurrentMeasureDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKbtn_DUTCurrentMeasureDialog.Location = new System.Drawing.Point(548, 362);
            this.OKbtn_DUTCurrentMeasureDialog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OKbtn_DUTCurrentMeasureDialog.Name = "OKbtn_DUTCurrentMeasureDialog";
            this.OKbtn_DUTCurrentMeasureDialog.Size = new System.Drawing.Size(75, 36);
            this.OKbtn_DUTCurrentMeasureDialog.TabIndex = 0;
            this.OKbtn_DUTCurrentMeasureDialog.Text = "OK";
            this.OKbtn_DUTCurrentMeasureDialog.UseVisualStyleBackColor = true;
            this.OKbtn_DUTCurrentMeasureDialog.Click += new System.EventHandler(this.OKbtn_DUTCurrentMeasureDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upper Limit (mA)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lower Limit (mA)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Delay Before Test (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sample Count";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Sample Interval (ms)";
            // 
            // numericUpDownUpperlimit
            // 
            this.numericUpDownUpperlimit.Location = new System.Drawing.Point(15, 30);
            this.numericUpDownUpperlimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownUpperlimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownUpperlimit.Name = "numericUpDownUpperlimit";
            this.numericUpDownUpperlimit.Size = new System.Drawing.Size(109, 22);
            this.numericUpDownUpperlimit.TabIndex = 21;
            this.numericUpDownUpperlimit.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDownLowerlimit
            // 
            this.numericUpDownLowerlimit.Location = new System.Drawing.Point(15, 78);
            this.numericUpDownLowerlimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownLowerlimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLowerlimit.Name = "numericUpDownLowerlimit";
            this.numericUpDownLowerlimit.Size = new System.Drawing.Size(109, 22);
            this.numericUpDownLowerlimit.TabIndex = 22;
            this.numericUpDownLowerlimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownDelayBeforeTest
            // 
            this.numericUpDownDelayBeforeTest.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownDelayBeforeTest.Location = new System.Drawing.Point(15, 172);
            this.numericUpDownDelayBeforeTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownDelayBeforeTest.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownDelayBeforeTest.Name = "numericUpDownDelayBeforeTest";
            this.numericUpDownDelayBeforeTest.Size = new System.Drawing.Size(109, 22);
            this.numericUpDownDelayBeforeTest.TabIndex = 23;
            // 
            // numericUpDownSampleCount
            // 
            this.numericUpDownSampleCount.Location = new System.Drawing.Point(15, 124);
            this.numericUpDownSampleCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownSampleCount.Name = "numericUpDownSampleCount";
            this.numericUpDownSampleCount.Size = new System.Drawing.Size(109, 22);
            this.numericUpDownSampleCount.TabIndex = 24;
            this.numericUpDownSampleCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSampleCount.ValueChanged += new System.EventHandler(this.numericUpDownRepeat_ValueChanged);
            // 
            // numericUpDownSampleInterval
            // 
            this.numericUpDownSampleInterval.Location = new System.Drawing.Point(183, 30);
            this.numericUpDownSampleInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownSampleInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSampleInterval.Name = "numericUpDownSampleInterval";
            this.numericUpDownSampleInterval.Size = new System.Drawing.Size(109, 22);
            this.numericUpDownSampleInterval.TabIndex = 25;
            this.numericUpDownSampleInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownCalcTimePerSample
            // 
            this.numericUpDownCalcTimePerSample.Location = new System.Drawing.Point(183, 78);
            this.numericUpDownCalcTimePerSample.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownCalcTimePerSample.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCalcTimePerSample.Name = "numericUpDownCalcTimePerSample";
            this.numericUpDownCalcTimePerSample.Size = new System.Drawing.Size(109, 22);
            this.numericUpDownCalcTimePerSample.TabIndex = 27;
            this.numericUpDownCalcTimePerSample.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Calc Time Per Sample (ms)";
            // 
            // numericUpDownDelayAfterTest
            // 
            this.numericUpDownDelayAfterTest.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownDelayAfterTest.Location = new System.Drawing.Point(181, 172);
            this.numericUpDownDelayAfterTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownDelayAfterTest.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownDelayAfterTest.Name = "numericUpDownDelayAfterTest";
            this.numericUpDownDelayAfterTest.Size = new System.Drawing.Size(109, 22);
            this.numericUpDownDelayAfterTest.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Delay After Test (ms)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBox_criteria_per_sample);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox_overall_condition);
            this.groupBox1.Location = new System.Drawing.Point(395, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(224, 134);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pass Condition";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Criteria for Per Sample";
            // 
            // comboBox_criteria_per_sample
            // 
            this.comboBox_criteria_per_sample.FormattingEnabled = true;
            this.comboBox_criteria_per_sample.Items.AddRange(new object[] {
            "AVERAGE",
            "MAX_AND_MIN"});
            this.comboBox_criteria_per_sample.Location = new System.Drawing.Point(7, 47);
            this.comboBox_criteria_per_sample.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_criteria_per_sample.Name = "comboBox_criteria_per_sample";
            this.comboBox_criteria_per_sample.Size = new System.Drawing.Size(209, 24);
            this.comboBox_criteria_per_sample.TabIndex = 19;
            this.comboBox_criteria_per_sample.Text = "AVERAGE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Overall Result";
            // 
            // comboBox_overall_condition
            // 
            this.comboBox_overall_condition.FormattingEnabled = true;
            this.comboBox_overall_condition.Items.AddRange(new object[] {
            "ALL_SAMPLES",
            "ONE_SAMPLE"});
            this.comboBox_overall_condition.Location = new System.Drawing.Point(7, 102);
            this.comboBox_overall_condition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_overall_condition.Name = "comboBox_overall_condition";
            this.comboBox_overall_condition.Size = new System.Drawing.Size(209, 24);
            this.comboBox_overall_condition.TabIndex = 17;
            this.comboBox_overall_condition.Text = "ALL_SAMPLES";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 199);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instruments";
            // 
            // DUTCurrentMeasureDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 409);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericUpDownDelayAfterTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownCalcTimePerSample);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownSampleInterval);
            this.Controls.Add(this.numericUpDownSampleCount);
            this.Controls.Add(this.numericUpDownDelayBeforeTest);
            this.Controls.Add(this.numericUpDownLowerlimit);
            this.Controls.Add(this.numericUpDownUpperlimit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKbtn_DUTCurrentMeasureDialog);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "DUTCurrentMeasureDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DUTCurrentMeasureSettingsDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpperlimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowerlimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBeforeTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalcTimePerSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayAfterTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKbtn_DUTCurrentMeasureDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_overall_condition;
        private System.Windows.Forms.NumericUpDown numericUpDownUpperlimit;
        private System.Windows.Forms.NumericUpDown numericUpDownLowerlimit;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayBeforeTest;
        private System.Windows.Forms.NumericUpDown numericUpDownSampleCount;
        private System.Windows.Forms.NumericUpDown numericUpDownSampleInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownCalcTimePerSample;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayAfterTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_criteria_per_sample;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}