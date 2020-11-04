using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class Bus_Info
    {

    }

    public class Bus_InfoDB : IDisposable
    {
        MySqlConnection conn = null;
        public Bus_InfoDB()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn.Open();
        }

        #region 좌석 갯수 확인
        public int BusSeat(string BusID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select bus_info_reght_seat, bus_info_left_seat, bus_info_back_seat, bus_info_line_seat
                from bus_info where bus_info_ID = 
                (SELECT bus_info_ID FROM gudi06.bus where bus_ID = @bus_ID);";
                setParameters(cmd, MySqlDbType.Int32, "@bus_ID", BusID);

                MySqlDataReader reader = cmd.ExecuteReader();

                int seatall = 0;
                if (reader.Read())
                {
                    int reght = reader.GetInt32("bus_info_reght_seat");
                    int left = reader.GetInt32("bus_info_left_seat");
                    int back = reader.GetInt32("bus_info_back_seat");
                    int line = reader.GetInt32("bus_info_line_seat");

                    seatall = (reght + left) * line + back;
                }
                return seatall;
            }catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return 0;
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
