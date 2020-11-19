using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace gudi_project
{
    public class Code
    {
        public string code { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string pcode { get; set; }
    }

    public class CodeDB : IDisposable
    {
        MySqlConnection conn;

        public CodeDB()
        {
            conn = new MySqlConnection(); 
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn.Open();
        }

        #region 코드 select

        #region  모든 코드값
        public DataTable getAllCode()
        {
            try
            {
                string sql = "SELECT code, name, category, pcode FROM code";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                int count = da.Fill(dt);
                if (count == 0)
                    return null;
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region  카테고리 기준
        public DataTable getCategoryCode(string category)
        {
            try
            {
                string sql = "SELECT code, name FROM code where category = @category";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                setParameters(cmd, MySqlDbType.VarChar, "@category", category);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                int count = da.Fill(dt);
                if (count == 0)
                    return null;
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region  pcode 기준
        public DataTable getPcodeCode(string pcode)
        {
            try
            {
                string sql = "SELECT code, name FROM code where pcode = @pcode";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                setParameters(cmd, MySqlDbType.VarChar, "@pcode", pcode);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                int count = da.Fill(dt);
                if (count == 0)
                    return null;
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 코드값 기준
        public string GetCodeName(string code)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select name from code where code = @code;";

                setParameters(cmd, MySqlDbType.VarChar, "@code", code);

                string name = (string)cmd.ExecuteScalar();

                return name;
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        #endregion

        #region 코드 변경
        #region DataTable 기반 변경
        public void DtCodeSet(DataTable dt)
        {
            DataRow[] rows = dt.Select(null, null, DataViewRowState.Added);
            foreach (DataRow dr in rows)
            {
                Code item = SetCode(dr);
                Insert(item);
            }

            rows = dt.Select(null, null, DataViewRowState.ModifiedCurrent);
            foreach (DataRow dr in rows)
            {
                Code item = SetCode(dr);
                Update(item);
            }

            rows = dt.Select(null, null, DataViewRowState.Deleted);
            foreach (DataRow dr in rows)
            {
                Delete(dr["code", DataRowVersion.Original].ToString());
            }
        }

        public void ImportExlCodeSet(DataTable dt)
        {

            MySqlTransaction transaction = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand()
                {
                    CommandText = "delete from code;",
                    Connection = conn,
                    Transaction = transaction
                };
            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into code(code, name, category, pcode) values (@code, @name,@category, @pcode);";

                foreach (DataRow row in dt.Rows)
                {
                    cmd.Parameters.Clear();
                    Code code = SetCode(row);
                    setParameters(cmd, MySqlDbType.VarChar, "@code", code.code);
                    setParameters(cmd, MySqlDbType.VarChar, "@name", code.name);
                    setParameters(cmd, MySqlDbType.VarChar, "@category", code.category);
                    setParameters(cmd, MySqlDbType.VarChar, "@pcode", code.pcode);

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

        }

        #endregion

        #region class 기반 변경
        public void Insert(Code item)
        {
            string sql = "insert into code(code, name, category, pcode) values (@code , @name, @category, @pcode);";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.VarChar, "@code", item.code);
            setParameters(cmd, MySqlDbType.VarChar, "@name", item.name);
            setParameters(cmd, MySqlDbType.VarChar, "@category", item.category);
            setParameters(cmd, MySqlDbType.VarChar, "@pcode", item.pcode);

            cmd.ExecuteNonQuery();
        }

        public void Update(Code item)
        {
            string sql = @"update code set name =  @name 
              , category = @category
              , pcode = @pcode
              where code = @code;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.VarChar, "@code", item.code);
            setParameters(cmd, MySqlDbType.VarChar, "@name", item.name);
            setParameters(cmd, MySqlDbType.VarChar, "@category", item.category);
            setParameters(cmd, MySqlDbType.VarChar, "@pcode", item.pcode);

            cmd.ExecuteNonQuery();
        }

        public void Delete(string item)
        {
            string sql = @"delete from code where code = @code;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.VarChar, "@code", item);

            cmd.ExecuteNonQuery();
        }

        public void Delete(List<Code> item)
        {
           MySqlTransaction Transaction = conn.BeginTransaction();

            string sql = @"delete from code where code = @code;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Transaction = Transaction;
            try
            {
                foreach (Code code in item)
                {
                    cmd.Parameters.Clear();
                    setParameters(cmd, MySqlDbType.VarChar, "@code", code.code);
                    cmd.ExecuteNonQuery();
                }
                Transaction.Commit();
            }
            catch (Exception err)
            {
                Transaction.Rollback();
            }
        }
        #endregion

        #endregion



        #region Row to Class
        public Code SetCode(DataRow dr)
        {
            return new Code()
            {
                code = dr["code"].ToString(),
                name = dr["name"].ToString(),
                category = dr["category"].ToString(),
                pcode = dr["pcode"].ToString()
            };
        }
        #endregion

        #region 파라미터 설정

        private void setParameters(MySqlCommand cmd, MySqlDbType type, string ParamName, string ParamValue)
        {
            cmd.Parameters.Add(ParamName, type);
            cmd.Parameters[ParamName].Value = ParamValue;
        }

        #endregion
        
        
        public void Dispose()
        {
            conn.Close();
        }
    }
}
