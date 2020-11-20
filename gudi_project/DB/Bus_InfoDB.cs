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
    public class Bus_Info
    {
        public string bus_info_ID { get; set; }
        public string bus_info_make_code { get; set; }
        public string bus_info_model_code { get; set; }
        public int bus_info_reght_seat { get; set; }
        public int bus_info_left_seat { get; set; }
        public int bus_info_back_seat { get; set; }
        public int bus_info_line_seat { get; set; }
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

        #region select
        #region bus_info select
        public DataTable Select()
        {
            string sql = @"SELECT bus_info_ID
, bus_info_make_code, bus_info_model_code
, bus_info_reght_seat, bus_info_left_seat
, bus_info_back_seat, bus_info_line_seat FROM bus_info; ";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);

            return dt;
        }
        #endregion

        #region bus_info join code select
        public DataTable SelectJoinCode()
        {
            string sql = @"SELECT bus_info_ID
, bus_info_make_code, bus_info_model_code
, c1.name as make_name, c2.name as model_name
, bus_info_reght_seat, bus_info_left_seat
, bus_info_back_seat, bus_info_line_seat 
FROM bus_info join code c1 join code c2
on bus_info.bus_info_make_code = c1.code and bus_info.bus_info_model_code = c2.code ; ";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);

            return dt;
        }
        #endregion

        #endregion

        #region insert
        public bool insert(Bus_Info temp)
        {
            string sql = @"insert into bus_info(bus_info_make_code, bus_info_model_code, bus_info_reght_seat, bus_info_left_seat, bus_info_back_seat, bus_info_line_seat)
    values(@bus_info_make_code, @bus_info_model_code, @bus_info_reght_seat, @bus_info_left_seat, @bus_info_back_seat, @bus_info_line_seat)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.setParameters(MySqlDbType.VarChar, "@bus_info_make_code", temp.bus_info_make_code);
            cmd.setParameters(MySqlDbType.VarChar, "@bus_info_model_code", temp.bus_info_model_code);
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_reght_seat", temp.bus_info_reght_seat.ToString());
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_left_seat", temp.bus_info_left_seat.ToString());
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_back_seat", temp.bus_info_back_seat.ToString());
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_line_seat", temp.bus_info_line_seat.ToString());

            return cmd.ExecuteNonQuery() == 0 ? false : true;
            
        }
        #endregion

        #region update
        public bool update(Bus_Info temp)
        {
            string sql = @"update bus_info 
set bus_info_make_code = @bus_info_make_code
, bus_info_model_code = @bus_info_model_code
, bus_info_reght_seat = @bus_info_reght_seat
, bus_info_left_seat = @bus_info_left_seat
, bus_info_back_seat = @bus_info_back_seat
, bus_info_line_seat = @bus_info_line_seat
where bus_info_ID = @bus_info_ID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.setParameters(MySqlDbType.VarChar, "@bus_info_make_code", temp.bus_info_make_code);
            cmd.setParameters(MySqlDbType.VarChar, "@bus_info_model_code", temp.bus_info_model_code);
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_reght_seat", temp.bus_info_reght_seat.ToString());
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_left_seat", temp.bus_info_left_seat.ToString());
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_back_seat", temp.bus_info_back_seat.ToString());
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_line_seat", temp.bus_info_line_seat.ToString());
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_ID", temp.bus_info_ID.ToString());

            return cmd.ExecuteNonQuery() == 0 ? false : true;

        }
        #endregion

        #region delete
        public bool delete(Bus_Info temp)
        {
            string sql = "delete from bus_info where bus_info_ID = @bus_info_ID;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.setParameters(MySqlDbType.Int32, "@bus_info_ID", temp.bus_info_ID);

            return cmd.ExecuteNonQuery() == 0 ? false: true;
        }
        #endregion

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
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return 0;
            }
        }
        #endregion

        #region 버스 정보 전달
        public Bus_Info GetBus_Info(string trv_info_ID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = $@"select bus_info_ID, bus_info_make_code, bus_info_model_code, bus_info_reght_seat, bus_info_left_seat, bus_info_back_seat, bus_info_line_seat 
                                from bus_info where bus_info_ID =
                                (select bus_info_ID from bus where bus_ID =
                                (SELECT bus_ID FROM gudi06.travel_info where trv_info_ID = @trv_info_ID))"
                };

                setParameters(cmd, MySqlDbType.Int32, "@trv_info_ID", trv_info_ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                Bus_Info temp = null;
                while (reader.Read())
                {
                    temp = new Bus_Info();
                    temp.bus_info_ID = reader.GetInt32("bus_info_ID").ToString();
                    temp.bus_info_make_code = reader.GetString("bus_info_make_code");
                    temp.bus_info_reght_seat = reader.GetInt32("bus_info_reght_seat");
                    temp.bus_info_left_seat = reader.GetInt32("bus_info_left_seat");
                    temp.bus_info_line_seat = reader.GetInt32("bus_info_line_seat");
                    temp.bus_info_back_seat = reader.GetInt32("bus_info_back_seat");
                }

                return temp;
            }catch (Exception err)
            {
                return null;
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
