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
        public Employees_Mast()
        {
            InitializeComponent();
        }

        private void Employees_Mast_Load(object sender, EventArgs e)
        {
            SetControls();
        }
        private void SetControls()
        {
            CommonUtil.SetInitGridView(dgv_xls_employees);
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


            cbx_mgr_code01.DisplayMember = "emp_mgr_code";
            cbx_mgr_code01.ValueMember = "emp_mgr_code";

            cbx_dep_code01.DisplayMember = "emp_dep_code";
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
            CodeDB db = new CodeDB();
            dt = db.getAllCode();
            DataTable temp = db.getAllCode();
            if (temp == null)
                return;
            DataView dv = temp.AsDataView();
            DataRow row = dv.Table.NewRow();
            row["code"] = string.Empty;
            row["pcode"] = string.Empty;
            dv.Table.Rows.InsertAt(row, 0);
            dataGridView1.DataSource = dt;
            cbx_pcode.DataSource = dv;

            dt.AcceptChanges();
            dv.Table.AcceptChanges();
            db.Dispose();



            int x = dataGridView1.Rows[0].Cells[0].ContentBounds.X;
            int y = dataGridView1.Rows[0].Cells[0].ContentBounds.Y;
            delete = new CheckBox();
            delete.Name = "delete";
            delete.Size = new System.Drawing.Size(20, 20);
            delete.Location = new System.Drawing.Point(x + 55, y + 10);
            tabPage1.Controls.Add(delete);
            delete.BringToFront();
            delete.CheckedChanged += Delete_CheckedChanged;

            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                rw.Cells[0].Value = false;
            }
        }

    }
}
