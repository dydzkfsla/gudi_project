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
        private Maintravel_info Maintravel_infoPanel = null;
        List<Travel_info> info = null;
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
            Travel_infoDB infoDB = new Travel_infoDB();
            info = infoDB.MainTravel();
            if(info != null)
            {
                foreach(Travel_info travel in info)
                {
                    TabPage tab = new TabPage();
                    tab.Text = travel.trv_info_name;
                    tab.Name = travel.trv_info_ID;
                    if (travel.trv_info_img != null) {
                        tab.BackgroundImage = Image.FromFile(travel.trv_info_img);
                        tab.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    tab.Tag = travel;
                    tbc_MainTrInfo.Controls.Add(tab);
                }
            }
            infoDB.Dispose();

            tbc_MainTrInfo.SelectedIndex = 0;
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
            Fromdelete();
            this.UserInfoPanel = new System.Windows.Forms.UserInfoPanel(User);
            this.Controls.Add(this.UserInfoPanel);
            this.UserInfoPanel.BringToFront();
            this.Tag = UserInfoPanel;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 대표여행지ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Fromdelete();
            Maintravel_infoPanel = new Maintravel_info(info);
            Maintravel_infoPanel.Location = new Point(0, 30);
            this.Controls.Add(Maintravel_infoPanel);
            Maintravel_infoPanel.BringToFront();
            this.Tag = Maintravel_infoPanel;
        }

        private void tbc_MainTrInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Travel_info temp = (Travel_info)tbc_MainTrInfo.SelectedTab.Tag;
            lbl_info_name.Text = temp.trv_info_name;
            lbl_info_price.Text = temp.trv_info_price + " 만원";
            lbl_info_start_date.Text = temp.trv_info_start_date;
            lbl_info_tel.Text = temp.trv_info_tel;
        }

        #region 이미 다른걸 보고있다면 삭제
        private void Fromdelete()
        {
            if (this.Tag != null)
            {
                this.Controls.Remove((Control)this.Tag);
                this.Tag = null;
            }
        }
        #endregion
    }
}
