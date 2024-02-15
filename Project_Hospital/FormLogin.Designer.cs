namespace Project_Hospital
{
    partial class FormLogin
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
            this.BtnPatientLogin = new System.Windows.Forms.Button();
            this.BtnDoctorLogin = new System.Windows.Forms.Button();
            this.BtnSecretaryLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnPatientLogin
            // 
            this.BtnPatientLogin.Location = new System.Drawing.Point(39, 38);
            this.BtnPatientLogin.Name = "BtnPatientLogin";
            this.BtnPatientLogin.Size = new System.Drawing.Size(141, 122);
            this.BtnPatientLogin.TabIndex = 0;
            this.BtnPatientLogin.Text = "button1";
            this.BtnPatientLogin.UseVisualStyleBackColor = true;
            this.BtnPatientLogin.Click += new System.EventHandler(this.BtnPatientLogin_Click);
            // 
            // BtnDoctorLogin
            // 
            this.BtnDoctorLogin.Location = new System.Drawing.Point(217, 38);
            this.BtnDoctorLogin.Name = "BtnDoctorLogin";
            this.BtnDoctorLogin.Size = new System.Drawing.Size(141, 122);
            this.BtnDoctorLogin.TabIndex = 1;
            this.BtnDoctorLogin.Text = "button2";
            this.BtnDoctorLogin.UseVisualStyleBackColor = true;
            this.BtnDoctorLogin.Click += new System.EventHandler(this.BtnDoctorLogin_Click);
            // 
            // BtnSecretaryLogin
            // 
            this.BtnSecretaryLogin.Location = new System.Drawing.Point(404, 38);
            this.BtnSecretaryLogin.Name = "BtnSecretaryLogin";
            this.BtnSecretaryLogin.Size = new System.Drawing.Size(141, 122);
            this.BtnSecretaryLogin.TabIndex = 2;
            this.BtnSecretaryLogin.Text = "button3";
            this.BtnSecretaryLogin.UseVisualStyleBackColor = true;
            this.BtnSecretaryLogin.Click += new System.EventHandler(this.BtnSecretaryLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Doctor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Secretary";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(686, 359);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSecretaryLogin);
            this.Controls.Add(this.BtnDoctorLogin);
            this.Controls.Add(this.BtnPatientLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnPatientLogin;
        private System.Windows.Forms.Button BtnDoctorLogin;
        private System.Windows.Forms.Button BtnSecretaryLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

