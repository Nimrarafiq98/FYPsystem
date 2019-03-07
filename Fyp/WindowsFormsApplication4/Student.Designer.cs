namespace WindowsFormsApplication4
{
    partial class Student
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
            this.txtRegno = new System.Windows.Forms.TextBox();
            this.lblregNo = new System.Windows.Forms.Label();
            this.cmdInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRegno
            // 
            this.txtRegno.Location = new System.Drawing.Point(210, 109);
            this.txtRegno.Name = "txtRegno";
            this.txtRegno.Size = new System.Drawing.Size(100, 20);
            this.txtRegno.TabIndex = 0;
            // 
            // lblregNo
            // 
            this.lblregNo.AutoSize = true;
            this.lblregNo.Location = new System.Drawing.Point(81, 109);
            this.lblregNo.Name = "lblregNo";
            this.lblregNo.Size = new System.Drawing.Size(103, 13);
            this.lblregNo.TabIndex = 1;
            this.lblregNo.Text = "Registration Number";
            // 
            // cmdInfo
            // 
            this.cmdInfo.Location = new System.Drawing.Point(201, 154);
            this.cmdInfo.Name = "cmdInfo";
            this.cmdInfo.Size = new System.Drawing.Size(109, 29);
            this.cmdInfo.TabIndex = 2;
            this.cmdInfo.Text = "Add person Info";
            this.cmdInfo.UseVisualStyleBackColor = true;
            this.cmdInfo.Click += new System.EventHandler(this.cmdInfo_Click);
            // 
            // Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 298);
            this.Controls.Add(this.cmdInfo);
            this.Controls.Add(this.lblregNo);
            this.Controls.Add(this.txtRegno);
            this.Name = "Student";
            this.Text = "Student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRegno;
        private System.Windows.Forms.Label lblregNo;
        private System.Windows.Forms.Button cmdInfo;
    }
}