namespace LoggerConfig
{
    partial class AtmelBrnType
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
            this.radioBtnMk = new System.Windows.Forms.RadioButton();
            this.radioBtnIce = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.btnCncl = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioBtnMk
            // 
            this.radioBtnMk.AutoSize = true;
            this.radioBtnMk.Location = new System.Drawing.Point(33, 53);
            this.radioBtnMk.Name = "radioBtnMk";
            this.radioBtnMk.Size = new System.Drawing.Size(84, 17);
            this.radioBtnMk.TabIndex = 1;
            this.radioBtnMk.TabStop = true;
            this.radioBtnMk.Text = "ATMEL MK||";
            this.radioBtnMk.UseVisualStyleBackColor = true;
            // 
            // radioBtnIce
            // 
            this.radioBtnIce.AutoSize = true;
            this.radioBtnIce.Location = new System.Drawing.Point(32, 20);
            this.radioBtnIce.Name = "radioBtnIce";
            this.radioBtnIce.Size = new System.Drawing.Size(81, 17);
            this.radioBtnIce.TabIndex = 0;
            this.radioBtnIce.TabStop = true;
            this.radioBtnIce.Text = "ATMEL ICE";
            this.radioBtnIce.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnMk);
            this.groupBox1.Controls.Add(this.radioBtnIce);
            this.groupBox1.Location = new System.Drawing.Point(42, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 91);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(20, 118);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(90, 25);
            this.BtnOK.TabIndex = 3;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCncl
            // 
            this.btnCncl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCncl.Location = new System.Drawing.Point(127, 118);
            this.btnCncl.Name = "btnCncl";
            this.btnCncl.Size = new System.Drawing.Size(90, 25);
            this.btnCncl.TabIndex = 4;
            this.btnCncl.Text = "Cancel";
            this.btnCncl.UseVisualStyleBackColor = true;
            // 
            // AtmelBrnType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 153);
            this.Controls.Add(this.btnCncl);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "AtmelBrnType";
            this.Text = "Atmel Burner Type";
            this.Load += new System.EventHandler(this.AtmelBrnType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBtnIce;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button btnCncl;
        private System.Windows.Forms.RadioButton radioBtnMk;
    }
}