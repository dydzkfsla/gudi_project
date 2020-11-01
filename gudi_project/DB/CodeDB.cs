using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace gudi_project
{
    public class Code
    {
        public string code { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string stringpcode { get; set; }
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

        #region 코드 확인
        
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

        private void setParameters(MySqlCommand cmd, MySqlDbType type, string ParamName, string ParamValue)
        {
            cmd.Parameters.Add(ParamName, type);
            cmd.Parameters[ParamName].Value = ParamValue;
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
