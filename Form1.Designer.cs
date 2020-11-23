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
            this.cleareLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOfficialVersionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.factoryNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontGenerateNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amelBurnerTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valvesGateWayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.percentageLbl = new System.Windows.Forms.Label();
            this.pictureOK6 = new System.Windows.Forms.PictureBox();
            this.pictureOK3 = new System.Windows.Forms.PictureBox();
            this.pictureOK4 = new System.Windows.Forms.PictureBox();
            this.pictureOK5 = new System.Windows.Forms.PictureBox();
            this.pictureOK2 = new System.Windows.Forms.PictureBox();
            this.pictureOK1 = new System.Windows.Forms.PictureBox();
            this.pictureOK7 = new System.Windows.Forms.PictureBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.PumpLbl = new System.Windows.Forms.Label();
            this.pictureOK8 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK8)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 189);
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
            this.button1.Location = new System.Drawing.Point(77, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start Configure New Logger";
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
            this.richTextBoxLgr.Location = new System.Drawing.Point(275, 189);
            this.richTextBoxLgr.Name = "richTextBoxLgr";
            this.richTextBoxLgr.Size = new System.Drawing.Size(292, 142);
            this.richTextBoxLgr.TabIndex = 9;
            this.richTextBoxLgr.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(573, 189);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(210, 142);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(275, 147);
            this.progressBar1.Maximum = 11;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(504, 33);
            this.progressBar1.TabIndex = 12;
            // 
            // StageLbl
            // 
            this.StageLbl.AutoSize = true;
            this.StageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StageLbl.Location = new System.Drawing.Point(410, 26);
            this.StageLbl.Name = "StageLbl";
            this.StageLbl.Size = new System.Drawing.Size(16, 16);
            this.StageLbl.TabIndex = 14;
            this.StageLbl.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.iDToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogToolStripMenuItem,
            this.cleareLogsToolStripMenuItem,
            this.showOfficialVersionsToolStripMenuItem,
            this.factoryNameToolStripMenuItem,
            this.filesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.CheckOnClick = true;
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showLogToolStripMenuItem.Text = "Show Log";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // cleareLogsToolStripMenuItem
            // 
            this.cleareLogsToolStripMenuItem.Name = "cleareLogsToolStripMenuItem";
            this.cleareLogsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.cleareLogsToolStripMenuItem.Text = "Clear Logs";
            this.cleareLogsToolStripMenuItem.Click += new System.EventHandler(this.cleareLogsToolStripMenuItem_Click);
            // 
            // showOfficialVersionsToolStripMenuItem
            // 
            this.showOfficialVersionsToolStripMenuItem.Name = "showOfficialVersionsToolStripMenuItem";
            this.showOfficialVersionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showOfficialVersionsToolStripMenuItem.Text = "Official Versions";
            this.showOfficialVersionsToolStripMenuItem.Click += new System.EventHandler(this.showOfficialVersionsToolStripMenuItem_Click);
            // 
            // factoryNameToolStripMenuItem
            // 
            this.factoryNameToolStripMenuItem.Name = "factoryNameToolStripMenuItem";
            this.factoryNameToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.factoryNameToolStripMenuItem.Text = "Factory Name";
            this.factoryNameToolStripMenuItem.Click += new System.EventHandler(this.factoryNameToolStripMenuItem_Click);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.filesToolStripMenuItem.Text = "Files ";
            this.filesToolStripMenuItem.Click += new System.EventHandler(this.filesToolStripMenuItem_Click);
            // 
            // iDToolStripMenuItem
            // 
            this.iDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dontGenerateNewToolStripMenuItem,
            this.amelBurnerTypeToolStripMenuItem,
            this.valvesGateWayToolStripMenuItem});
            this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
            this.iDToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.iDToolStripMenuItem.Text = "Operation";
            // 
            // dontGenerateNewToolStripMenuItem
            // 
            this.dontGenerateNewToolStripMenuItem.CheckOnClick = true;
            this.dontGenerateNewToolStripMenuItem.Name = "dontGenerateNewToolStripMenuItem";
            this.dontGenerateNewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.dontGenerateNewToolStripMenuItem.Text = "Don\'t Generate New ID";
            this.dontGenerateNewToolStripMenuItem.Click += new System.EventHandler(this.dontGenerateNewToolStripMenuItem_Click);
            // 
            // amelBurnerTypeToolStripMenuItem
            // 
            this.amelBurnerTypeToolStripMenuItem.Name = "amelBurnerTypeToolStripMenuItem";
            this.amelBurnerTypeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.amelBurnerTypeToolStripMenuItem.Text = "Amel Burner Type";
            this.amelBurnerTypeToolStripMenuItem.Click += new System.EventHandler(this.amelBurnerTypeToolStripMenuItem_Click);
            // 
            // valvesGateWayToolStripMenuItem
            // 
            this.valvesGateWayToolStripMenuItem.CheckOnClick = true;
            this.valvesGateWayToolStripMenuItem.Name = "valvesGateWayToolStripMenuItem";
            this.valvesGateWayToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.valvesGateWayToolStripMenuItem.Text = "Valves GateWay";
            this.valvesGateWayToolStripMenuItem.CheckedChanged += new System.EventHandler(this.valvesGateWayToolStripMenuItem_CheckedChanged);
            // 
            // percentageLbl
            // 
            this.percentageLbl.AutoSize = true;
            this.percentageLbl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.percentageLbl.Location = new System.Drawing.Point(517, 157);
            this.percentageLbl.Name = "percentageLbl";
            this.percentageLbl.Size = new System.Drawing.Size(21, 13);
            this.percentageLbl.TabIndex = 16;
            this.percentageLbl.Text = "0%";
            // 
            // pictureOK6
            // 
            this.pictureOK6.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK6.Image")));
            this.pictureOK6.Location = new System.Drawing.Point(390, 109);
            this.pictureOK6.Name = "pictureOK6";
            this.pictureOK6.Size = new System.Drawing.Size(15, 15);
            this.pictureOK6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK6.TabIndex = 22;
            this.pictureOK6.TabStop = false;
            this.pictureOK6.Visible = false;
            // 
            // pictureOK3
            // 
            this.pictureOK3.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK3.Image")));
            this.pictureOK3.Location = new System.Drawing.Point(390, 58);
            this.pictureOK3.Name = "pictureOK3";
            this.pictureOK3.Size = new System.Drawing.Size(15, 15);
            this.pictureOK3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK3.TabIndex = 21;
            this.pictureOK3.TabStop = false;
            this.pictureOK3.Visible = false;
            // 
            // pictureOK4
            // 
            this.pictureOK4.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK4.Image")));
            this.pictureOK4.Location = new System.Drawing.Point(390, 75);
            this.pictureOK4.Name = "pictureOK4";
            this.pictureOK4.Size = new System.Drawing.Size(15, 15);
            this.pictureOK4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK4.TabIndex = 20;
            this.pictureOK4.TabStop = false;
            this.pictureOK4.Visible = false;
            // 
            // pictureOK5
            // 
            this.pictureOK5.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK5.Image")));
            this.pictureOK5.Location = new System.Drawing.Point(390, 92);
            this.pictureOK5.Name = "pictureOK5";
            this.pictureOK5.Size = new System.Drawing.Size(15, 15);
            this.pictureOK5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK5.TabIndex = 19;
            this.pictureOK5.TabStop = false;
            this.pictureOK5.Visible = false;
            // 
            // pictureOK2
            // 
            this.pictureOK2.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK2.Image")));
            this.pictureOK2.Location = new System.Drawing.Point(390, 42);
            this.pictureOK2.Name = "pictureOK2";
            this.pictureOK2.Size = new System.Drawing.Size(15, 15);
            this.pictureOK2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK2.TabIndex = 18;
            this.pictureOK2.TabStop = false;
            this.pictureOK2.Visible = false;
            // 
            // pictureOK1
            // 
            this.pictureOK1.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK1.Image")));
            this.pictureOK1.Location = new System.Drawing.Point(390, 26);
            this.pictureOK1.Name = "pictureOK1";
            this.pictureOK1.Size = new System.Drawing.Size(15, 15);
            this.pictureOK1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK1.TabIndex = 17;
            this.pictureOK1.TabStop = false;
            this.pictureOK1.Visible = false;
            // 
            // pictureOK7
            // 
            this.pictureOK7.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK7.Image")));
            this.pictureOK7.Location = new System.Drawing.Point(390, 126);
            this.pictureOK7.Name = "pictureOK7";
            this.pictureOK7.Size = new System.Drawing.Size(15, 15);
            this.pictureOK7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK7.TabIndex = 23;
            this.pictureOK7.TabStop = false;
            this.pictureOK7.Visible = false;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(111, 118);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(103, 20);
            this.textBoxID.TabIndex = 24;
            this.textBoxID.Visible = false;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(11, 118);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 13);
            this.labelID.TabIndex = 25;
            this.labelID.Text = "ID:";
            this.labelID.Visible = false;
            // 
            // PumpLbl
            // 
            this.PumpLbl.AutoSize = true;
            this.PumpLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PumpLbl.Location = new System.Drawing.Point(663, 58);
            this.PumpLbl.Name = "PumpLbl";
            this.PumpLbl.Size = new System.Drawing.Size(18, 16);
            this.PumpLbl.TabIndex = 26;
            this.PumpLbl.Text = "Y";
            // 
            // pictureOK8
            // 
            this.pictureOK8.Image = ((System.Drawing.Image)(resources.GetObject("pictureOK8.Image")));
            this.pictureOK8.Location = new System.Drawing.Point(646, 58);
            this.pictureOK8.Name = "pictureOK8";
            this.pictureOK8.Size = new System.Drawing.Size(15, 15);
            this.pictureOK8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOK8.TabIndex = 27;
            this.pictureOK8.TabStop = false;
            this.pictureOK8.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 258);
            this.Controls.Add(this.pictureOK8);
            this.Controls.Add(this.PumpLbl);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.pictureOK7);
            this.Controls.Add(this.pictureOK6);
            this.Controls.Add(this.pictureOK3);
            this.Controls.Add(this.pictureOK4);
            this.Controls.Add(this.pictureOK5);
            this.Controls.Add(this.pictureOK2);
            this.Controls.Add(this.pictureOK1);
            this.Controls.Add(this.percentageLbl);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoggerConfig";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOK8)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem cleareLogsToolStripMenuItem;
        private System.Windows.Forms.Label percentageLbl;
        private System.Windows.Forms.PictureBox pictureOK1;
        private System.Windows.Forms.PictureBox pictureOK2;
        private System.Windows.Forms.PictureBox pictureOK5;
        private System.Windows.Forms.PictureBox pictureOK4;
        private System.Windows.Forms.PictureBox pictureOK3;
        private System.Windows.Forms.PictureBox pictureOK6;
        private System.Windows.Forms.PictureBox pictureOK7;
        private System.Windows.Forms.ToolStripMenuItem showOfficialVersionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem factoryNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontGenerateNewToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.ToolStripMenuItem amelBurnerTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valvesGateWayToolStripMenuItem;
        private System.Windows.Forms.Label PumpLbl;
        private System.Windows.Forms.PictureBox pictureOK8;
    }
}

