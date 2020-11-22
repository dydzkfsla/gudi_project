using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            tbx_Max.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_Min.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_conn_trv_ID.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_conn_trv_info_ID.KeyPress += UtilEvent.TextBoxIsDigit;


            cbx_bus_emp_ID.ValueMember = cbx_guid_emp_ID.ValueMember = "emp_ID";
            cbx_bus_emp_ID.DisplayMember = cbx_guid_emp_ID.DisplayMember = "emp_name";
            cbx_bus_ID.ValueMember = "bus_ID";
            cbx_bus_ID.DisplayMember = "bus_ID";

            EmployeesDB edb = new EmployeesDB();
            cbx_bus_emp_ID.DataSource = edb.Getdepeployess("DE02");
            cbx_guid_emp_ID.DataSource = edb.Getdepeployess("DE01");
            edb.Dispose();

            BusDB db = new BusDB();
            cbx_bus_ID.DataSource = db.SelectID();
            db.Dispose();

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
            CommonUtil.AddGridTextColumn(dataGridView3, "trv_img", "trv_img",visibility: false);

            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "trv_ID", "trv_ID");
            CommonUtil.AddGridTextColumn(dataGridView1, "trv_info_ID", "trv_info_ID");


            CommonUtil.SetInitGridView(dataGridView2);

            CommonUtil.AddGridTextColumn(dataGridView2, "trv_info_ID", "trv_info_ID");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_ID", "bus_ID");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_emp_name", "bus_emp_name");
            CommonUtil.AddGridTextColumn(dataGridView2, "guid_emp_name", "guid_emp_name");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_emp_ID", "bus_emp_ID", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView2, "guid_emp_ID", "guid_emp_ID",visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView2, "trv_info_name", "trv_info_name");
            CommonUtil.AddGridTextColumn(dataGridView2, "trv_info_start_date", "trv_info_start_date");
            CommonUtil.AddGridTextColumn(dataGridView2, "trv_info_price", "trv_info_price");
            CommonUtil.AddGridTextColumn(dataGridView2, "trv_info_tel", "trv_info_tel");
            CommonUtil.AddGridTextColumn(dataGridView2, "trv_info_Data", "trv_info_Data");
            CommonUtil.AddGridImageColumn(dataGridView2, "trv_info_img", "trv_info_img");

        }

        private void DataLoad()
        {
            travelDataLoad();

            Travel_connDB TCdb = new Travel_connDB();
            dataGridView1.DataSource = TCdb.select();
            TCdb.Dispose();


            Travel_infoDB infodb = new Travel_infoDB();
            dataGridView2.DataSource = infodb.select();
            infodb.Dispose();
        }

        private void travelDataLoad()
        {
            TravelDB db = new TravelDB();
            List<Travel> list = db.selectlimit();
            var MinMax = db.selectMaxMin();
            db.Dispose();

            lbl_Max.Text = MinMax.max.ToString();
            lbl_Min.Text = MinMax.min.ToString();
            dataGridView3.DataSource = list;
        }
        #endregion


        #region 이벤트

        #region Travel_conn 이벤트

        #region Travel_conn dgv 더블클릭
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbx_conn_trv_ID.Text = dataGridView1["trv_ID", e.RowIndex].Value.ToString();
            tbx_conn_trv_info_ID.Text = dataGridView1["trv_info_ID", e.RowIndex].Value.ToString();
        }
        #endregion

        #region Travel_conn 추가
        private void button1_Click(object sender, EventArgs e)
        {
            string trv_info_ID = tbx_conn_trv_info_ID.Text.Trim();
            string trv_ID = tbx_conn_trv_ID.Text.Trim();
            if (trv_ID == string.Empty || trv_info_ID == string.Empty)
                return;
            Travel_infoDB infodb = new Travel_infoDB();
            List<string> trv_info_IDs = infodb.SelectIDList();
            infodb.Dispose();
            if (trv_info_IDs.IndexOf(trv_info_ID) == -1)
                return;
            TravelDB tdb = new TravelDB();
            List<string> trv_IDs = tdb.SelectIDList();
            tdb.Dispose();
            if (trv_IDs.IndexOf(trv_ID) == -1)
                return;

            Travel_connDB db = new Travel_connDB();
            db.insert(trv_ID, trv_info_ID);

            DataLoad();

        }
        #endregion

        #region Travel_conn 삭제
        private void button3_Click(object sender, EventArgs e)
        {
            string trv_info_ID = tbx_conn_trv_info_ID.Text.Trim();
            string trv_ID = tbx_conn_trv_ID.Text.Trim();
            if (trv_ID == string.Empty || trv_info_ID == string.Empty)
                return;
            Travel_connDB db = new Travel_connDB();
            db.delete(trv_ID, trv_info_ID);
            db.Dispose();

            DataLoad();
        }
        #endregion

        #endregion

        #region Travel_info 이벤트

        #region Travel_info dgv 더블클릭
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            tbx_trv_info_ID.Text = dataGridView2["trv_info_ID", e.RowIndex].Value.ToString();
            cbx_bus_ID.SelectedValue = dataGridView2["bus_ID", e.RowIndex].Value.ToString();
            cbx_bus_emp_ID.SelectedValue = dataGridView2["bus_emp_ID", e.RowIndex].Value.ToString();
            cbx_guid_emp_ID.SelectedValue = dataGridView2["guid_emp_ID", e.RowIndex].Value.ToString();
            dtp_trv_info_start_date.Value = Convert.ToDateTime(dataGridView2["trv_info_start_date", e.RowIndex].Value.ToString());
            tbx_trv_info_name.Text = dataGridView2["trv_info_name", e.RowIndex].Value.ToString();
            tbx_trv_info_price.Text = dataGridView2["trv_info_price", e.RowIndex].Value.ToString();
            tbx_trv_info_tel.Text = dataGridView2["trv_info_tel", e.RowIndex].Value.ToString();
            tbx_trv_info_Data.Text = dataGridView2["trv_info_Data", e.RowIndex].Value.ToString();
            byte[] iamge = (byte[])dataGridView2["trv_info_img", e.RowIndex].Value;
            MemoryStream ms = new MemoryStream(iamge);
            ptb_trv_info_img.Image = Image.FromStream(ms);
            ptb_trv_info_img.Tag = iamge;
        }
        #endregion

        #region Travel_info 이미지 설정
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images Files(*.jpg;*.gif;*.jpeg;*.png;*.bmp)|*.jpg;*.gif;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] image = br.ReadBytes((int)fs.Length);
            ptb_trv_info_img.Image = Image.FromStream(fs);
            ptb_trv_info_img.Tag = image;
            br.Close();
            fs.Close();
        }
        #endregion

        #region Travel_info 추가
        private void button4_Click(object sender, EventArgs e)
        {
            Travel_info temp = new Travel_info();
            temp.bus_ID = cbx_bus_ID.SelectedValue.ToString();
            temp.bus_emp_ID = cbx_bus_emp_ID.SelectedValue.ToString();
            temp.guid_emp_ID = cbx_guid_emp_ID.SelectedValue.ToString();
            temp.trv_info_start_date = dtp_trv_info_start_date.Value.ToString("yyyy-MM-dd");
            temp.trv_info_name = tbx_trv_info_name.Text;
            temp.trv_info_price = tbx_trv_info_price.Text;
            temp.trv_info_tel = tbx_trv_info_tel.Text;
            temp.trv_info_Data = tbx_trv_info_Data.Text;
            temp.trv_info_img = (byte[])ptb_trv_info_img.Tag;

            Travel_infoDB db = new Travel_infoDB();
            db.insert(temp);
            DataLoad();
        }
        #endregion

        #region Travel_info 수정
        private void button7_Click(object sender, EventArgs e)
        {
            Travel_info temp = new Travel_info();
            temp.trv_info_ID = tbx_trv_info_ID.Text;
            temp.bus_ID = cbx_bus_ID.SelectedValue.ToString();
            temp.bus_emp_ID = cbx_bus_emp_ID.SelectedValue.ToString();
            temp.guid_emp_ID = cbx_guid_emp_ID.SelectedValue.ToString();
            temp.trv_info_start_date = dtp_trv_info_start_date.Value.ToString("yyyy-MM-dd");
            temp.trv_info_name = tbx_trv_info_name.Text;
            temp.trv_info_price = tbx_trv_info_price.Text;
            temp.trv_info_tel = tbx_trv_info_tel.Text;
            temp.trv_info_Data = tbx_trv_info_Data.Text;
            temp.trv_info_img = (byte[])ptb_trv_info_img.Tag;

            Travel_infoDB db = new Travel_infoDB();
            db.update(temp);
            DataLoad();
        }

        #endregion


        #region Travel_info 삭제
        private void button6_Click(object sender, EventArgs e)
        {
            Travel_info temp = new Travel_info();
            temp.trv_info_ID = tbx_trv_info_ID.Text;

            Travel_infoDB db = new Travel_infoDB();
            db.delete(temp);
            DataLoad();
        }

        #endregion

        #endregion

        #region Travel 이벤트

        #region Travel 갱신
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor Cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int Max = 0;
                String URLString = "https://tour.chungnam.go.kr/_prog/openapi/?func=tour&mode=getCnt";
                XmlTextReader reader = new XmlTextReader(URLString);

                while (reader.Read())
                {
                    if (reader.Name == "totalCnt" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        Max = Convert.ToInt32(reader.Value);
                    }
                }
                // 본래는 max데이터를 불러서 확인해야하지만 중간에 오류가 나는 데이터가 있으므로 75까지
                URLString = "https://tour.chungnam.go.kr/_prog/openapi/?func=tour&start=1&end=" + 75.ToString();
                reader = new XmlTextReader(URLString);

                List<Travel> travels = new List<Travel>();
                Travel temp = new Travel();
                //이 사이트 xml 데이터 관리가 똥이라 1~75 까지밖에 안됩니다. 
                //error on line 1095 at column 28: Input is not proper UTF-8, indicate encoding !
                //Bytes: 0x0B 0x2D 0x20 0xEA  해당 오류 구문임니다
                while (reader.Read())
                {
                    if (reader.Name == "mng_no" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_ID = reader.Value;

                    }
                    if (reader.Name == "addr" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_addr = reader.Value;
                    }
                    if (reader.Name == "nm" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_name = reader.Value;
                    }
                    if (reader.Name == "lat" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_lat = Convert.ToDouble(reader.Value);
                    }
                    if (reader.Name == "lng" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_lng = Convert.ToDouble(reader.Value);
                    }
                    if (reader.Name == "tel" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_tel = reader.Value;
                    }
                    if (reader.Name == "desc" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_data = reader.Value;
                    }
                    if (reader.Name == "list_img" && reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        temp.trv_img = reader.Value;
                        travels.Add(temp);
                        temp = new Travel();
                    }
                }

                TravelDB db = new TravelDB();
                db.ListTravelSet(travels);
                db.Dispose();
                travelDataLoad();
            }
            finally
            {
                this.Cursor = Cursor;
            }

        }
        #endregion

        #region Travel 검색
        private void tbx_cherch_Click(object sender, EventArgs e)
        {
            if (tbx_Max.Text == string.Empty || tbx_Min.Text == string.Empty)
                return;
            TravelDB db = new TravelDB();
           dataGridView3.DataSource = db.SelectSerch(tbx_Max.Text, tbx_Min.Text);
        }
        #endregion

        #region Travel dgv 더블클릭
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            Bitmap bitmap = CommonUtil.WebImageView(dataGridView3["trv_img", e.RowIndex].Value.ToString().Replace("http", "https"));
            MemoryStream ms = new MemoryStream();   // 초기화
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Image image = Image.FromStream(ms);
            pictureBox1.Image = image;
        }
        #endregion

        #endregion

        #endregion

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
