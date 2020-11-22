using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class Reservation
    {
        public string res_ID { get; set; }
        public string trv_info_ID { get; set; }
        public string usr_email { get; set; }
        public string res_date { get; set; }
        public string res_prce { get; set; }
    }

    public class ReservationDB : IDisposable
    {
        MySqlConnection conn;

        public ReservationDB()
        {
            conn = new MySqlConnection()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString
            };

            conn.Open();
        }

        #region 예약 추가
        public bool InserReservation(Travel_info travel, List<seat> seats,string usr_email)
        {
            string sql = @"insert reservation(trv_info_ID, usr_email, res_date, res_prce) 
                            values(@trv_info_ID, @usr_email,date_format(now(), '%Y%m%d'), @res_prce);";
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandText = sql,
                Connection = conn
            };
            string res_prce = (int.Parse(travel.trv_info_price) * seats.Count).ToString();
            setParameters(cmd, MySqlDbType.Int32, "@trv_info_ID", travel.trv_info_ID);
            setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);
            setParameters(cmd, MySqlDbType.Int32, "@res_prce", res_prce);

            int count = cmd.ExecuteNonQuery();

            if(count > 0)
            {
                string res_ID = GetRes_ID().ToString();
                foreach (seat seat in seats)
                {
                    seat.res_ID = res_ID;
                }
                seatDB db = new seatDB();
                db.InserSeat(seats);
                return true;
            }
            else
                return false;
        }
        #endregion

        #region 맨마지막 예약 ID값 확인
        public int GetRes_ID()
        {
            string sql = @"select res_ID from reservation 
                          order by res_ID desc
                          limit 1;";
            MySqlCommand cmd = new MySqlCommand() 
            {
                CommandText = sql,
                Connection = conn
            };

            int res_ID = Convert.ToInt32(cmd.ExecuteScalar());
            return res_ID;
        }
        #endregion

        #region 유저를 기반으로 예약된 것을 확인
        public DataTable UsergetRervation(string usr_email)
        {
            string sql = @"select 
                        res_ID, T.trv_info_ID, usr_name,date_format(res_date, '%Y-%m-%d') res_date,T.trv_info_name ,res_prce
                        ,CAST((res_prce / T.trv_info_price) as signed integer) seat, trv_info_img
                        from reservation R join user U join travel_info T
                        on R.usr_email = U.usr_email and T.trv_info_ID = R.trv_info_ID
                        where U.usr_email = @usr_email
                        and date_format(trv_info_start_date, '%Y-%m-%d') > now();";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.Add("@usr_email", MySqlDbType.VarChar);
            da.SelectCommand.Parameters["@usr_email"].Value = usr_email;
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;

        }
        #endregion

        #region 삭제
        public bool DeleteRes(string res_ID)
        {
            string sql = "delete from reservation where res_ID = @res_ID;";
            MySqlCommand cmd = new MySqlCommand()
            {
                Connection = conn,
                CommandText = sql
            };

            setParameters(cmd, MySqlDbType.Int32, "@res_ID", res_ID);

            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
                seatDB db = new seatDB();
                bool result = db.ResDeleteSeat(res_ID);
                db.Dispose();
                if (result)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        #endregion

        #region 매출 정보
        public DataTable Getsales(string from_date, string to_date)
        {
            string sql = @"call da(@from_date,@to_date);";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.SelectCommand.Parameters.Add("@from_date", MySqlDbType.VarChar);
            da.SelectCommand.Parameters["@from_date"].Value = from_date;
            da.SelectCommand.Parameters.Add("@to_date", MySqlDbType.VarChar);
            da.SelectCommand.Parameters["@to_date"].Value = to_date;
            da.Fill(dt);

            return dt;
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
