using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading;
using System.Text.RegularExpressions;

namespace gudi_project
{
    public partial class Sing_Up : Form
    {
        private static Sing_Up Sing_up = null;
        private string conn = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        private string code = "11011";
        private int Count = 10;
        private Sing_Up()
        {
            InitializeComponent();
        }

        public static void ShowSingUp()
        {
            if(Sing_up == null || Sing_up.IsDisposed)
            {
                Sing_up = new Sing_Up();
                Sing_up.Show();
            }
        }

        #region 로딩 
        private void Sing_Up_Load(object sender, EventArgs e)
        {
            using (MySqlConnection myConn = new MySqlConnection(conn))
            {
                string Command = @"select name from code
                              where code like 'EM%';";

                MySqlCommand command = new MySqlCommand(Command, myConn);
                myConn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbx_email_name.Items.Add(reader.GetString("name"));
                }
                reader.Close();
                myConn.Close();
            }
            lbl_code.Visible = code_color.Visible = btn_code_check.Visible 
                = lbl_time.Visible= lbl_Count.Visible = false;

            email_color.BackColor = name_color.BackColor = pwdre_color.BackColor
                = pwd_color.BackColor = code_color.BackColor = Color.Red;
        }
        #endregion

        #region 메일전송
        private void btn_email_check_Click(object sender, EventArgs e)
        {
            SendEamail();
            code_color.BackColor = Color.Red;
            timer1.Start();
            btn_code_check.Click += btn_code_check_Click;
        }

        private void SendEamail()
        {
            StringBuilder builder = new StringBuilder();
            Mail mail = new Mail();
            builder.Append(tbx_email_name);
            builder.Append("@");
            builder.Append(cbx_email_name.Text);

            mail.SetToAddress(builder.ToString());
            string Smail = mail.SendEmail("가입 확인 메일", "code: 11011");
            MessageBox.Show(Smail);
            if (Smail == "send mail Ok")
            {
                lbl_code.Visible = code_color.Visible = btn_code_check.Visible
                   = lbl_time.Visible = lbl_Count.Visible = true;
                btn_email_check.Text = "재전송";
            }
        }
        #endregion

        #region 코드확인 이벤트
        private void btn_code_check_Click(object sender, EventArgs e)
        {
            if(tbx_code.Text == code)
            {
                email_color.BackColor = code_color.BackColor = Color.Black;
                btn_email_check.Text = "메일 확인";
                timer1.Stop();
                Count = 300;

                lbl_code.Visible = code_color.Visible = btn_code_check.Visible
               = lbl_time.Visible = lbl_Count.Visible = false;
            }
        }
        #endregion

        #region 이메일 이름 변경 이벤트
        private void tbx_email_name_TextChanged(object sender, EventArgs e)
        {
            if (email_color.BackColor == Color.Black)
            {
                email_color.BackColor = email_color.BackColor = Color.Red;
            }
        }
        #endregion

        #region 메일 체크 시간 타이머
        private void timer1_Tick(object sender, EventArgs e)
        {
            Count -= 1;
            lbl_Count.Text = Count.ToString();
            if(Count == 0)
            {
                lbl_Count.Text = "시간 초과";
                timer1.Stop();
                Count = 300;
                btn_code_check.Click -= btn_code_check_Click;
            }
        }
        #endregion


        #region 패스워드 1차 확인
        private void tbx_password_Test(object sender, EventArgs e)
        {
            Regex test1 = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}");
            Regex test2 = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9]).{8,}");
            string Text = tbx_password.Text.Trim().Replace(" ", "");
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

        #region 공백제거
        private void tbx_password_Trim(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        #endregion

        #region 패스워드 2차 확인
        private void tbx_passwordre_TextChanged(object sender, EventArgs e)
        {
            if(pwd_color.BackColor == Color.Black && tbx_password.Text == tbx_passwordre.Text)
            {
                pwdre_color.BackColor = Color.Black;
            }
            else
            {
                pwdre_color.BackColor = Color.Red;
            }
        }
        #endregion

        #region 이름확인
        private void tbx_name_TextChanged(object sender, EventArgs e)
        {
            if(tbx_name.Text.Length > 3)
            {
                name_color.BackColor = Color.Black;
            }
            else
            {
                name_color.BackColor = Color.Red;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
