using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class Maintravel_info : UserControl
    {
        public List<Travel_info> info { get; set; }

        public Maintravel_info(List<Travel_info> Main)
        {
            InitializeComponent();
            info = Main;
        }


        #region 여행지 정보 확인
        private void SetTravel_Info(Travel_info info)
        {
            pictureBox1.Image = new Bitmap(Image.FromFile(info.trv_info_img), 310, 280);
            lbl_trv_info_name.Text = info.trv_info_name;
            lbl_trv_info_tel.Text = info.trv_info_tel;
            lbl_trv_info_price.Text = info.trv_info_price + " 만원";
            tbx_trv_info_data.Text = info.trv_info_Data;
        }
        #endregion

        private void Maintravel_info_Load(object sender, EventArgs e)
        {
            SetTravel_Info(info[0]);
            foreach(Travel_info temp in info)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Name = temp.trv_info_ID;
                treeNode.Text = temp.trv_info_name;
                treeNode.Tag = temp;
                treeView1.Nodes.Add(treeNode);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Travel_info temp = (Travel_info)e.Node.Tag;

            pictureBox1.Image = new Bitmap(Image.FromFile(temp.trv_info_img), 310, 280);
            lbl_trv_info_name.Text = temp.trv_info_name;
            lbl_trv_info_tel.Text = temp.trv_info_tel;
            lbl_trv_info_price.Text = temp.trv_info_price + " 만원";
            tbx_trv_info_data.Text = temp.trv_info_Data;
        }
    }
}
