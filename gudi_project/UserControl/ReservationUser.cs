using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;

namespace gudi_project
{
    public partial class ReservationUser : UserControl
    {
        User user;

        public ReservationUser(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ReservationUser_Load(object sender, EventArgs e)
        {
            RoadData();
        }

        private void RoadData()
        {
            panel1.Controls.Clear();
            ReservationDB db = new ReservationDB();
            DataRow[] rows = db.UsergetRervation(user.usr_email).Select();
            db.Dispose();
            int i = 0;
            foreach (DataRow row in rows)
            {
                ResControl resControl = new ResControl(row);
                resControl.Name = row["res_ID"].ToString();
                resControl.Size = new Size(750, 150);
                resControl.Location = new Point(25, 25 + (i++ * 175));
                resControl.DBAtiocn += ResControl_DBAtiocn;
                panel1.Controls.Add(resControl);

                //string Name =  row["usr_name"].ToString();
                //string Res_date = row["res_date"].ToString();
                //string res_prce = row["res_prce"].ToString();
                //string trv_info_name = row["trv_info_name"].ToString();
                //string trv_info_img = row["trv_info_img"].ToString();
            }
        }

        private void ResControl_DBAtiocn(object send, ResControl.DeleteButtonActiocnArgs e)
        {
            ReservationDB db = new ReservationDB();
            if (db.DeleteRes(e.res_ID))
            {
                RoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
