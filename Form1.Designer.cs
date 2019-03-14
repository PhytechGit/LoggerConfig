namespace LoggerConfig
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.AtmelPort = new System.IO.Ports.SerialPort(this.components);
            this.EzrPort = new System.IO.Ports.SerialPort(this.components);
            this.comboPortAtml = new System.Windows.Forms.ComboBox();
            this.comboPortsEzr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openAtmelComBtn = new System.Windows.Forms.Button();
            this.openEzrComBtn = new System.Windows.Forms.Button();
            this.textID = new System.Windows.Forms.TextBox();
            this.richTextBoxLgr = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 184);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(254, 138);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // AtmelPort
            // 
            this.AtmelPort.BaudRate = 38400;
            this.AtmelPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.AtmelPort_DataReceived);
            // 
            // EzrPort
            // 
            this.EzrPort.BaudRate = 115200;
            this.EzrPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.EzrPort_DataReceived);
            // 
            // comboPortAtml
            // 
            this.comboPortAtml.FormattingEnabled = true;
            this.comboPortAtml.Location = new System.Drawing.Point(120, 26);
            this.comboPortAtml.Name = "comboPortAtml";
            this.comboPortAtml.Size = new System.Drawing.Size(130, 21);
            this.comboPortAtml.TabIndex = 1;
            // 
            // comboPortsEzr
            // 
            this.comboPortsEzr.FormattingEnabled = true;
            this.comboPortsEzr.Location = new System.Drawing.Point(120, 64);
            this.comboPortsEzr.Name = "comboPortsEzr";
            this.comboPortsEzr.Size = new System.Drawing.Size(129, 21);
            this.comboPortsEzr.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Atmel Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select EZR Port:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openAtmelComBtn
            // 
            this.openAtmelComBtn.Location = new System.Drawing.Point(265, 22);
            this.openAtmelComBtn.Name = "openAtmelComBtn";
            this.openAtmelComBtn.Size = new System.Drawing.Size(46, 27);
            this.openAtmelComBtn.TabIndex = 6;
            this.openAtmelComBtn.Text = "Open";
            this.openAtmelComBtn.UseVisualStyleBackColor = true;
            this.openAtmelComBtn.Click += new System.EventHandler(this.openAtmelComBtn_Click);
            // 
            // openEzrComBtn
            // 
            this.openEzrComBtn.Location = new System.Drawing.Point(267, 62);
            this.openEzrComBtn.Name = "openEzrComBtn";
            this.openEzrComBtn.Size = new System.Drawing.Size(42, 27);
            this.openEzrComBtn.TabIndex = 7;
            this.openEzrComBtn.Text = "Open";
            this.openEzrComBtn.UseVisualStyleBackColor = true;
            this.openEzrComBtn.Click += new System.EventHandler(this.openEzrComBtn_Click);
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(462, 81);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(122, 20);
            this.textID.TabIndex = 8;
            // 
            // richTextBoxLgr
            // 
            this.richTextBoxLgr.Location = new System.Drawing.Point(275, 184);
            this.richTextBoxLgr.Name = "richTextBoxLgr";
            this.richTextBoxLgr.Size = new System.Drawing.Size(292, 142);
            this.richTextBoxLgr.TabIndex = 9;
            this.richTextBoxLgr.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(467, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(573, 184);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(169, 142);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(15, 144);
            this.progressBar1.Maximum = 7;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(419, 20);
            this.progressBar1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 335);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBoxLgr);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.openEzrComBtn);
            this.Controls.Add(this.openAtmelComBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPortsEzr);
            this.Controls.Add(this.comboPortAtml);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "LoggerConfig";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.IO.Ports.SerialPort AtmelPort;
        private System.IO.Ports.SerialPort EzrPort;
        private System.Windows.Forms.ComboBox comboPortAtml;
        private System.Windows.Forms.ComboBox comboPortsEzr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button openAtmelComBtn;
        private System.Windows.Forms.Button openEzrComBtn;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.RichTextBox richTextBoxLgr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

