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
