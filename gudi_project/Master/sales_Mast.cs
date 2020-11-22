using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gudi_project
{
    public partial class sales_Mast : Form
    {
        DataTable dt = null;
        public sales_Mast()
        {
            InitializeComponent();
        }

        private void sales_Mast_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            List<string> date = new List<string>();
            //List<string> trv_info_name = new List<string>();
            string from_date = dtp_from_date.Value.ToString("yyyy-MM-dd");
            string to_date = dtp_to_date.Value.ToString("yyyy-MM-dd");
            ReservationDB db = new ReservationDB();
            dt = db.Getsales(from_date, to_date);
            db.Dispose();

            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName != "trv_info_name")
                    date.Add(col.ColumnName);
            }

            foreach (DataRow row in dt.Rows)
            {
                string trv_info_name = row["trv_info_name"].ToString();
                chart1.Series.Add(new Series(trv_info_name));
                foreach (string dt in date)
                {
                    chart1.Series[trv_info_name].Points.AddXY(dt, row[dt]);
                }
            }
        }
    }
}
