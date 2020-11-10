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

        #region 예약 좌석 확인
        public List<seat> SeatList(string trv_info_ID)
        {
            List<seat> seats = new List<seat>();
            try
            {
                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = @"SELECT res_seat_ID, S.res_ID, res_seat_num 
                FROM seat S JOIN reservation R join travel_info T 
                ON R.trv_info_ID = T.trv_info_ID and R.res_ID = S.res_ID
                WHERE T.trv_info_ID = @trv_info_ID;"
                };
                setParameters(cmd, MySqlDbType.Int32, "@trv_info_ID", trv_info_ID);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    seat seat = new seat();
                    seat.res_seat_ID = reader.GetInt32("res_seat_ID").ToString();
                    seat.res_ID = reader.GetInt32("res_ID").ToString();
                    seat.res_seat_num = reader.GetString("res_seat_num");
                    seats.Add(seat);
                }

                return seats;
            }catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
        #endregion

        #region 좌석 추가
        public void InserSeat(List<seat> seats)
        {
            string sql = @"insert into seat(res_ID, res_seat_num) 
                            values (@res_ID, @res_seat_num);";
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = conn,
                CommandText = sql
            };
            foreach (seat seat in seats) {
                cmd.Parameters.Clear();
                setParameters(cmd, MySqlDbType.Int32, "@res_ID", seat.res_ID);
                setParameters(cmd, MySqlDbType.VarChar, "@res_seat_num", seat.res_seat_num);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 예약 기반 좌석 삭제
        public bool ResDeleteSeat(string res_ID)
        {
            string sql = "delete from seat where res_ID = @res_ID;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@res_ID", res_ID);

            int count = cmd.ExecuteNonQuery();

            if (count > 0)
                return true;
            else
                return false;
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
