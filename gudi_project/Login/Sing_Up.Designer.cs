﻿namespace gudi_project
{
    partial class Sing_Up
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_code_check = new System.Windows.Forms.Button();
            this.lbl_Count = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_PwdTest = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_email_name = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chb = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_email_check = new System.Windows.Forms.Button();
            this.lbl_code = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.pen_Red = new System.Windows.Forms.Panel();
            this.pen_Yellow = new System.Windows.Forms.Panel();
            this.pen_Green = new System.Windows.Forms.Panel();
            this.tbx_code = new gudi_project.ColorTextBox();
            this.tbx_name = new gudi_project.ColorTextBox();
            this.tbx_passwordre = new gudi_project.ColorTextBox();
            this.tbx_password = new gudi_project.ColorTextBox();
            this.tbx_email_name = new gudi_project.ColorTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(27, 558);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(465, 72);
            this.button1.TabIndex = 28;
            this.button1.Text = "가입 하기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_code_check
            // 
            this.btn_code_check.BackColor = System.Drawing.Color.White;
            this.btn_code_check.Location = new System.Drawing.Point(649, 172);
            this.btn_code_check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_code_check.Name = "btn_code_check";
            this.btn_code_check.Size = new System.Drawing.Size(119, 42);
            this.btn_code_check.TabIndex = 36;
            this.btn_code_check.Text = "코드 확인";
            this.btn_code_check.UseVisualStyleBackColor = false;
            // 
            // lbl_Count
            // 
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Count.Location = new System.Drawing.Point(662, 132);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(64, 30);
            this.lbl_Count.TabIndex = 38;
            this.lbl_Count.Text = "300";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_PwdTest
            // 
            this.lbl_PwdTest.AutoSize = true;
            this.lbl_PwdTest.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PwdTest.Location = new System.Drawing.Point(642, 271);
            this.lbl_PwdTest.Name = "lbl_PwdTest";
            this.lbl_PwdTest.Size = new System.Drawing.Size(63, 32);
            this.lbl_PwdTest.TabIndex = 44;
            this.lbl_PwdTest.Text = "위험";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(523, 558);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 72);
            this.button2.TabIndex = 50;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 81);
            this.label1.TabIndex = 1;
            this.label1.Text = "환영합니다!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "지금 가입하여 즐겁고 손쉬운 여행을 경험하세요.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 32);
            this.label3.TabIndex = 17;
            this.label3.Text = "이메일";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 32);
            this.label4.TabIndex = 19;
            this.label4.Text = "@";
            // 
            // cbx_email_name
            // 
            this.cbx_email_name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_email_name.FormattingEnabled = true;
            this.cbx_email_name.Location = new System.Drawing.Point(271, 176);
            this.cbx_email_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_email_name.Name = "cbx_email_name";
            this.cbx_email_name.Size = new System.Drawing.Size(221, 39);
            this.cbx_email_name.TabIndex = 1;
            this.cbx_email_name.SelectedIndexChanged += new System.EventHandler(this.tbx_email_name_TextChanged);
            this.cbx_email_name.TextUpdate += new System.EventHandler(this.tbx_email_name_TextChanged);
            this.cbx_email_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Trim);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 32);
            this.label5.TabIndex = 21;
            this.label5.Text = "비밀번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 32);
            this.label6.TabIndex = 23;
            this.label6.Text = "비밀번호 확인";
            // 
            // chb
            // 
            this.chb.AutoSize = true;
            this.chb.Location = new System.Drawing.Point(29, 532);
            this.chb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chb.Name = "chb";
            this.chb.Size = new System.Drawing.Size(309, 19);
            this.chb.TabIndex = 25;
            this.chb.Text = "이용 약관과 개인정보 취급에 동의합니다.";
            this.chb.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 32);
            this.label7.TabIndex = 26;
            this.label7.Text = "이름";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(26, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(412, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "* 최소 8자 이상이며 숫자와 문자를 하나씩 포합이해 합니다.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(26, 421);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "*비밀번호를 다시 입력해 주세요";
            // 
            // btn_email_check
            // 
            this.btn_email_check.BackColor = System.Drawing.Color.White;
            this.btn_email_check.Location = new System.Drawing.Point(523, 172);
            this.btn_email_check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_email_check.Name = "btn_email_check";
            this.btn_email_check.Size = new System.Drawing.Size(119, 42);
            this.btn_email_check.TabIndex = 31;
            this.btn_email_check.Text = "메일 확인";
            this.btn_email_check.UseVisualStyleBackColor = false;
            this.btn_email_check.Click += new System.EventHandler(this.btn_email_check_Click);
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_code.Location = new System.Drawing.Point(535, 90);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(87, 32);
            this.lbl_code.TabIndex = 34;
            this.lbl_code.Text = "코드값";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(534, 134);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(111, 32);
            this.lbl_time.TabIndex = 37;
            this.lbl_time.Text = "시간확인";
            // 
            // pen_Red
            // 
            this.pen_Red.BackColor = System.Drawing.Color.Red;
            this.pen_Red.ForeColor = System.Drawing.Color.White;
            this.pen_Red.Location = new System.Drawing.Point(523, 268);
            this.pen_Red.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pen_Red.Name = "pen_Red";
            this.pen_Red.Size = new System.Drawing.Size(31, 36);
            this.pen_Red.TabIndex = 42;
            // 
            // pen_Yellow
            // 
            this.pen_Yellow.BackColor = System.Drawing.Color.Yellow;
            this.pen_Yellow.ForeColor = System.Drawing.Color.White;
            this.pen_Yellow.Location = new System.Drawing.Point(561, 268);
            this.pen_Yellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pen_Yellow.Name = "pen_Yellow";
            this.pen_Yellow.Size = new System.Drawing.Size(31, 36);
            this.pen_Yellow.TabIndex = 43;
            this.pen_Yellow.Visible = false;
            // 
            // pen_Green
            // 
            this.pen_Green.BackColor = System.Drawing.Color.LawnGreen;
            this.pen_Green.ForeColor = System.Drawing.Color.White;
            this.pen_Green.Location = new System.Drawing.Point(598, 268);
            this.pen_Green.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pen_Green.Name = "pen_Green";
            this.pen_Green.Size = new System.Drawing.Size(31, 36);
            this.pen_Green.TabIndex = 43;
            this.pen_Green.Visible = false;
            // 
            // tbx_code
            // 
            this.tbx_code.BackColor = System.Drawing.Color.Red;
            this.tbx_code.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tbx_code.Location = new System.Drawing.Point(649, 89);
            this.tbx_code.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbx_code.Name = "tbx_code";
            this.tbx_code.PasswordChar = '\0';
            this.tbx_code.Size = new System.Drawing.Size(120, 37);
            this.tbx_code.TabIndex = 55;
            this.tbx_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Trim);
            // 
            // tbx_name
            // 
            this.tbx_name.BackColor = System.Drawing.Color.Red;
            this.tbx_name.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tbx_name.Location = new System.Drawing.Point(32, 473);
            this.tbx_name.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.PasswordChar = '\0';
            this.tbx_name.Size = new System.Drawing.Size(460, 37);
            this.tbx_name.TabIndex = 54;
            // 
            // tbx_passwordre
            // 
            this.tbx_passwordre.BackColor = System.Drawing.Color.Red;
            this.tbx_passwordre.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tbx_passwordre.Location = new System.Drawing.Point(32, 378);
            this.tbx_passwordre.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbx_passwordre.Name = "tbx_passwordre";
            this.tbx_passwordre.PasswordChar = '\0';
            this.tbx_passwordre.Size = new System.Drawing.Size(460, 37);
            this.tbx_passwordre.TabIndex = 53;
            this.tbx_passwordre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Trim);
            // 
            // tbx_password
            // 
            this.tbx_password.BackColor = System.Drawing.Color.Red;
            this.tbx_password.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tbx_password.Location = new System.Drawing.Point(32, 266);
            this.tbx_password.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.PasswordChar = '\0';
            this.tbx_password.Size = new System.Drawing.Size(460, 37);
            this.tbx_password.TabIndex = 52;
            this.tbx_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Trim);
            // 
            // tbx_email_name
            // 
            this.tbx_email_name.BackColor = System.Drawing.Color.Red;
            this.tbx_email_name.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tbx_email_name.Location = new System.Drawing.Point(27, 178);
            this.tbx_email_name.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbx_email_name.Name = "tbx_email_name";
            this.tbx_email_name.PasswordChar = '\0';
            this.tbx_email_name.Size = new System.Drawing.Size(223, 37);
            this.tbx_email_name.TabIndex = 51;
            this.tbx_email_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Trim);
            // 
            // Sing_Up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(845, 706);
            this.Controls.Add(this.tbx_code);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.tbx_passwordre);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.tbx_email_name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl_PwdTest);
            this.Controls.Add(this.pen_Green);
            this.Controls.Add(this.pen_Yellow);
            this.Controls.Add(this.pen_Red);
            this.Controls.Add(this.lbl_Count);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.btn_code_check);
            this.Controls.Add(this.lbl_code);
            this.Controls.Add(this.btn_email_check);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_email_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sing_Up";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sing_Up";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sing_Up_FormClosing);
            this.Load += new System.EventHandler(this.Sing_Up_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_code_check;
        private System.Windows.Forms.Label lbl_Count;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_PwdTest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_email_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_email_check;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Panel pen_Red;
        private System.Windows.Forms.Panel pen_Yellow;
        private System.Windows.Forms.Panel pen_Green;
        private ColorTextBox tbx_email_name;
        private ColorTextBox tbx_password;
        private ColorTextBox tbx_passwordre;
        private ColorTextBox tbx_name;
        private ColorTextBox tbx_code;
    }
}