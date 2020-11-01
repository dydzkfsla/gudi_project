using gudi_project;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    class UserInfoPanel : Panel
    {
        User User = null;
        public UserInfoPanel(User user) : base()
        {
            InitializeComponent();
            User = user;
            CodeDB db = new CodeDB();
            Event ev = new Event();

            string state_Name = db.GetCodeName(User.usr_status_code);

            lbl_Email.Text = User.usr_email;
            lbl_Name.Text = User.usr_name;
            lbl_from_date.Text = User.usr_from_date;
            lbl_state_Name.Text = state_Name;
            tbx_Pwd.KeyPress += ev.tbx_Trim;
            tbx_NewPwd.KeyPress += ev.tbx_Trim;
            tbx_NewPwdre.KeyPress += ev.tbx_Trim;
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_from_date = new System.Windows.Forms.Label();
            this.lbl_state_Name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Pwd = new System.Windows.Forms.TextBox();
            this.tbx_NewPwd = new System.Windows.Forms.TextBox();
            this.btn_Pwd = new System.Windows.Forms.Button();
            this.lbl_PwdTest = new System.Windows.Forms.Label();
            this.pen_Green = new System.Windows.Forms.Panel();
            this.pen_Yellow = new System.Windows.Forms.Panel();
            this.pen_Red = new System.Windows.Forms.Panel();
            this.btn_NewPwd = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pwd_color = new System.Windows.Forms.Panel();
            this.pwdre_color = new System.Windows.Forms.Panel();
            this.tbx_NewPwdre = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.pwd_color.SuspendLayout();
            this.pwdre_color.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "가입일";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "상태";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(303, 36);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(52, 21);
            this.lbl_Email.TabIndex = 12;
            this.lbl_Email.Text = "label6";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(303, 106);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(52, 21);
            this.lbl_Name.TabIndex = 13;
            this.lbl_Name.Text = "label6";
            // 
            // lbl_from_date
            // 
            this.lbl_from_date.AutoSize = true;
            this.lbl_from_date.Location = new System.Drawing.Point(303, 176);
            this.lbl_from_date.Name = "lbl_from_date";
            this.lbl_from_date.Size = new System.Drawing.Size(52, 21);
            this.lbl_from_date.TabIndex = 14;
            this.lbl_from_date.Text = "label6";
            // 
            // lbl_state_Name
            // 
            this.lbl_state_Name.AutoSize = true;
            this.lbl_state_Name.Location = new System.Drawing.Point(303, 246);
            this.lbl_state_Name.Name = "lbl_state_Name";
            this.lbl_state_Name.Size = new System.Drawing.Size(52, 21);
            this.lbl_state_Name.TabIndex = 15;
            this.lbl_state_Name.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "현 비밀번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "변경 비밀번호";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "비밀번호 확인";
            // 
            // tbx_Pwd
            // 
            this.tbx_Pwd.Location = new System.Drawing.Point(131, 32);
            this.tbx_Pwd.Name = "tbx_Pwd";
            this.tbx_Pwd.PasswordChar = '*';
            this.tbx_Pwd.Size = new System.Drawing.Size(235, 29);
            this.tbx_Pwd.TabIndex = 19;
            // 
            // tbx_NewPwd
            // 
            this.tbx_NewPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_NewPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_NewPwd.Location = new System.Drawing.Point(3, 3);
            this.tbx_NewPwd.Margin = new System.Windows.Forms.Padding(0);
            this.tbx_NewPwd.Name = "tbx_NewPwd";
            this.tbx_NewPwd.PasswordChar = '*';
            this.tbx_NewPwd.Size = new System.Drawing.Size(229, 22);
            this.tbx_NewPwd.TabIndex = 20;
            this.tbx_NewPwd.TextChanged += new System.EventHandler(this.tbx_password_Test);
            // 
            // btn_Pwd
            // 
            this.btn_Pwd.Location = new System.Drawing.Point(425, 30);
            this.btn_Pwd.Name = "btn_Pwd";
            this.btn_Pwd.Size = new System.Drawing.Size(135, 30);
            this.btn_Pwd.TabIndex = 22;
            this.btn_Pwd.Text = "비밀번호 확인";
            this.btn_Pwd.UseVisualStyleBackColor = true;
            this.btn_Pwd.Click += new System.EventHandler(this.btn_Pwd_Click);
            // 
            // lbl_PwdTest
            // 
            this.lbl_PwdTest.AutoSize = true;
            this.lbl_PwdTest.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PwdTest.Location = new System.Drawing.Point(529, 84);
            this.lbl_PwdTest.Name = "lbl_PwdTest";
            this.lbl_PwdTest.Size = new System.Drawing.Size(50, 25);
            this.lbl_PwdTest.TabIndex = 48;
            this.lbl_PwdTest.Text = "위험";
            // 
            // pen_Green
            // 
            this.pen_Green.BackColor = System.Drawing.Color.LawnGreen;
            this.pen_Green.ForeColor = System.Drawing.Color.White;
            this.pen_Green.Location = new System.Drawing.Point(490, 81);
            this.pen_Green.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pen_Green.Name = "pen_Green";
            this.pen_Green.Size = new System.Drawing.Size(27, 29);
            this.pen_Green.TabIndex = 46;
            this.pen_Green.Visible = false;
            // 
            // pen_Yellow
            // 
            this.pen_Yellow.BackColor = System.Drawing.Color.Yellow;
            this.pen_Yellow.ForeColor = System.Drawing.Color.White;
            this.pen_Yellow.Location = new System.Drawing.Point(458, 81);
            this.pen_Yellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pen_Yellow.Name = "pen_Yellow";
            this.pen_Yellow.Size = new System.Drawing.Size(27, 29);
            this.pen_Yellow.TabIndex = 47;
            this.pen_Yellow.Visible = false;
            // 
            // pen_Red
            // 
            this.pen_Red.BackColor = System.Drawing.Color.Red;
            this.pen_Red.ForeColor = System.Drawing.Color.White;
            this.pen_Red.Location = new System.Drawing.Point(425, 81);
            this.pen_Red.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pen_Red.Name = "pen_Red";
            this.pen_Red.Size = new System.Drawing.Size(27, 29);
            this.pen_Red.TabIndex = 45;
            // 
            // btn_NewPwd
            // 
            this.btn_NewPwd.Location = new System.Drawing.Point(513, 526);
            this.btn_NewPwd.Name = "btn_NewPwd";
            this.btn_NewPwd.Size = new System.Drawing.Size(126, 52);
            this.btn_NewPwd.TabIndex = 50;
            this.btn_NewPwd.Text = "비밀번호 변경";
            this.btn_NewPwd.UseVisualStyleBackColor = true;
            this.btn_NewPwd.Click += new System.EventHandler(this.btn_NewPwd_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(32, 526);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(126, 52);
            this.btn_ok.TabIndex = 51;
            this.btn_ok.Text = "확인";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pwdre_color);
            this.groupBox1.Controls.Add(this.pwd_color);
            this.groupBox1.Controls.Add(this.lbl_PwdTest);
            this.groupBox1.Controls.Add(this.pen_Green);
            this.groupBox1.Controls.Add(this.pen_Yellow);
            this.groupBox1.Controls.Add(this.pen_Red);
            this.groupBox1.Controls.Add(this.btn_Pwd);
            this.groupBox1.Controls.Add(this.tbx_Pwd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(32, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 191);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "비밀번호 변경";
            // 
            // pwd_color
            // 
            this.pwd_color.BackColor = System.Drawing.Color.Red;
            this.pwd_color.Controls.Add(this.tbx_NewPwd);
            this.pwd_color.Location = new System.Drawing.Point(131, 82);
            this.pwd_color.Name = "pwd_color";
            this.pwd_color.Size = new System.Drawing.Size(235, 28);
            this.pwd_color.TabIndex = 49;
            // 
            // pwdre_color
            // 
            this.pwdre_color.BackColor = System.Drawing.Color.Red;
            this.pwdre_color.Controls.Add(this.tbx_NewPwdre);
            this.pwdre_color.Location = new System.Drawing.Point(131, 134);
            this.pwdre_color.Name = "pwdre_color";
            this.pwdre_color.Size = new System.Drawing.Size(235, 28);
            this.pwdre_color.TabIndex = 50;
            // 
            // tbx_NewPwdre
            // 
            this.tbx_NewPwdre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_NewPwdre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_NewPwdre.Location = new System.Drawing.Point(3, 3);
            this.tbx_NewPwdre.Margin = new System.Windows.Forms.Padding(0);
            this.tbx_NewPwdre.Name = "tbx_NewPwdre";
            this.tbx_NewPwdre.PasswordChar = '*';
            this.tbx_NewPwdre.Size = new System.Drawing.Size(229, 22);
            this.tbx_NewPwdre.TabIndex = 20;
            this.tbx_NewPwdre.TextChanged += new System.EventHandler(this.tbx_passwordre_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.btn_NewPwd);
            this.panel1.Controls.Add(this.lbl_state_Name);
            this.panel1.Controls.Add(this.lbl_from_date);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Controls.Add(this.lbl_Email);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 736);
            this.panel1.TabIndex = 53;
            // 
            // UserMain
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Location = new System.Drawing.Point(0, 32);
            this.Size = new System.Drawing.Size(984, 730);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pwd_color.ResumeLayout(false);
            this.pwd_color.PerformLayout();
            this.pwdre_color.ResumeLayout(false);
            this.pwdre_color.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 이벤트
        private void btn_Pwd_Click(object sender, EventArgs e)
        {
            UserDB db = new UserDB();
            if (db.UserChackPwd(lbl_Email.Text.Trim(), tbx_Pwd.Text.Trim()))
            {
                tbx_Pwd.Enabled = false;
                btn_Pwd.Enabled = false;
            }
            else
            {
                MessageBox.Show("맞지 않는 비밀번호 입니다.");
            }
        }

        #region 패스워드 1차 확인
        private void tbx_password_Test(object sender, EventArgs e)
        {
            Regex test1 = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}");
            Regex test2 = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9]).{8,}");
            string Text = tbx_NewPwd.Text.Trim().Replace(" ", "");
            if (test1.IsMatch(Text))
            {
                pwd_color.BackColor = Color.Black;
                pen_Yellow.Visible = true;
                pen_Green.Visible = true;
                lbl_PwdTest.Text = "안전";
                TestPwdColor();
            }
            else if (test2.IsMatch(Text))
            {
                pwd_color.BackColor = Color.Black;
                pen_Yellow.Visible = true;
                pen_Green.Visible = false;
                lbl_PwdTest.Text = "주의";
                TestPwdColor();
            }
            else
            {
                pwd_color.BackColor = Color.Red;
                pen_Yellow.Visible = false;
                pen_Green.Visible = false;
                lbl_PwdTest.Text = "경고";
                TestPwdColor();
            }
        }
        private void TestPwdColor() //비밀번호 확인 박스 색 변경확인
        {
            if (pwdre_color.BackColor == Color.Black)
            {
                pwdre_color.BackColor = Color.Red;
            }
        }
        #endregion

        #region 패스워드 2차 확인
        private void tbx_passwordre_TextChanged(object sender, EventArgs e)
        {
            if (pwd_color.BackColor == Color.Black && tbx_NewPwd.Text == tbx_NewPwdre.Text)
            {
                pwdre_color.BackColor = Color.Black;
            }
            else
            {
                pwdre_color.BackColor = Color.Red;
            }
        }
        #endregion

        private void btn_NewPwd_Click(object sender, EventArgs e)
        {
            UserDB db = new UserDB();
            if(pwd_color.BackColor == Color.Black && pwdre_color.BackColor == Color.Black && !tbx_Pwd.Enabled)
            {
                if(db.UpdatePwd(lbl_Email.Text.Trim(), tbx_NewPwd.Text.Trim()))
                {
                    MessageBox.Show("비밀번호 변경 성공");
                }
                else
                {
                    MessageBox.Show("비밀번호 변경 실패");
                }
                db.Dispose();
                this.Dispose();
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region 추가 컨트롤들
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_from_date;
        private System.Windows.Forms.Label lbl_state_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_Pwd;
        private System.Windows.Forms.TextBox tbx_NewPwd;
        private System.Windows.Forms.Button btn_Pwd;
        private System.Windows.Forms.Label lbl_PwdTest;
        private System.Windows.Forms.Panel pen_Green;
        private System.Windows.Forms.Panel pen_Yellow;
        private System.Windows.Forms.Panel pen_Red;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pwdre_color;
        private System.Windows.Forms.TextBox tbx_NewPwdre;
        private System.Windows.Forms.Panel pwd_color;
        private System.Windows.Forms.Button btn_NewPwd;
        private System.Windows.Forms.Panel panel1;
        #endregion 추가 컨트롤들
    }
}
