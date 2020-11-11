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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Sing_Up_Show(object sender, EventArgs e)
        {
            Sing_Up.ShowSingUp(this);
            this.Hide();
        }
 
        private void btn_Login_Click(object sender, EventArgs e)
        {
            UserDB db = new UserDB();
            string Mas = db.UserLoingChack(tbx_Email.Text.Trim(), tbx_Pwd.Text.Trim());
            if (string.IsNullOrEmpty(Mas))
            {
                MessageBox.Show("아이디와 비밀번호를 확인해 주세요");
                db.Dispose();
                return;
            }
            if(Mas == "UM01")
            {
                User user = db.GetUser(tbx_Email.Text.Trim(), tbx_Pwd.Text.Trim());
                UserMain.ShowUserMainFrom(this, user);
                this.Hide();
            }
            else if(Mas == "UM02")
            {
                MessageBox.Show("관리자 로그인");
            }
            db.Dispose();
        }

        private void btn_Password_Click(object sender, EventArgs e)
        {
            Pword.Showfrm(this);
        }
    }
}
