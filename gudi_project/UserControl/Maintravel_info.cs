using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Instrumentation;
using System.Net;
using System.IO;

namespace gudi_project
{
    public partial class Maintravel_info : UserControl
    {
        public List<Travel_info> info { get; set; }
        User user;
        public Maintravel_info(List<Travel_info> Main, User user)
        {
            InitializeComponent();
            info = Main;
            this.user = user;
        }

        #region 여행지 정보 확인
        private void SetTravel_Info(Travel_info info)
        {
            pictureBox1.Image = Image.FromFile(info.trv_info_img);
            lbl_trv_info_name.Text = info.trv_info_name;
            lbl_trv_info_tel.Text = info.trv_info_tel;
            lbl_trv_info_price.Text = info.trv_info_price + " 만원";
            trv_info_start_date.Text = info.trv_info_start_date;
            tbx_trv_info_data.Text = info.trv_info_Data;
            Travel_infoDB db = new Travel_infoDB();

            lbl_Bus_set.Text = db.getremainderSeat(info.bus_ID, info.trv_info_ID).ToString() + " 자리";
        }
        #endregion

        private void Maintravel_info_Load(object sender, EventArgs e)
        {
            SetTravel_Info(info[0]);
            foreach (Travel_info temp in info)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Name = temp.trv_info_ID;
                treeNode.Text = temp.trv_info_name;
                treeNode.Tag = temp;
                treeView1.Nodes.Add(treeNode);
            }
            TreeNodeMouseClickEventArgs eventArgs = new TreeNodeMouseClickEventArgs(treeView1.Nodes[0], MouseButtons.Right, 2, 0 ,0);
            treeView1_NodeMouseDoubleClick(null, eventArgs);
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        #region 노드 변경, 다른 상품 클릭
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tabControl1.TabPages.Clear();
            Travel_info temp = (Travel_info)e.Node.Tag;
            TravelDB db = new TravelDB();
            SetTravel_Info(temp);
            List<Travel> travels =  db.GetTravel(temp.trv_info_ID);


            foreach(Travel trave in travels)
            {
                TabPage tab = new TabPage();
                tab.Text = trave.trv_name;
                tab.Name = trave.trv_ID;
                tab.Tag = trave;
                tabControl1.TabPages.Add(tab);
            }

            TabControlEventArgs tabControlEventArgs = new TabControlEventArgs(tabControl1.TabPages[0], 0, TabControlAction.Selected);
            tabControl1_Selected(null, tabControlEventArgs);
            tabControl1.SelectTab(0);
        }
        #endregion

        #region 탭 페이지 변경시
        /// <summary>
        ///  e.TabPage 의 NULL 체크로 삭제중일때 해당 이벤트 본내용이 실행 되지 않게 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
                Travel travel = (Travel)e.TabPage.Tag;
                pictureBox2.ImageLocation = travel.trv_img.Replace("http", "https");
                label8.Text = travel.trv_name;
                label9.Text = travel.trv_addr;
            }
        }
        #endregion

        #region 확인
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region 경유지 정보 확인
        private void button3_Click(object sender, EventArgs e)
        {
            Travel travel = null;
            if (tabControl1.SelectedTab != null)
            {
                travel = (Travel)tabControl1.SelectedTab.Tag;
            }
            if (travel != null)
            {
                Traveldata frm = new Traveldata(travel);
                frm.Show();
            }

        }
        #endregion

        #region 예약
        private void button2_Click(object sender, EventArgs e)
        {
            Travel_info travel = treeView1.SelectedNode.Tag as Travel_info;
            BusReservation busReservation = new BusReservation(travel);
            if(busReservation.ShowDialog() == DialogResult.OK)
            {
                DataRow[] rows = busReservation.table.Select();
                List<seat> seats = new List<seat>();
                
                foreach(DataRow row in rows)
                {
                    seat temp = new seat();
                    temp.res_seat_num = row["seat"].ToString();
                    seats.Add(temp);
                }

                ReservationDB db = new ReservationDB();
                if(db.InserReservation(travel, seats, user.usr_email))
                {
                    MessageBox.Show("성공적으로 예약 되었습니다.");
                }
                db.Dispose();
            }
        }
        #endregion
    }
}
