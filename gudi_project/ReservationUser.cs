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
            ReservationDB db = new ReservationDB();
            DataRow[] rows =  db.UsergetRervation(user.usr_email).Select();
            foreach(DataRow row in rows)
            {
                string Name =  row["usr_name"].ToString();
                string Res_date = row["res_date"].ToString();
                string res_prce = row["res_prce"].ToString();
                string trv_info_name = row["trv_info_name"].ToString();
                string trv_info_img = row["trv_info_img"].ToString();
            }

        }
    }
}
