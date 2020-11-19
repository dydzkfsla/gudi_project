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
        DataTable AllEmpt = null;

        public Employees_Mast()
        {
            InitializeComponent();
        }

        private void Employees_Mast_Load(object sender, EventArgs e)
        {
            tbx_Empt_salary01.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_Empt_ID01.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_Empt_name01.KeyPress += UtilEvent.TextBoxNoIsDigit;

            tbx_emp_Up_ID01.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_emp_Up_salary01.KeyPress += UtilEvent.TextBoxIsDigit;
            tbx_emp_Up_Name01.KeyPress += UtilEvent.TextBoxNoIsDigit;

            dtp_Empt_to_data_01.Value = dtp_Empt_from_data_01.Value = DateTime.Now;
            SetControls();
            dataLoad();
        }


        #region private 메서드
        private void SetControls()
        {
            SetDgv(dgv_employees_All);
            SetDgv(dgv_employees01);
            SetDgv(dgv_employees02);

            #region dgv 무명 매서드
            dgv_employees01.CellDoubleClick += (a, b) => TabControls.SelectedIndex = 0;
            dgv_employees02.CellDoubleClick += (obj, evnt) =>
            {
                int row = evnt.RowIndex;
                if (row == -1)
                    return;
                tbx_Empt_ID02.Text = dgv_employees02["emp_ID", evnt.RowIndex].Value.ToString();
                dept_emp_Up_to_date02.Value = Convert.ToDateTime(dgv_employees02["emp_to_date", evnt.RowIndex].Value.ToString());
            };
            #endregion


            CodeDB cdb = new CodeDB();
            DataTable Manager = cdb.getCategoryCode("매니저 여부");
            DataTable DeptName = cdb.getCategoryCode("DeptName");
            cdb.Dispose();

            DataRow Mrow = Manager.insertRow();
            DataRow Drow = DeptName.insertRow();

            Mrow["code"] = string.Empty;
            Mrow["name"] = string.Empty;
            Drow["code"] = string.Empty;
            Drow["name"] = string.Empty;

            SetCombBox(cbx_mgr_code01, Manager);
            SetCombBox(cbx_dep_code01, DeptName);
            SetCombBox(cbx_emp_Up_mgr01, Manager.AsDataView().ToTable());
            SetCombBox(cbx_emp_Up_dep01, DeptName.AsDataView().ToTable());


        }

        private void SetCombBox(ComboBox cbx, DataTable table)
        {
            cbx.DisplayMember = "name";
            cbx.ValueMember = "code";
            cbx.DataSource = table;
        }

        private void SetDgv(DataGridView dgv)
        {
            CommonUtil.SetInitGridView(dgv);
            //code, name, category, pcode
            CommonUtil.AddGridCheckColumn(dgv, "    Delete", "Delete", 100);
            CommonUtil.AddGridTextColumn(dgv, "emp_ID", "emp_ID", 80);
            CommonUtil.AddGridTextColumn(dgv, "emp_name", "emp_name", 100);
            CommonUtil.AddGridTextColumn(dgv, "emp_from_date", "emp_from_date", 150);
            CommonUtil.AddGridTextColumn(dgv, "emp_to_date", "emp_to_date", 150);
            CommonUtil.AddGridTextColumn(dgv, "emp_salary", "emp_salary", 100);
            CommonUtil.AddGridTextColumn(dgv, "emp_mgr_name", "mgrname", 150);
            CommonUtil.AddGridTextColumn(dgv, "emp_dep_name", "depname", 150);

            CommonUtil.AddGridTextColumn(dgv, "emp_mgr_code", "emp_mgr_code", 1, false);
            CommonUtil.AddGridTextColumn(dgv, "emp_dep_code", "emp_dep_code", 1, false);
        }

        private void dataLoad()
        {
            EmployeesDB db = new EmployeesDB();
            AllEmpt = db.GetAllemployess();
            if (AllEmpt == null)
                return;
            dgv_employees_All.DataSource = AllEmpt;
            Setdgv_empt_0102();
            AllEmpt.AcceptChanges();
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

            foreach (DataGridViewRow rw in dgv_employees01.Rows)
            {
                rw.Cells[0].Value = false;
            }
        }

        private void Setdgv_empt_0102()
        {
            DataView dv = ((DataTable)dgv_employees_All.DataSource).AsDataView();
            dv.RowFilter = "emp_to_date >= #9999-12-30#";
            dgv_employees01.DataSource = dv.ToTable();

            dv.RowFilter = "emp_to_date NOT IN (#9999-12-30#)";
            dgv_employees02.DataSource = dv.ToTable();
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

        #region 그리드 삭제 박스 더블클릭
        private void dgv_employees_All_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            CheckBox ckb = (CheckBox)dgv.Tag;
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (row == -1 || col != 0)
                return;
            foreach (DataGridViewRow dgvrow in dgv.Rows)
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

        #region all데이터 그리드 더블클릭
        private void dgv_employees_All_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int row = e.RowIndex;
            if (row == -1)
                return;
            tbx_emp_Up_ID01.Text = dgv["emp_ID", e.RowIndex].Value.ToString();
            tbx_emp_Up_Name01.Text = dgv["emp_name", e.RowIndex].Value.ToString();
            tbx_emp_Up_salary01.Text = dgv["emp_salary", e.RowIndex].Value.ToString();
            cbx_emp_Up_dep01.SelectedValue = dgv["emp_dep_code", e.RowIndex].Value.ToString();
            cbx_emp_Up_mgr01.SelectedValue = dgv["emp_mgr_code", e.RowIndex].Value.ToString();
            dept_emp_Up_to_date01.Value = Convert.ToDateTime(dgv["emp_from_date", e.RowIndex].Value.ToString());
        }
        #endregion

        #region all 데이터 검색 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            bool result = false;
            DataTable data = AllEmpt;
            DataView dv = data.AsDataView();
            StringBuilder builder = new StringBuilder();
            if (tbx_Empt_ID01.Text.Trim() != string.Empty)
            {
                result = true;
                builder.Append("emp_ID = ");
                builder.Append(tbx_Empt_ID01.Text.Trim() + " AND ");
            }
            if (tbx_Empt_name01.Text.Trim() != string.Empty)
            {
                result = true;
                builder.Append("emp_name like '%");
                builder.Append(tbx_Empt_name01.Text.Trim() + "%' AND ");
            }
            if (tbx_Empt_name01.Text.Trim() != string.Empty)
            {
                result = true;
                builder.Append("emp_name like '%");
                builder.Append(tbx_Empt_name01.Text.Trim() + "%' AND ");
            }
            if (dtp_Empt_to_data_01.Value != dtp_Empt_from_data_01.Value)
            {
                result = true;
                builder.Append(" (emp_from_date >= #");
                builder.Append(Convert.ToDateTime(dtp_Empt_from_data_01.Value).ToString("yyyy-MM-dd"));
                builder.Append("# And emp_from_date <= #");
                builder.Append(Convert.ToDateTime(dtp_Empt_to_data_01.Value).ToString("yyyy-MM-dd"));
                builder.Append("#)  AND ");
            }
            if (tbx_Empt_salary01.Text.Trim() != string.Empty)
            {
                result = true;
                if (Salay_Toggle01.Toggled == true)
                {
                    builder.Append(" emp_salary >= ");
                    builder.Append(tbx_Empt_salary01.Text.Trim() + " AND ");
                }
                else
                {
                    builder.Append(" emp_salary <= ");
                    builder.Append(tbx_Empt_salary01.Text.Trim() + " AND ");
                }
            }
            if ((string)cbx_dep_code01.SelectedValue != string.Empty)
            {
                result = true;
                builder.Append(" emp_dep_code = '");
                builder.Append((string)cbx_dep_code01.SelectedValue + "' AND ");
            }

            if ((string)cbx_mgr_code01.SelectedValue != string.Empty)
            {
                result = true;
                builder.Append(" emp_mgr_code = '");
                builder.Append((string)cbx_mgr_code01.SelectedValue + "' AND ");
            }
            if (result)
            {
                string Filter = builder.ToString();
                Filter = Filter.Substring(0, Filter.LastIndexOf("AND"));

                dv.RowFilter = Filter;
            }
            dgv_employees_All.DataSource = dv.ToTable();
            Setdgv_empt_0102();
        }


        #endregion

        #region all 데이터 수정 버튼
        private void button3_Click(object sender, EventArgs e)
        {

            if (tbx_emp_Up_ID01.Text == string.Empty)
                return;
            employees emp = new employees();
            emp.emp_ID = tbx_emp_Up_ID01.Text;
            emp.emp_name = tbx_emp_Up_Name01.Text.Trim();
            emp.emp_salary = tbx_emp_Up_salary01.Text.Trim();
            emp.emp_from_date = dept_emp_Up_to_date01.Value.ToString("yyyy-MM-dd");
            emp.emp_dep_code = cbx_emp_Up_dep01.SelectedValue.ToString();
            emp.emp_mgr_code = cbx_emp_Up_mgr01.SelectedValue.ToString();


            EmployeesDB db = new EmployeesDB();

            db.update(emp);
            db.Dispose();
            dataLoad();
        }
        #endregion

        #region 퇴사 확인

        private void button2_Click(object sender, EventArgs e)
        {
            string emp_ID = tbx_emp_Up_ID01.Text.Trim();
            if (emp_ID == string.Empty)
                return;
            EmployeesDB db = new EmployeesDB();
            db.updateTodateNow(emp_ID);
            dataLoad();
        }
        #endregion

        #region 입사
        private void button5_Click(object sender, EventArgs e)
        {
            if (tbx_emp_Up_Name01.Text.Trim() == string.Empty || tbx_emp_Up_salary01.Text.Trim() == string.Empty ||
                dept_emp_Up_to_date01.Value.ToString("yyyy-MM-dd") == string.Empty || cbx_emp_Up_dep01.SelectedValue.ToString() == string.Empty ||
                cbx_emp_Up_mgr01.SelectedValue.ToString() == string.Empty)
                return;

            employees emp = new employees();
            emp.emp_name = tbx_emp_Up_Name01.Text.Trim();
            emp.emp_salary = tbx_emp_Up_salary01.Text.Trim();
            emp.emp_from_date = dept_emp_Up_to_date01.Value.ToString("yyyy-MM-dd");
            emp.emp_to_date = "9999-12-30";
            emp.emp_dep_code = cbx_emp_Up_dep01.SelectedValue.ToString();
            emp.emp_mgr_code = cbx_emp_Up_mgr01.SelectedValue.ToString();

            EmployeesDB db = new EmployeesDB();
            db.insert(emp);
            db.Dispose();

            dataLoad();
        }
        #endregion

        #region 삭제
        private void button4_Click(object sender, EventArgs e)
        {
            employees employees = new employees();
            if (tbx_emp_Up_ID01.Text.Trim() == string.Empty)
                return;
            employees.emp_ID = tbx_emp_Up_ID01.Text.Trim();

            EmployeesDB db = new EmployeesDB();
            db.delete(employees);
            db.Dispose();

            dataLoad();

        }


        #endregion

        #region 엑셀
        #region 엑셀 Export
        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            CommonExcel excel = new CommonExcel();
            excel.Cursor = this.Cursor;
            dlg.Filter = "Excel File(*.xls)|*.xls";
            dlg.Title = "엑셀파일로 내보내기";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            AllEmpt.TableName = "employees";
            string toltip = $@"emp_ID: 직원의 고유 번호
                            {System.Environment.NewLine}emp_name: 직원의 이름
                            {System.Environment.NewLine}emp_from_date:  직원 입사일
                            {System.Environment.NewLine}emp_to_date: 원 퇴사일
                            {System.Environment.NewLine}emp_salary: 직원의 월급
                            {System.Environment.NewLine}emp_mgr_code:  직원 매니저 유무
                            {System.Environment.NewLine}emp_dep_code: 직원 부서";
            if (excel.ExportDataToExcel(AllEmpt, dlg.FileName, toltip))
            {
                MessageBox.Show("엑셀파일에 저장하였습니다.");
            }
        }

        #endregion

        #region 엑셀 import
        private void button9_Click(object sender, EventArgs e)
        {
            DataTable ndt = new DataTable();
            CommonExcel excel = new CommonExcel();
            ndt.Columns.Clear();
            //emp_ID, emp_name, emp_from_date, emp_to_date, emp_salary, emp_mgr_code, emp_dep_code
            ndt.Columns.Add(new DataColumn("emp_ID", typeof(string)));
            ndt.Columns.Add(new DataColumn("emp_name", typeof(string)));
            ndt.Columns.Add(new DataColumn("emp_from_date", typeof(string)));
            ndt.Columns.Add(new DataColumn("emp_to_date", typeof(string)));
            ndt.Columns.Add(new DataColumn("emp_salary", typeof(string)));
            ndt.Columns.Add(new DataColumn("emp_mgr_code", typeof(string)));
            ndt.Columns.Add(new DataColumn("emp_dep_code", typeof(string)));
            ndt.Columns.Add(new DataColumn("mgrname", typeof(string)));
            ndt.Columns.Add(new DataColumn("depname", typeof(string)));
            excel.Cursor = this.Cursor;
            excel.ImportDatatoExcelnonOleDb(ndt, dgv_xls_employees);
            //dgv_xls_employees.DataSource = ndt;
        }
        #endregion

        #region 엑셀 저장
        private void button10_Click(object sender, EventArgs e)
        {
            if (dgv_xls_employees.DataSource == null)
                return;
            DataTable table = (DataTable)(dgv_xls_employees.DataSource);

            EmployeesDB db = new EmployeesDB();
            db.AllDataImportExcel(table);
            db.Dispose();
            dataLoad();
        }
        #endregion

        #endregion

        #region 퇴사 취소
        private void button7_Click(object sender, EventArgs e)
        {
            string emp_ID = tbx_Empt_ID02.Text.Trim();
            if (emp_ID == string.Empty)
                return;
            EmployeesDB db = new EmployeesDB();
            db.updateTodateBreak(emp_ID);
            db.Dispose();
            dataLoad();

        }
        #endregion

        #region 퇴사일 변경
        private void button8_Click(object sender, EventArgs e)
        {
            if (tbx_Empt_ID02.Text.Trim() == string.Empty)
                return;
            employees employees = new employees();
            employees.emp_ID = tbx_Empt_ID02.Text.Trim();
            employees.emp_to_date = dept_emp_Up_to_date02.Value.ToString("yyyy-MM-dd");

            EmployeesDB db = new EmployeesDB();
            db.updateTodate(employees);
            db.Dispose();
            dataLoad();
        }
        #endregion

        #endregion

    }
}
