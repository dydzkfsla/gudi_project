using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class seat
    {
        public string res_seat_ID { get; set; }
        public string res_ID { get; set; }
        public string res_seat_num { get; set; }
    }

    
    public class seatDB : IDisposable
    {
        MySqlConnection conn = null;

        public seatDB()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn.Open();
        }

        public List<seat> reseat(string trv_info_ID)
        {
            List<seat> seats = new List<seat>();
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = conn,
                CommandText = @"SELECT count(*) FROM gudi06.seat 
                                where res_ID = 
                                (select res_ID from reservation where trv_info_ID = @trv_info_ID);"
            };
            setParameters(cmd, MySqlDbType.Int32, "@trv_info_ID", trv_info_ID);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reader.GetInt32("res_seat_ID");
                reader.GetInt32("res_ID");
                reader.GetString("res_seat_num");
            }
        }

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
