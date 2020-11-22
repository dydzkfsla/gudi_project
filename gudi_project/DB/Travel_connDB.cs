using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace gudi_project
{
    public class Travel_conn
    {
        public string   trv_ID              {   get; set; }
        public string   trv_info_ID     {   get; set; }
    }

    public class Travel_connDB :IDisposable
    {
        MySqlConnection conn = null;
        public Travel_connDB()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn.Open();
        }

        #region select
        public List<Travel_conn> select()
        {
            List<Travel_conn> travels = new List<Travel_conn>();
            string sql = "SELECT trv_ID, trv_info_ID FROM travel_conn;";
            MySqlCommand cmd = new MySqlCommand(sql ,conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Travel_conn temp = new Travel_conn();
                temp.trv_ID = reader.GetString("trv_ID"); 
                temp.trv_info_ID = reader.GetString("trv_info_ID");
                travels.Add(temp);
            }

            return travels.Count == 0 ? null : travels;
        }
        #endregion

        #region insert
        public bool insert(string trv_ID, string trv_info_ID)
        {
            try
            {
                string sql = "insert into travel_conn(trv_ID, trv_info_ID) values (@trv_ID, @trv_info_ID);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.setParameters(MySqlDbType.VarChar, "@trv_ID", trv_ID);
                cmd.setParameters(MySqlDbType.VarChar, "@trv_info_ID", trv_info_ID);

                return cmd.ExecuteNonQuery() == 0 ? false : true;
            }
            catch(Exception err)
            {
                return false;
            }
        }

        #endregion

        #region delete
        public bool delete(string trv_ID, string trv_info_ID)
        {
            try
            {
                string sql = "delete from travel_conn where trv_ID = @trv_ID and trv_info_ID = @trv_info_ID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.setParameters(MySqlDbType.VarChar, "@trv_ID", trv_ID);
                cmd.setParameters(MySqlDbType.VarChar, "@trv_info_ID", trv_info_ID);

                return cmd.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        #endregion

        public void Dispose()
        {
            conn.Dispose();
        }
    }
}
