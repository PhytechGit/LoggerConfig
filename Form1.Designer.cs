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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.richTextBoxLgr = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.StageLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.comboPortAtml.Location = new System.Drawing.Point(111, 38);
            this.comboPortAtml.Name = "comboPortAtml";
            this.comboPortAtml.Size = new System.Drawing.Size(103, 21);
            this.comboPortAtml.TabIndex = 1;
            // 
            // comboPortsEzr
            // 
            this.comboPortsEzr.FormattingEnabled = true;
            this.comboPortsEzr.Location = new System.Drawing.Point(111, 78);
            this.comboPortsEzr.Name = "comboPortsEzr";
            this.comboPortsEzr.Size = new System.Drawing.Size(103, 21);
            this.comboPortsEzr.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Atmel Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select EZR Port:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start New Logger";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openAtmelComBtn
            // 
            this.openAtmelComBtn.Location = new System.Drawing.Point(224, 38);
            this.openAtmelComBtn.Name = "openAtmelComBtn";
            this.openAtmelComBtn.Size = new System.Drawing.Size(42, 21);
            this.openAtmelComBtn.TabIndex = 6;
            this.openAtmelComBtn.Text = "Open";
            this.openAtmelComBtn.UseVisualStyleBackColor = true;
            this.openAtmelComBtn.Click += new System.EventHandler(this.openAtmelComBtn_Click);
            // 
            // openEzrComBtn
            // 
            this.openEzrComBtn.Location = new System.Drawing.Point(224, 78);
            this.openEzrComBtn.Name = "openEzrComBtn";
            this.openEzrComBtn.Size = new System.Drawing.Size(42, 21);
            this.openEzrComBtn.TabIndex = 7;
            this.openEzrComBtn.Text = "Open";
            this.openEzrComBtn.UseVisualStyleBackColor = true;
            this.openEzrComBtn.Click += new System.EventHandler(this.openEzrComBtn_Click);
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
            this.button2.Location = new System.Drawing.Point(661, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
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
            this.progressBar1.Location = new System.Drawing.Point(331, 109);
            this.progressBar1.Maximum = 8;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(419, 20);
            this.progressBar1.TabIndex = 12;
            // 
            // StageLbl
            // 
            this.StageLbl.AutoSize = true;
            this.StageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StageLbl.Location = new System.Drawing.Point(460, 20);
            this.StageLbl.Name = "StageLbl";
            this.StageLbl.Size = new System.Drawing.Size(0, 16);
            this.StageLbl.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(762, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.CheckOnClick = true;
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showLogToolStripMenuItem.Text = "Show Log";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 175);
            this.Controls.Add(this.StageLbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBoxLgr);
            this.Controls.Add(this.openEzrComBtn);
            this.Controls.Add(this.openAtmelComBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPortsEzr);
            this.Controls.Add(this.comboPortAtml);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LoggerConfig";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.RichTextBox richTextBoxLgr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label StageLbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
    }
}

