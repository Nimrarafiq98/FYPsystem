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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRegno
            // 
            this.txtRegno.Location = new System.Drawing.Point(305, 109);
            this.txtRegno.Multiline = true;
            this.txtRegno.Name = "txtRegno";
            this.txtRegno.Size = new System.Drawing.Size(163, 34);
            this.txtRegno.TabIndex = 0;
            this.txtRegno.TextChanged += new System.EventHandler(this.txtRegno_TextChanged);
            // 
            // lblregNo
            // 
            this.lblregNo.AutoSize = true;
            this.lblregNo.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregNo.Location = new System.Drawing.Point(22, 109);
            this.lblregNo.Name = "lblregNo";
            this.lblregNo.Size = new System.Drawing.Size(251, 34);
            this.lblregNo.TabIndex = 1;
            this.lblregNo.Text = "Registration Number";
            this.lblregNo.Click += new System.EventHandler(this.lblregNo_Click);
            // 
            // cmdInfo
            // 
            this.cmdInfo.Font = new System.Drawing.Font("Segoe Script", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInfo.Location = new System.Drawing.Point(181, 174);
            this.cmdInfo.Name = "cmdInfo";
            this.cmdInfo.Size = new System.Drawing.Size(223, 47);
            this.cmdInfo.TabIndex = 2;
            this.cmdInfo.Text = "Add Student";
            this.cmdInfo.UseVisualStyleBackColor = true;
            this.cmdInfo.Click += new System.EventHandler(this.cmdInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student Information";
            // 
            // Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 327);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
    }
}