using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class Pword : Form
    {
        private static Pword frm = null;

        private Pword()
        {
            InitializeComponent();
        }

        public static void Showfrm(Form Parent)
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new Pword();
                frm.Show();
                frm.Owner = Parent;
            }

        }

        private void Pword_Load(object sender, EventArgs e)
        {
            CodeDB db = new CodeDB();
            DataTable dt = db.getCategoryCode("Email");
            cbx_email_name.DataSource = dt;
            cbx_email_name.DisplayMember = "name";
            cbx_email_name.ValueMember = "name";
            db.Dispose();
        }


        #region 공백제거
        private void tbx_Trim(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 비밀 초기화
        private void btn_Pwd_Click(object sender, EventArgs e)
        {
            UserDB db = new UserDB();
            StringBuilder Email = new StringBuilder();
            string Name = tbx_name.Text.Trim();
            Email.Append(tbx_email_name.Text.Trim());
            Email.Append("@");
            Email.Append(cbx_email_name.Text.Trim());
            if (!db.UserChack(Email.ToString(), Name))
            {
                MessageBox.Show("존재하지 않는 회원입니다.");
                db.Dispose();
                return;
            }
            Mail mail = new Mail();
            mail.SetToAddress(Email.ToString());
            string NewPwd = Randompwd();
            string subject = $"{Name}님의 비빌번호";
            string body = $"초기화 비밀번호는 [{NewPwd}] 입니다.";
            string SendMail = mail.SendEmail($"{Name}님의 비빌번호", body);
            MessageBox.Show(SendMail);
            if (SendMail == "send mail Ok")
            {
                if(!db.UpdatePwd(Email.ToString(), NewPwd))
                {
                    MessageBox.Show("비밀번호 초기화 실패");
                }
            }
            db.Dispose();
        }
        #endregion

        #region 랜덤 비밀번호 생성
        private string Randompwd()
        {
            Random rand = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 8; i++) {
                int temp = rand.Next(0, 36);
                if(temp < 10)
                {
                    builder.Append(temp.ToString());
                }
                else
                {
                    temp += (int)'A' - 10;
                    builder.Append((char)temp);
                }
            }

            return builder.ToString();
        }
        #endregion

        #region 폼 종료
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Pword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }
        #endregion
            
    }
}
