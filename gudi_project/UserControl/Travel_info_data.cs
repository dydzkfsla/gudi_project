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
    public partial class Travel_info_data : UserControl
    {
        Travel_info info = null;
        User user = null;
        public Travel_info_data(Travel_info info ,User user)
        {
            InitializeComponent();
            this.info = info;
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Travel_info> lsit = new List<Travel_info>() { info };
            Maintravel_info temp = new Maintravel_info(lsit, user);
            temp.Location = new Point(0, 0);
            this.Parent.Parent.Controls.Add(temp);
            temp.BringToFront();
        }

        private void Travel_info_data_Load(object sender, EventArgs e)
        {
            lbl_trv_name.Text = info.trv_info_name;
            lbl_Start_date.Text = info.trv_info_start_date;
            lbl_price.Text = info.trv_info_price;
            pictureBox1.ImageLocation = info.trv_info_img.Replace("http", "https");

            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "경유지", "trv_name", 200);
            TravelDB db = new TravelDB();
            dataGridView1.DataSource = db.GetTravel(info.trv_info_ID);
            db.Dispose();
        }
    }
}
