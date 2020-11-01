using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class UserMain : Form
    {
        private static UserMain frm = null;
        private System.Windows.Forms.UserInfoPanel UserInfoPanel;
        User User = null;
        public static void ShowUserMainFrom(Form Parent, User User)
        {
            if (frm == null || frm.IsDisposed) 
            {
                frm = new UserMain(User);
                frm.Show();
                frm.Owner = Parent;
            }
        }

        public UserMain(User user)
        {
            User = user;
            InitializeComponent();
        }

        private void UserMain_Load(object sender, EventArgs e)
        {
            CodeDB db = new CodeDB();
            Event ev = new Event();
            string state_Name = db.GetCodeName(User.usr_status_code);
            db.Dispose();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void 정보수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UserInfoPanel = new System.Windows.Forms.UserInfoPanel(User);
            this.Controls.Add(this.UserInfoPanel);
            this.UserInfoPanel.BringToFront();
        }
    }
}
