namespace CyBLE_MTK_Application
{
    partial class SerialPortSettingsDialog
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SerialPortCombo = new System.Windows.Forms.ComboBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(195, 54);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(100, 28);
            this.ConnectButton.TabIndex = 11;
            this.ConnectButton.Text = "Co&nnect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // SerialPortCombo
            // 
            this.SerialPortCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialPortCombo.FormattingEnabled = true;
            this.SerialPortCombo.Location = new System.Drawing.Point(16, 17);
            this.SerialPortCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SerialPortCombo.Name = "SerialPortCombo";
            this.SerialPortCombo.Size = new System.Drawing.Size(517, 24);
            this.SerialPortCombo.TabIndex = 10;
            this.SerialPortCombo.SelectedIndexChanged += new System.EventHandler(this.SerialPortCombo_SelectedIndexChanged);
            this.SerialPortCombo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SerialPortCombo_MouseClick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = global::CyBLE_MTK_Application.Properties.Resources.Refresh_icon;
            this.RefreshButton.Location = new System.Drawing.Point(543, 11);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(39, 36);
            this.RefreshButton.TabIndex = 13;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(303, 54);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 28);
            this.CloseButton.TabIndex = 14;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // SerialPortSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(597, 92);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.SerialPortCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialPortSettingsDialog";
            this.Text = "Serial Port Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox SerialPortCombo;
        private System.Windows.Forms.Button CloseButton;

    }
}