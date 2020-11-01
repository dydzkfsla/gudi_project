namespace gudi_project
{
    partial class Login
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbx_Pwd = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Sing_Up = new System.Windows.Forms.Button();
            this.btn_Password = new System.Windows.Forms.Button();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "로그인";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(-2, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1286, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------------------------------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "비밀번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 41);
            this.label4.TabIndex = 3;
            this.label4.Text = "아이디";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(186, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(388, 40);
            this.textBox1.TabIndex = 4;
            // 
            // tbx_Pwd
            // 
            this.tbx_Pwd.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Pwd.Location = new System.Drawing.Point(186, 181);
            this.tbx_Pwd.Name = "tbx_Pwd";
            this.tbx_Pwd.PasswordChar = '*';
            this.tbx_Pwd.Size = new System.Drawing.Size(388, 47);
            this.tbx_Pwd.TabIndex = 1;
            // 
            // btn_Login
            // 
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(19, 250);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(273, 70);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "로그인";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Sing_Up
            // 
            this.btn_Sing_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Sing_Up.Image = global::gudi_project.Properties.Resources.회원가입;
            this.btn_Sing_Up.Location = new System.Drawing.Point(617, 93);
            this.btn_Sing_Up.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Sing_Up.Name = "btn_Sing_Up";
            this.btn_Sing_Up.Size = new System.Drawing.Size(239, 240);
            this.btn_Sing_Up.TabIndex = 4;
            this.btn_Sing_Up.Text = "회 원 가 입";
            this.btn_Sing_Up.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sing_Up.UseVisualStyleBackColor = true;
            this.btn_Sing_Up.Click += new System.EventHandler(this.Sing_Up_Show);
            // 
            // btn_Password
            // 
            this.btn_Password.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Password.Location = new System.Drawing.Point(297, 250);
            this.btn_Password.Name = "btn_Password";
            this.btn_Password.Size = new System.Drawing.Size(277, 70);
            this.btn_Password.TabIndex = 3;
            this.btn_Password.Text = "비밀번호 찾기";
            this.btn_Password.UseVisualStyleBackColor = true;
            this.btn_Password.Click += new System.EventHandler(this.btn_Password_Click);
            // 
            // tbx_Email
            // 
            this.tbx_Email.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Email.Location = new System.Drawing.Point(186, 93);
            this.tbx_Email.Name = "tbx_Email";
            this.tbx_Email.Size = new System.Drawing.Size(388, 47);
            this.tbx_Email.TabIndex = 0;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(878, 364);
            this.Controls.Add(this.tbx_Email);
            this.Controls.Add(this.btn_Password);
            this.Controls.Add(this.btn_Sing_Up);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.tbx_Pwd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbx_Pwd;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Sing_Up;
        private System.Windows.Forms.Button btn_Password;
        private System.Windows.Forms.TextBox tbx_Email;
    }
}