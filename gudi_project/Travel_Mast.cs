using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class Travel_Mast : Form
    {
        int max = 0, min = 0;

        public Travel_Mast()
        {
            InitializeComponent();
        }

        private void Travel_Mast_Load(object sender, EventArgs e)
        {
            SetDgv();
            DataLoad();
        }

        #region private 메서드

        private void SetDgv()
        {

            CommonUtil.SetInitGridView(dataGridView3);

            CommonUtil.AddGridTextColumn(dataGridView3 , "trv_ID", "trv_ID");
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_name", "trv_name");
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_addr", "trv_addr");
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_data", "trv_data");
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_tel", "trv_tel");
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_lat", "trv_lat");
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_lng", "trv_lng");
            CommonUtil.AddGridImageColumn(dataGridView3, "image", "image");
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_img", "trv_img",visibility: false);

        }

        private void DataLoad()
        {
            travelDataLoad();

        }

        private void travelDataLoad()
        {

            TravelDB db = new TravelDB();
            List<Travel> list = db.selectlimit();
            db.Dispose();

            dataGridView3.DataSource = list;

            foreach(DataGridViewRow row in dataGridView3.Rows)
            {
                DataGridViewImageCell DGVI = (DataGridViewImageCell)(row.Cells["image"]);
                Bitmap bitmap = CommonUtil.WebImageView(row.Cells["trv_img"].Value.ToString().Replace("http", "https"));
                MemoryStream ms = new MemoryStream();   // 초기화
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Image image = Image.FromStream(ms);
                pictureBox1.Image = image;
                DGVI. = image;
            }
        }
        #endregion
    }
}
