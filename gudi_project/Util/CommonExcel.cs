using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace gudi_project
{
    public class CommonExcel
    {
        public Cursor Cursor { get;  set; }

        public void ImportDatatoExcelonOleDb(DataTable dt, DataGridView dgv)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls|Excel Files(*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Cursor currentCursor = null;
                if (this.Cursor != null)
                    currentCursor = this.Cursor;
                try
                {
                    if (this.Cursor != null)
                        this.Cursor = Cursors.WaitCursor;
                    string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                    string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

                    string fileName = dlg.FileName;
                    string fileExtension = System.IO.Path.GetExtension(fileName);
                    string strConn = string.Empty;
                    string sheetName = string.Empty;

                    switch (fileExtension)
                    {
                        case ".xls":
                            strConn = string.Format(Excel03ConString, fileName, "Yes");
                            break;
                        case ".xlsx":
                            strConn = string.Format(Excel07ConString, fileName, "Yes");
                            break;
                    }
                    //첫번째 Sheet 명을 가져옮

                    OleDbConnection conn = new OleDbConnection(strConn);
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    conn.Open();
                    DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                    conn.Close();

                    conn.Open();
                    // 엑셀파일을 읽었을때 테이블명은 [Sheet$]
                    string sql = "select * from [" + sheetName + "]";
                    OleDbDataAdapter oda = new OleDbDataAdapter(sql, conn);
                    dt = new DataTable();
                    oda.Fill(1, 10000, dt);
                    conn.Close();

                    dgv.DataSource = dt;
                }
                finally
                {
                    if (Cursor != null)
                        this.Cursor = currentCursor;
                }
            }
        }

        public void ImportDatatoExcelnonOleDb(DataTable dt, DataGridView dgv)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls|Excel Files(*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Cursor currentCursor = null;
                if (this.Cursor != null)
                    currentCursor = this.Cursor;
                try
                {
                    if (this.Cursor != null)
                        this.Cursor = Cursors.WaitCursor;
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workBook = excelApp.Workbooks.Open(dlg.FileName);
                    Excel.Worksheet workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;

                    Excel.Range range = workSheet.UsedRange;
                    for (int row =3; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복 
                    {
                        DataRow drw = dt.NewRow();
                        for (int column = 1; column <= range.Columns.Count - 1; column++)
                        {
                            string str = (string)(range.Cells[row, column] as Excel.Range).Value2;
                            drw[column - 1] = str;
                        }
                        dt.Rows.Add(drw);
                    }
                    dgv.DataSource = dt;
                }
                finally
                {
                    if (Cursor != null)
                        this.Cursor = currentCursor;
                }
            }
        }

        public bool ExportDataToExcel(DataTable dt, string fileName,string tooltip)
        {
            Cursor currentCursor = null;
            if (this.Cursor != null)
                currentCursor = this.Cursor;
            try
            {
                if (this.Cursor != null)
                    this.Cursor = Cursors.WaitCursor;
                //파일 Export 저장

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlWorkBook.Sheets.Add();
                xlSheet.Name = dt.TableName;

                //엑셀파일 내용에 대한 설명
                xlSheet.Cells[1, 1] = tooltip;
                xlSheet.Range[xlSheet.Cells[1, 1], xlSheet.Cells[1, 5]].Merge();
                ((Excel.Range)xlSheet.Cells[1, 1]).EntireRow.RowHeight = 200;

                //타이틀
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    xlSheet.Cells[2, i + 1] = dt.Columns[i].ColumnName;
                    ((Excel.Range)xlSheet.Cells[2, i + 1]).Interior.Color = Excel.XlRgbColor.rgbGhostWhite;
                }

                //데이터
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        xlSheet.Cells[r + 3, i + 1] = dt.Rows[r][i].ToString();
                    }
                }
                xlSheet.Columns.AutoFit();
                //컬럼의 너비가 데이터길이에 따라서 자동조정

                xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);
                xlWorkBook.Close();
                xlApp.Quit();

                releaseObject(xlSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                if(Cursor != null)
                    this.Cursor = currentCursor;
                return true;
            }
            catch (Exception err)
            {
                if (Cursor != null)
                    this.Cursor = currentCursor;

                MessageBox.Show(err.Message);
                return false;
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
