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
using System.Runtime.CompilerServices;

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

        public static void ShowSingUp(Form Parent)
        {
            if(Sing_up == null || Sing_up.IsDisposed)
            {
                Sing_up = new Sing_Up();
                Sing_up.Show();
                Sing_up.Owner = Parent;
            }
        }

        #region 로딩 
        private void Sing_Up_Load(object sender, EventArgs e)
        {
            CodeDB db = new CodeDB();
            DataTable dt =  db.getCategoryCode("Email");
            cbx_email_name.DataSource = dt;
            cbx_email_name.DisplayMember = "name";
            cbx_email_name.ValueMember = "name";
            db.Dispose();

            lbl_code.Visible = tbx_code.Visible = btn_code_check.Visible 
                = lbl_time.Visible= lbl_Count.Visible = false;

            tbx_email_name.BackColor = tbx_name.BackColor = tbx_password.BackColor
                = tbx_password.BackColor = tbx_code.BackColor = Color.Red;
            tbx_passwordre.SetTextChangedEvent(tbx_passwordre_TextChanged);
            tbx_email_name.SetTextChangedEvent(tbx_email_name_TextChanged);
            tbx_password.SetTextChangedEvent(tbx_password_Test);
            tbx_name.SetTextChangedEvent( tbx_name_TextChanged);

            tbx_password.PasswordChar = '*';
            tbx_passwordre.PasswordChar = '*';


        }
        #endregion

        #region 메일전송
        private void btn_email_check_Click(object sender, EventArgs e)
        {
            SendEamail();
            tbx_code.BackColor = Color.Red;
            timer1.Start();
            btn_code_check.Click += btn_code_check_Click;
        }

        private void SendEamail()
        {
            StringBuilder builder = new StringBuilder();
            Mail mail = new Mail();
            builder.Append(tbx_email_name.Text);
            builder.Append("@");
            builder.Append(cbx_email_name.Text);

            UserDB db = new UserDB();
            if (db.UserChack(builder.ToString()))
            {
                MessageBox.Show("이미 있는 유저입니다.");
                db.Dispose();
                return;
            }
            else
                db.Dispose();

            mail.SetToAddress(builder.ToString());
            string Smail = mail.SendEmail("가입 확인 메일", "code: 11011");
            MessageBox.Show(Smail);
            if (Smail == "send mail Ok")
            {
                lbl_code.Visible = tbx_code.Visible = btn_code_check.Visible
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
                tbx_email_name.BackColor = tbx_code.BackColor = Color.Black;
                btn_email_check.Text = "메일 확인";
                timer1.Stop();
                Count = 300;

                lbl_code.Visible = tbx_code.Visible = btn_code_check.Visible
               = lbl_time.Visible = lbl_Count.Visible = false;
            }
        }
        #endregion

        #region 이메일 이름 변경 이벤트
        private void tbx_email_name_TextChanged(object sender, EventArgs e)
        {
            if (tbx_email_name.BackColor == Color.Black)
            {
                tbx_email_name.BackColor = tbx_email_name.BackColor = Color.Red;
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
                tbx_password.BackColor = Color.Black;
                pen_Yellow.Visible = true;
                pen_Green.Visible = true;
                lbl_PwdTest.Text = "안전";
                TestPwdColor();
            }
            else if (test2.IsMatch(Text))
            {
                tbx_password.BackColor = Color.Black;
                pen_Yellow.Visible = true;
                pen_Green.Visible = false;
                lbl_PwdTest.Text = "주의";
                TestPwdColor();
            }
            else
            {
                tbx_password.BackColor = Color.Red;
                pen_Yellow.Visible = false;
                pen_Green.Visible = false;
                lbl_PwdTest.Text = "경고";
                TestPwdColor();
            }
        }

        private void TestPwdColor() //비밀번호 확인 박스 색 변경확인
        {
            if (tbx_passwordre.BackColor == Color.Black)
            {
                tbx_passwordre.BackColor = Color.Red;
            }
        }
        #endregion

        #region 공백제거
        private void tbx_Trim(object sender, KeyPressEventArgs e)
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
            if(tbx_password.BackColor == Color.Black && tbx_password.Text == tbx_passwordre.Text)
            {
                tbx_passwordre.BackColor = Color.Black;
            }
            else
            {
                tbx_passwordre.BackColor = Color.Red;
            }
        }
        #endregion

        #region 이름확인
        private void tbx_name_TextChanged(object sender, EventArgs e)
        {
            if(tbx_name.Text.Length > 2)
            {
                tbx_name.BackColor = Color.Black;
            }
            else
            {
                tbx_name.BackColor = Color.Red;
            }
        }
        #endregion

        #region 회원가입 체크
        private void button1_Click(object sender, EventArgs e)
        {
            bool Chaek = tbx_email_name.BackColor == Color.Black &&
                        tbx_password.BackColor == Color.Black &&
                        tbx_passwordre.BackColor == Color.Black &&
                        tbx_name.BackColor == Color.Black &&
                        chb.Checked;
            if (Chaek)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(tbx_email_name.Text.Trim());
                builder.Append("@");
                builder.Append(cbx_email_name.Text.Trim());

                UserDB db = new UserDB();
                bool flag = db.InsertUser(builder.ToString(), tbx_password.Text.Trim(), tbx_name.Text.Trim());
                db.Dispose();
                if (!flag)
                {
                    MessageBox.Show("유저 입력 실패 다시 시도하여 주십시오.");
                    return;
                }
                MessageBox.Show("회원 가입 성공");
                Sing_up.Close();
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 닫기
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 클로즈시 실행 : 로그인 페이지 표시
        private void Sing_Up_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }
        #endregion
    }
}
