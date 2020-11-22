using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class Bus_Mast : Form
    {
        public Bus_Mast()
        {
            InitializeComponent();
        }

        private void Bus_Mast_Load(object sender, EventArgs e)
        {
            tbx_bus_info_left_seat.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_bus_info_back_seat.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_bus_info_line_seat.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_bus_info_reght_seat.KeyPress += UtilEvent.TextBoxIsDigit;


            EmployeesDB db = new EmployeesDB();
            DataTable dt = db.GetMechanicemployess();
            db.Dispose();

            cbx_emp_ID.DisplayMember = "emp_name";
            cbx_emp_ID.ValueMember = "emp_ID";
            cbx_emp_ID.DataSource = dt.AsDataView().ToTable();

            Bus_InfoDB Bdb = new Bus_InfoDB();
            dt = Bdb.Select();
            Bdb.Dispose();

            cbx_bus_info_ID.DataSource = dt.AsDataView().ToTable();
            cbx_bus_info_ID.ValueMember = "bus_info_ID";
            cbx_bus_info_ID.DisplayMember = "bus_info_ID";

            CodeDB cdb = new CodeDB();
            dt = cdb.getCategoryCode("BusState");
            DataTable make = cdb.getCategoryCode("BusMaker");
            cdb.Dispose();

            SetCodeForCbx(cbx_bus_in_name, dt);
            SetCodeForCbx(cbx_bus_info_make_name, make);

            SetDgv();
            DataLoad();
        }


        #region private 메서드
        private void SetDgv()
        {
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.SetInitGridView(dataGridView2);

            CommonUtil.AddGridTextColumn(dataGridView1, "bus_ID", "bus_ID");
            CommonUtil.AddGridTextColumn(dataGridView1, "emp_ID", "emp_ID", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "emp_name", "emp_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "bus_info_ID", "bus_info_ID");
            CommonUtil.AddGridTextColumn(dataGridView1, "bus_from_date", "bus_from_date");
            CommonUtil.AddGridTextColumn(dataGridView1, "bus_in_code", "bus_in_code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "bus_in_name", "bus_in_name");


            CommonUtil.AddGridTextColumn(dataGridView2, "bus_info_ID", "bus_info_ID");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_info_make_code", "bus_info_make_code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_info_model_code", "bus_info_model_code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView2, "make_name", "make_name");
            CommonUtil.AddGridTextColumn(dataGridView2, "model_name", "model_name");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_info_reght_seat", "bus_info_reght_seat");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_info_left_seat", "bus_info_left_seat");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_info_back_seat", "bus_info_back_seat");
            CommonUtil.AddGridTextColumn(dataGridView2, "bus_info_line_seat", "bus_info_line_seat");
        }

        private void DataLoad()
        {
            BusDB Busdb = new BusDB();
            DataTable dt = Busdb.Select();
            dataGridView1.DataSource = dt;

            Bus_InfoDB infodb = new Bus_InfoDB();
            dt = infodb.SelectJoinCode();
            dataGridView2.DataSource = dt;

            EmployeesDB db = new EmployeesDB();
            dt = db.GetMechanicemployess();

        }

        private void SetCodeForCbx(ComboBox cbx, DataTable dt)
        {
            cbx.ValueMember = "code";
            cbx.DisplayMember = "name";
            cbx.DataSource = dt.AsDataView().ToTable();
        }

        #endregion

        #region 이벤트

        #region bus 관련 이벤트
        #region bus dgv 더블클릭
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            tbx_bus_ID.Text = dataGridView1["bus_ID", e.RowIndex].Value.ToString();
            cbx_emp_ID.SelectedValue = dataGridView1["emp_ID", e.RowIndex].Value.ToString();
            cbx_bus_in_name.SelectedValue = dataGridView1["bus_in_code", e.RowIndex].Value.ToString();
            cbx_bus_info_ID.SelectedValue = dataGridView1["bus_info_ID", e.RowIndex].Value.ToString();
            dtp_From.Value = Convert.ToDateTime(dataGridView1["bus_from_date", e.RowIndex].Value.ToString());
        }
        #endregion

        #region bus 추가
        private void button1_Click(object sender, EventArgs e)
        {
            Bus bus = new Bus();

            bus.emp_ID = cbx_emp_ID.SelectedValue.ToString();
            bus.bus_info_ID = cbx_bus_info_ID.SelectedValue.ToString();
            bus.bus_from_date = dtp_From.Value.ToString("yyyy-MM-dd");
            bus.bus_in_code = cbx_bus_in_name.SelectedValue.ToString();

            BusDB db = new BusDB();
            db.insert(bus);
            db.Dispose();

            DataLoad();
        }
        #endregion

        #region bus 수정
        private void button2_Click(object sender, EventArgs e)
        {
            Bus bus = new Bus();

            bus.bus_ID = tbx_bus_ID.Text.Trim();
            bus.emp_ID = cbx_emp_ID.SelectedValue.ToString();
            bus.bus_info_ID = cbx_bus_info_ID.SelectedValue.ToString();
            bus.bus_from_date = dtp_From.Value.ToString("yyyy-MM-dd");
            bus.bus_in_code = cbx_bus_in_name.SelectedValue.ToString();


            BusDB db = new BusDB();
            db.update(bus);
            db.Dispose();
            DataLoad();
        }
        #endregion

        #region bus 삭제
        private void button3_Click(object sender, EventArgs e)
        {
            Bus bus = new Bus();

            bus.bus_ID = tbx_bus_ID.Text.Trim();

            BusDB db = new BusDB();
            db.delete(bus);
            db.Dispose();
            DataLoad();
        }
        #endregion
        #endregion

        #region bus_info 관련 이벤트

        #region Make 선택에 따른 model변경 이벤트
        private void cbx_bus_info_make_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            if (cbx.Text == "")
                return;
            CodeDB cdb = new CodeDB();
            DataTable model = cdb.getPcodeCode(cbx.SelectedValue.ToString());
            cdb.Dispose();
            SetCodeForCbx(cbx_bus_info_model_name, model);
        }
        #endregion

        #region dgv_bus_info_더블클릭 이벤트
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            tbx_bus_info_ID.Text = dataGridView2["bus_info_ID", e.RowIndex].Value.ToString();
            tbx_bus_info_left_seat.Text = dataGridView2["bus_info_left_seat", e.RowIndex].Value.ToString();
            tbx_bus_info_reght_seat.Text = dataGridView2["bus_info_reght_seat", e.RowIndex].Value.ToString();
            tbx_bus_info_line_seat.Text = dataGridView2["bus_info_line_seat", e.RowIndex].Value.ToString();
            tbx_bus_info_back_seat.Text = dataGridView2["bus_info_back_seat", e.RowIndex].Value.ToString();
            cbx_bus_info_make_name.SelectedValue = dataGridView2["bus_info_make_code", e.RowIndex].Value.ToString();
            cbx_bus_info_model_name.SelectedValue = dataGridView2["bus_info_model_code", e.RowIndex].Value.ToString();

        }
        #endregion

        #region 추가
        private void button4_Click(object sender, EventArgs e)
        {
            Bus_Info bus_Info = new Bus_Info();
            bus_Info.bus_info_ID = tbx_bus_info_ID.Text;
            bus_Info.bus_info_left_seat = int.Parse(tbx_bus_info_left_seat.Text);
            bus_Info.bus_info_reght_seat = int.Parse(tbx_bus_info_reght_seat.Text);
            bus_Info.bus_info_line_seat = int.Parse(tbx_bus_info_line_seat.Text);
            bus_Info.bus_info_back_seat = int.Parse(tbx_bus_info_back_seat.Text);
            bus_Info.bus_info_make_code = cbx_bus_info_make_name.SelectedValue.ToString();
            bus_Info.bus_info_model_code = cbx_bus_info_model_name.SelectedValue.ToString();

            Bus_InfoDB db = new Bus_InfoDB();
            db.insert(bus_Info);
            db.Dispose();
            DataLoad();
        }
        #endregion

        #region 수정
        private void button6_Click(object sender, EventArgs e)
        {
            if (tbx_bus_info_ID.Text == string.Empty)
                return;
            Bus_Info bus_Info = new Bus_Info();
            bus_Info.bus_info_ID = tbx_bus_info_ID.Text;
            bus_Info.bus_info_left_seat = int.Parse(tbx_bus_info_left_seat.Text);
            bus_Info.bus_info_reght_seat = int.Parse(tbx_bus_info_reght_seat.Text);
            bus_Info.bus_info_line_seat = int.Parse(tbx_bus_info_line_seat.Text);
            bus_Info.bus_info_back_seat = int.Parse(tbx_bus_info_back_seat.Text);
            bus_Info.bus_info_make_code = cbx_bus_info_make_name.SelectedValue.ToString();
            bus_Info.bus_info_model_code = cbx_bus_info_model_name.SelectedValue.ToString();

            Bus_InfoDB db = new Bus_InfoDB();
            db.update(bus_Info);
            db.Dispose();
            DataLoad();
        }
        #endregion

        #region 삭제
        private void button5_Click(object sender, EventArgs e)
        {
            if (tbx_bus_info_ID.Text == string.Empty)
                return;
            Bus_Info bus_Info = new Bus_Info();
            bus_Info.bus_info_ID = tbx_bus_info_ID.Text;
            bus_Info.bus_info_left_seat = int.Parse(tbx_bus_info_left_seat.Text);
            bus_Info.bus_info_reght_seat = int.Parse(tbx_bus_info_reght_seat.Text);
            bus_Info.bus_info_line_seat = int.Parse(tbx_bus_info_line_seat.Text);
            bus_Info.bus_info_back_seat = int.Parse(tbx_bus_info_back_seat.Text);
            bus_Info.bus_info_make_code = cbx_bus_info_make_name.SelectedValue.ToString();
            bus_Info.bus_info_model_code = cbx_bus_info_model_name.SelectedValue.ToString();

            Bus_InfoDB db = new Bus_InfoDB();
            db.delete(bus_Info);
            db.Dispose();
            DataLoad();
        }
        #endregion

        #endregion

        #endregion
    }
}
