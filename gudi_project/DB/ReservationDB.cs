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
                string res_ID = GetRes_ID(travel).ToString();
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

        #region ID값 확인
        public int GetRes_ID(Travel_info travel)
        {
            string sql = @"select res_ID from reservation where trv_info_ID = @trv_info_ID;";
            MySqlCommand cmd = new MySqlCommand() 
            {
                CommandText = sql,
                Connection = conn
            };

            setParameters(cmd, MySqlDbType.Int32, "@trv_info_ID", travel.trv_info_ID);

            int res_ID = Convert.ToInt32(cmd.ExecuteScalar());
            return res_ID;
        }
        #endregion

        public DataTable UsergetRervation(string usr_email)
        {
            string sql = @"select T.trv_info_ID, usr_name, res_date, res_prce ,T.trv_info_name, trv_info_img
                            from reservation R join user U join travel_info T
                            on R.usr_email = U.usr_email and T.trv_info_ID = R.trv_info_ID
                            where U.usr_email = @usr_email";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.Add("@usr_email", MySqlDbType.VarChar);
            da.SelectCommand.Parameters["@usr_email"].Value = usr_email;
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;

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
            conn.Close();
        }
    }
}
