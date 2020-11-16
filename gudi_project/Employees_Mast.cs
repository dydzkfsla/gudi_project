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
    public partial class Employees_Mast : Form
    {
        DataTable dt = null;

        public Employees_Mast()
        {
            InitializeComponent();
        }

        private void Employees_Mast_Load(object sender, EventArgs e)
        {
            SetControls();
            dataLoad();
        }


        #region private 메서드
        private void SetControls()
        {
            CommonUtil.SetInitGridView(dgv_employees_All);
            //code, name, category, pcode
            CommonUtil.AddGridCheckColumn(dgv_employees_All, "    Delete", "Delete", 100);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_ID", "emp_ID", 80);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_name", "emp_name", 100);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_from_date", "emp_from_date", 150);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_to_date", "emp_to_date", 150);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_salary", "emp_salary",  100);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_mgr_name", "mgrname", 100);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_dep_name", "depname", 100);

            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_mgr_code", "emp_mgr_code", 1 , false);
            CommonUtil.AddGridTextColumn(dgv_employees_All, "emp_dep_code", "emp_dep_code", 1, false);


            cbx_mgr_code01.DisplayMember = "mgrname";
            cbx_mgr_code01.ValueMember = "emp_mgr_code";

            cbx_dep_code01.DisplayMember = "depname";
            cbx_dep_code01.ValueMember = "emp_dep_code";


            //CommonUtil.SetInitGridView(dataGridView2);
            ////code, name, category, pcode
            //CommonUtil.AddGridTextColumn(dataGridView2, "code", "code", 80);
            //CommonUtil.AddGridTextColumn(dataGridView2, "name", "name", 220);
            //CommonUtil.AddGridTextColumn(dataGridView2, "category", "category", 130);
            //CommonUtil.AddGridTextColumn(dataGridView2, "pcode", "pcode", 80);
            //cbx_xls_pcode.DisplayMember = "code";
            //cbx_xls_pcode.ValueMember = "code";

        }

        private void dataLoad()
        {
            EmployeesDB db = new EmployeesDB();
            dt = db.GetAllemployess();
            if (dt == null)
                return;
            DataTable temp = dt.AsDataView().ToTable();
            //temp.ToTable(true, "mgrname");
            DataRow row = temp.NewRow();
            DataView dv = temp.AsDataView();
            row["mgrname"] = string.Empty;
            row["emp_mgr_code"] = string.Empty;
            row["depname"] = string.Empty;
            row["emp_dep_code"] = string.Empty;
            temp.Rows.InsertAt(row, 0);
            dgv_employees_All.DataSource = dt;


            cbx_dep_code01.DataSource = dv.ToTable(true, "depname", "emp_dep_code");
            cbx_mgr_code01.DataSource = dv.ToTable(true, "mgrname", "emp_mgr_code");

            dt.AcceptChanges();
            db.Dispose();



            int x = dgv_employees_All.Rows[0].Cells[0].ContentBounds.X;
            int y = dgv_employees_All.Rows[0].Cells[0].ContentBounds.Y;
            CheckBox delete = new CheckBox();
            delete.Name = "delete";
            delete.Size = new System.Drawing.Size(15, 15);
            delete.Location = new System.Drawing.Point(x + 55, y + 10);
            tabPage1.Controls.Add(delete);
            delete.BringToFront();
            delete.CheckedChanged += Delete_CheckedChanged;
            dgv_employees_All.Tag = delete;
            delete.Tag = dgv_employees_All;

            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                rw.Cells[0].Value = false;
            }
        }
        #endregion

        #region 이벤트
        private void Delete_CheckedChanged(object sender, EventArgs e)
        {
            bool result = ((CheckBox)sender).Checked;
            DataGridView dgv = (DataGridView)((CheckBox)sender).Tag;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["Delete"]).Value = result;
            }
        }

        private void dgv_employees_All_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            CheckBox ckb = (CheckBox)dgv.Tag;
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (row == -1 || col != 0)
                return;
            foreach(DataGridViewRow dgvrow in dgv.Rows)
            {
                if (ckb.Checked)
                {
                    ckb.CheckedChanged -= Delete_CheckedChanged;
                    ckb.Checked = false;
                    ckb.CheckedChanged += Delete_CheckedChanged;
                }
            }
            dgv.EndEdit();
        }
        #endregion
    }
}
