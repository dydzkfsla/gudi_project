using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace gudi_project
{
    public partial class Code_Mast : Form
    {
        DataTable dt = null;
        CheckBox delete = null;
        public Code_Mast()
        {
            InitializeComponent();
        }

        private void Code_Mast_Load(object sender, EventArgs e)
        {
            SetControls();
            dataLoad();
;
        }

        private void SetControls()
        {
            CommonUtil.SetInitGridView(dataGridView1);
            //code, name, category, pcode
            CommonUtil.AddGridCheckColumn(dataGridView1,"    Delete", "Delete",  100);
            CommonUtil.AddGridTextColumn(dataGridView1, "code", "code", 80);
            CommonUtil.AddGridTextColumn(dataGridView1, "name", "name", 220);
            CommonUtil.AddGridTextColumn(dataGridView1, "category", "category", 130);
            CommonUtil.AddGridTextColumn(dataGridView1, "pcode", "pcode", 80);
            cbx_pcode.DisplayMember = "code";
            cbx_pcode.ValueMember = "code";


            CommonUtil.SetInitGridView(dataGridView2);
            //code, name, category, pcode
            CommonUtil.AddGridTextColumn(dataGridView2, "code", "code", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "name", "name", 220);
            CommonUtil.AddGridTextColumn(dataGridView2, "category", "category", 130);
            CommonUtil.AddGridTextColumn(dataGridView2, "pcode", "pcode", 80);
            cbx_xls_pcode.DisplayMember = "code";
            cbx_xls_pcode.ValueMember = "code";

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
            delete.Location = new System.Drawing.Point(x+ 55,y+ 10);
            tabPage1.Controls.Add(delete);
            delete.BringToFront();
            delete.CheckedChanged += Delete_CheckedChanged;

            foreach(DataGridViewRow rw in dataGridView1.Rows)
            {
                rw.Cells[0].Value = false;
            }
        }

        #region 이벤트

        #region 쓸모없는
        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            tbx_category.Width = splitContainer1.Panel2.Width - 6;
            tbx_code.Width = splitContainer1.Panel2.Width - 6;
            tbx_name.Width = splitContainer1.Panel2.Width - 6;
            cbx_pcode.Width = splitContainer1.Panel2.Width - 6;
        }
        #endregion

        #region dgv 더블클릭
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex == -1)
            {
                return;
            }

            tbx_code.Text = dgv["code", e.RowIndex].Value.ToString();
            tbx_name.Text = dgv["name", e.RowIndex].Value.ToString();
            tbx_category.Text = dgv["category", e.RowIndex].Value.ToString();
            cbx_pcode.SelectedValue = dgv["pcode", e.RowIndex].Value.ToString();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex == -1)
            {
                return;
            }

            tbx_xls_code.Text = dgv["code", e.RowIndex].Value.ToString();
            tbx_xls_name.Text = dgv["name", e.RowIndex].Value.ToString();
            tbx_xls_category.Text = dgv["category", e.RowIndex].Value.ToString();
            cbx_xls_pcode.SelectedValue = dgv["pcode", e.RowIndex].Value.ToString();
        }
        #endregion

        #region 액셀 내보내기
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            CommonExcel excel = new CommonExcel();
            excel.Cursor = this.Cursor;
            dlg.Filter = "Excel File(*.xls)|*.xls";
            dlg.Title = "엑셀파일로 내보내기";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            dt.TableName = "code";
            string toltip = $@"code: 저장될 code값
                            {System.Environment.NewLine}name: 코드의 표현 값
                            {System.Environment.NewLine}category:  어느 그룹에 속하는지
                            {System.Environment.NewLine}pcode: 상위 부모가 있을경우 부모 code";
            if (excel.ExportDataToExcel(dt , dlg.FileName, toltip))
            {
                MessageBox.Show("엑셀파일에 저장하였습니다.");
            }
        }
        #endregion

        #region 엑셀 들여오기
        private void button5_Click(object sender, EventArgs e)
        {
            DataTable ndt = new DataTable();
            CommonExcel excel = new CommonExcel();
            excel.Cursor = this.Cursor;
            ndt.Columns.Clear();
            ndt.Columns.Add(new DataColumn("code", typeof(string)));
            ndt.Columns.Add(new DataColumn("name", typeof(string)));
            ndt.Columns.Add(new DataColumn("category", typeof(string)));
            ndt.Columns.Add(new DataColumn("pcode", typeof(string)));
            excel.ImportDatatoExcelnonOleDb(ndt, dataGridView2);
            cbx_xls_pcode.DataSource = ndt;
        }

        #endregion

        #region 코드 추가
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (tbx_code.Text == string.Empty || tbx_name.Text == string.Empty || tbx_category.Text == string.Empty)
                return;

            Code item = new Code();
            item.code = tbx_code.Text;
            item.name = tbx_name.Text;
            item.category = tbx_category.Text;
            item.pcode = cbx_pcode.SelectedValue.ToString();
            foreach (DataRow row in dt.Rows)
            {
                if (row["code"].ToString()== item.code)
                {
                    return;
                }
            }
            CodeDB db = new CodeDB();
            db.Insert(item);
            dataLoad();
        }
        #endregion

        #region 코드 삭제
        private void button3_Click(object sender, EventArgs e)
        {
            List<Code> lscode = new List<Code>(); 
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ( (bool)((DataGridViewCheckBoxCell)row.Cells["Delete"]).Value  == true)
                {
                    Code code = new Code();
                    code.code = (string)row.Cells["code"].Value;
                    lscode.Add(code);
                }
            }

            CodeDB db = new CodeDB();
            db.Delete(lscode);
            db.Dispose();
            dataLoad();
        }
        #endregion

        #region 코드 수정
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["code"].ToString() == tbx_code.Text)
                {
                    row["name"] = tbx_name.Text;
                    row["category"] = tbx_category.Text;
                    row["pcode"] = cbx_pcode.SelectedValue;

                    CodeDB db = new CodeDB();
                    Code code = db.SetCode(row);
                    db.Update(code);
                    dataLoad();
                    return;
                }
            }
        }
        #endregion

        #region 메인 체크박스 체크
        private void Delete_CheckedChanged(object sender, EventArgs e)
        {
            bool result = ((CheckBox)sender).Checked;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["Delete"]).Value = result;
            }
        }
        #endregion

        #region 딜리트 개별 체크 시 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    if (delete.Checked)
                    {
                        delete.CheckedChanged -= Delete_CheckedChanged;
                        delete.Checked = false;
                        delete.CheckedChanged += Delete_CheckedChanged;
                    }
                }
            }
        }
        #endregion

        #region 엑셀 반영
        private void button8_Click(object sender, EventArgs e)
        {
            DataTable Exdt = (DataTable)dataGridView2.DataSource;
            if (Exdt == null)
                return;
            CodeDB db = new CodeDB();
            db.ImportExlCodeSet(Exdt);
            dataLoad();
        }
        #endregion

        #endregion

    }
}
