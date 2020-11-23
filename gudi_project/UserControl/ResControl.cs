using System;
using System.IO;
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
    public partial class ResControl : UserControl
    {
        DataRow row = null;

        public delegate void DeleteButtonActiocn(object send, DeleteButtonActiocnArgs e);
        public event DeleteButtonActiocn DBAtiocn;

        public ResControl(DataRow row)
        {
            InitializeComponent();
            this.row = row;
        }

        private void ResControl_Load(object sender, EventArgs e)
        {
            lbl_useremail.Text = row["usr_name"].ToString();
            lbl_Start_date.Text = row["res_date"].ToString();
            lbl_price.Text = row["res_prce"].ToString();
            lbl_trv_name.Text = row["trv_info_name"].ToString();
            byte[] image = (byte[])row["trv_info_img"];
            MemoryStream ms = new MemoryStream(image);
            pictureBox1.Image = Image.FromStream(ms);
            lbl_seat.Text = row["seat"].ToString();
            seatDB db = new seatDB();
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "예약좌석", "res_seat_num");
            dataGridView1.DataSource =  db.SeatListRes(row["res_ID"].ToString());
            db.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DBAtiocn != null)
            {
                DeleteButtonActiocnArgs args = new DeleteButtonActiocnArgs();
                args.res_ID = this.Name;
                DBAtiocn(sender, args);
            }
        }

        public class DeleteButtonActiocnArgs : EventArgs 
        { 
            public string res_ID { get; set; }
                    
        }

    }
}
