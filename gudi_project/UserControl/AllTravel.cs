using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace gudi_project
{
    public partial class AllTravel : UserControl
    {
        User user = null;
        public AllTravel(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AllTravel_Load(object sender, EventArgs e)
        {
            dtp_to_date.Value = dtp_from_date.Value.AddMonths(6);
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            panel1.Controls.Clear();
            string from_date = dtp_from_date.Value.ToString("yyyy-MM-dd");
            string to_date = dtp_to_date.Value.ToString("yyyy-MM-dd");

            Travel_infoDB db = new Travel_infoDB();
            List<Travel_info> trb = db.MainTravel(from_date, to_date);
            int i = 0;
            if (trb != null)
            {
                foreach (Travel_info info in trb)
                {
                    Travel_info_data temp = new Travel_info_data(info, user);
                    temp.Name = i.ToString();
                    temp.Size = new Size(800, 150);
                    temp.Location = new Point(15, 25 + (i++ * 175));
                    panel1.Controls.Add(temp);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
