namespace LoggerConfig
{
    partial class SelectConfigForm
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
            this.radioButtonLgr = new System.Windows.Forms.RadioButton();
            this.radioButtonNG = new System.Windows.Forms.RadioButton();
            this.radioButtonGW = new System.Windows.Forms.RadioButton();
            this.OKBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonLgr
            // 
            this.radioButtonLgr.AutoSize = true;
            this.radioButtonLgr.Location = new System.Drawing.Point(42, 27);
            this.radioButtonLgr.Name = "radioButtonLgr";
            this.radioButtonLgr.Size = new System.Drawing.Size(58, 17);
            this.radioButtonLgr.TabIndex = 0;
            this.radioButtonLgr.TabStop = true;
            this.radioButtonLgr.Text = "Logger";
            this.radioButtonLgr.UseVisualStyleBackColor = true;
            // 
            // radioButtonNG
            // 
            this.radioButtonNG.AutoSize = true;
            this.radioButtonNG.Location = new System.Drawing.Point(42, 61);
            this.radioButtonNG.Name = "radioButtonNG";
            this.radioButtonNG.Size = new System.Drawing.Size(77, 17);
            this.radioButtonNG.TabIndex = 1;
            this.radioButtonNG.TabStop = true;
            this.radioButtonNG.Text = "NG Logger";
            this.radioButtonNG.UseVisualStyleBackColor = true;
            // 
            // radioButtonGW
            // 
            this.radioButtonGW.AutoSize = true;
            this.radioButtonGW.Location = new System.Drawing.Point(42, 95);
            this.radioButtonGW.Name = "radioButtonGW";
            this.radioButtonGW.Size = new System.Drawing.Size(79, 17);
            this.radioButtonGW.TabIndex = 2;
            this.radioButtonGW.TabStop = true;
            this.radioButtonGW.Text = "GATEWAY";
            this.radioButtonGW.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(21, 166);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(90, 32);
            this.OKBtn.TabIndex = 3;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(144, 166);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 32);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonGW);
            this.groupBox1.Controls.Add(this.radioButtonNG);
            this.groupBox1.Controls.Add(this.radioButtonLgr);
            this.groupBox1.Location = new System.Drawing.Point(49, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 143);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // SelectConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 209);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Name = "SelectConfigForm";
            this.Text = "Select Configuration";
            this.Load += new System.EventHandler(this.SelectConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonLgr;
        private System.Windows.Forms.RadioButton radioButtonNG;
        private System.Windows.Forms.RadioButton radioButtonGW;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}