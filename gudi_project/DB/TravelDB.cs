using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class Travel
    {
        public string trv_ID { get; set; }
        public string trv_name { get; set; }
        public string trv_addr { get; set; }
        public string trv_data { get; set; }
        public string trv_img { get; set; }
        public string trv_tel { get; set; }
        public double trv_lat { get; set; }
        public double trv_lng { get; set; }
    }

    public class TravelDB : IDisposable
    {
        MySqlConnection conn = null;

        public TravelDB()
        {
            conn = new MySqlConnection()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString
            };
            conn.Open();
        }

        public List<Travel> GetTravel(string trv_info_ID)
        {
            List<Travel> travels = new List<Travel>();


            try
            {
                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = @"select TC.trv_ID, TC.trv_info_ID, trv_name, trv_addr, trv_data, trv_img, trv_tel, trv_lat, trv_lng
                                from travel T join travel_conn TC JOIN travel_info TI
                                on T.trv_ID = TC.trv_ID 
                                AND TC.trv_info_ID = TI.trv_info_ID
                                where TC.trv_info_ID = @trv_info_ID; "
                };
                setParameters(cmd, MySqlDbType.Int32, "@trv_info_ID", trv_info_ID);


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Travel temp = new Travel();
                    temp.trv_ID = reader.GetInt32("trv_ID").ToString();
                    temp.trv_name = reader.GetString("trv_name");
                    temp.trv_addr = reader.GetString("trv_addr");
                    temp.trv_data = reader.GetString("trv_data");
                    temp.trv_img = reader.GetString("trv_img");
                    temp.trv_tel = reader.GetString("trv_tel");
                    temp.trv_lat = reader.GetDouble("trv_lat");
                    temp.trv_lng = reader.GetDouble("trv_lng");
                    travels.Add(temp);
                }

                return travels;
            }catch (Exception err)
            {
                Debug.WriteLine(err);
                return null;
            }

        }

       #region select
        public List<Travel> selectlimit()
        {
            string sql = "SELECT * FROM gudi06.travel limit 5";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);
            List<Travel> temp = new List<Travel>();

            foreach (DataRow dr in dt.Rows)
            {
                Travel travel = new Travel
                {
                    trv_ID = dr["trv_ID"].ToString(),
                    trv_name = dr["trv_name"].ToString(),
                    trv_addr = dr["trv_addr"].ToString(),
                    trv_data = dr["trv_data"].ToString(),
                    trv_img = dr["trv_img"].ToString(),
                    trv_tel = dr["trv_tel"].ToString(),
                    trv_lat = Convert.ToDouble(dr["trv_lat"]),
                    trv_lng = Convert.ToDouble(dr["trv_lng"])
                };
                temp.Add(travel);
            }

            return temp.Count == 0 ? null : temp;
        }

        public (int max, int min) selectMaxMin()
        {
            string sql = "SELECT max(trv_ID) as Max, min(trv_ID)  as Min FROM travel;";
            MySqlCommand da = new MySqlCommand(sql, conn);
            MySqlDataReader reader = da.ExecuteReader();
            (int max, int min) temp = (1,1);
            while (reader.Read())
            {
                temp.max = reader.GetInt32("Max");
                temp.min = reader.GetInt32("Min");
            }
            return temp;
        }

        public List<Travel> SelectSerch(string Max, string Min)
        {
            string sql = @"SELECT trv_ID, trv_name, trv_addr, trv_data, trv_img, trv_tel, trv_lat, trv_lng FROM travel
    where trv_ID >= @trv_IDMin and trv_ID <= @trv_IDMax; ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.setParameters(MySqlDbType.Int32, "@trv_IDMin", Min);
            cmd.setParameters(MySqlDbType.Int32, "@trv_IDMax", Max);

            MySqlDataReader reader = cmd.ExecuteReader();


            List<Travel> travels = new List<Travel>();
            while (reader.Read())
            {
                Travel temp = new Travel();
                temp.trv_ID = reader.GetString("trv_ID");
                temp.trv_addr = reader.GetString("trv_addr");
                temp.trv_data = reader.GetString("trv_data");
                temp.trv_img = reader.GetString("trv_img");
                temp.trv_name = reader.GetString("trv_name");
                temp.trv_tel = reader.GetString("trv_tel");
                temp.trv_lat = reader.GetDouble("trv_lat");
                temp.trv_lng = reader.GetDouble("trv_lng");
                travels.Add(temp);
            }

            return travels.Count == 0 ? null : travels;

        }

        public List<string> SelectIDList()
        {
            List<string> vs = new List<string>();
            string sql = "SELECT trv_ID FROM travel;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader =  cmd.ExecuteReader();
            while (reader.Read())
            {
                string trv_ID = reader.GetString("trv_ID");
                vs.Add(trv_ID);
            }

            return vs.Count == 0 ? null : vs;

        }
        #endregion

        #region 복합
        public bool ListTravelSet(List<Travel> travels)
        {
            MySqlTransaction MST = conn.BeginTransaction();

            try
            {
                string sql = "delete from travel;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.ExecuteNonQuery();

                cmd.CommandText = @"insert into travel(trv_ID, trv_name, trv_addr, trv_data, trv_img, trv_tel, trv_lat, trv_lng)
    values(@trv_ID, @trv_name, @trv_addr, @trv_data, @trv_img, @trv_tel, @trv_lat, @trv_lng);";

                travels.ForEach((travel) =>
                {
                    cmd.Parameters.Clear();
                    
                    cmd.setParameters(MySqlDbType.Int32, "@trv_ID", travel.trv_ID);
                    cmd.setParameters(MySqlDbType.VarChar, "@trv_name", travel.trv_name);
                    cmd.setParameters(MySqlDbType.VarChar, "@trv_addr", travel.trv_addr);
                    cmd.setParameters(MySqlDbType.VarChar, "@trv_data", travel.trv_data);
                    cmd.setParameters(MySqlDbType.VarChar, "@trv_img", travel.trv_img);
                    cmd.setParameters(MySqlDbType.VarChar, "@trv_tel", travel.trv_tel);
                    cmd.setParameters(MySqlDbType.Double, "@trv_lat", travel.trv_lat.ToString());
                    cmd.setParameters(MySqlDbType.Double, "@trv_lng", travel.trv_lng.ToString());

                    cmd.ExecuteNonQuery();

                });
                MST.Commit();
                return true;
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                MST.Rollback();
                return false;
            }
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
            conn.Dispose();
        }
    }
}
