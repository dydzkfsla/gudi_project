namespace gudi_project
{
    partial class Pword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_email_name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbx_email_name = new System.Windows.Forms.MyTextBox();
            this.btn_Pwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "이메일";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "이름";
            // 
            // cbx_email_name
            // 
            this.cbx_email_name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_email_name.FormattingEnabled = true;
            this.cbx_email_name.Location = new System.Drawing.Point(331, 23);
            this.cbx_email_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_email_name.Name = "cbx_email_name";
            this.cbx_email_name.Size = new System.Drawing.Size(194, 39);
            this.cbx_email_name.TabIndex = 21;
            this.cbx_email_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Trim);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(296, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 32);
            this.label4.TabIndex = 22;
            this.label4.Text = "@";
            // 
            // tbx_name
            // 
            this.tbx_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_name.Location = new System.Drawing.Point(113, 71);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(180, 38);
            this.tbx_name.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 48);
            this.button1.TabIndex = 24;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbx_email_name
            // 
            this.tbx_email_name.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbx_email_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_email_name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_email_name.Location = new System.Drawing.Point(113, 26);
            this.tbx_email_name.Margin = new System.Windows.Forms.Padding(0);
            this.tbx_email_name.Name = "tbx_email_name";
            this.tbx_email_name.Size = new System.Drawing.Size(180, 38);
            this.tbx_email_name.TabIndex = 0;
            this.tbx_email_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Trim);
            // 
            // btn_Pwd
            // 
            this.btn_Pwd.Location = new System.Drawing.Point(56, 151);
            this.btn_Pwd.Name = "btn_Pwd";
            this.btn_Pwd.Size = new System.Drawing.Size(201, 48);
            this.btn_Pwd.TabIndex = 23;
            this.btn_Pwd.Text = "비밀번호 초기화";
            this.btn_Pwd.UseVisualStyleBackColor = true;
            this.btn_Pwd.Click += new System.EventHandler(this.btn_Pwd_Click);
            // 
            // Pword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 228);
            this.Controls.Add(this.tbx_email_name);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Pwd);
            this.Controls.Add(this.cbx_email_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pword";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pword_FormClosing);
            this.Load += new System.EventHandler(this.Pword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MyTextBox tbx_email_name;
        private System.Windows.Forms.ComboBox cbx_email_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Pwd;
    }
}