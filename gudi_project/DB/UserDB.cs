using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class User
    {
        public string usr_email { get; set; }
        public string usr_pasword { get; set; }
        public string usr_name { get; set; }
        public string usr_from_date { get; set; }
        public string usr_to_date { get; set; }
        public string usr_status_code { get; set; }
    }


    public class UserDB : IDisposable
    {
        MySqlConnection conn;
        public UserDB()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn.Open();
        }
        #region 유저 확인
        public bool UserChack(string usr_email)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select count(usr_email) from user where usr_email = @usr_email";
                cmd.Connection = conn;

                setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UserChack(string usr_email, string usr_name)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select count(usr_email) from user where usr_email = @usr_email and usr_name = @usr_name";
                cmd.Connection = conn;

                setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);
                setParameters(cmd, MySqlDbType.VarChar, "@usr_name", usr_name);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UserChackPwd(string usr_email, string usr_pasword)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select count(usr_email) from user where usr_email = @usr_email and usr_pasword = @usr_pasword";
                cmd.Connection = conn;

                setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);
                setParameters(cmd, MySqlDbType.VarChar, "@usr_pasword", usr_pasword);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public string UserLoingChack(string usr_email,string usr_pasword)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT usr_mas_code FROM user where usr_email = @usr_email and usr_pasword = @usr_pasword and usr_status_code != 'US03';";

                setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);
                setParameters(cmd, MySqlDbType.VarChar, "@usr_pasword", usr_pasword);

                string temp = Convert.ToString(cmd.ExecuteScalar());

                return temp;
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        #region 유저 추가
        public bool InsertUser(string usr_email,string usr_pasword, string usr_name)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into user(usr_email, usr_name, usr_pasword, usr_from_date) values(@usr_email, @usr_name, @usr_pasword, date_format(now(), '%Y%m%d'));";
                cmd.Connection = conn;

                setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);
                setParameters(cmd, MySqlDbType.VarChar, "@usr_name", usr_name);
                setParameters(cmd, MySqlDbType.VarChar, "@usr_pasword", usr_pasword);

                int count = cmd.ExecuteNonQuery();

                if (count < 1)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 유저 정보 확인
        public User GetUser(string usr_email, string usr_pasword)
        {
            string sql = @"select usr_email, usr_name, usr_pasword, usr_from_date, usr_to_date, usr_status_code, usr_mas_code from user 
                           where usr_email = @usr_email and usr_pasword = @usr_pasword;";
            User user = new User();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);
            setParameters(cmd, MySqlDbType.VarChar, "@usr_pasword", usr_pasword);

            MySqlDataReader data =  cmd.ExecuteReader();

            if (data.Read())
            {
                user.usr_email = data.GetString("usr_email");
                user.usr_name = data.GetString("usr_name");
                user.usr_pasword = data.GetString("usr_pasword");
                user.usr_status_code = data.GetString("usr_status_code");
                user.usr_from_date = data.GetString("usr_from_date");
                user.usr_to_date = data.GetString("usr_to_date");
            }

            return user;
        }
        #endregion

        #region 비밀번호 업데이트
        public bool UpdatePwd(string usr_email, string newPwd)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update user set usr_pasword = @usr_pasword where usr_email = @usr_email";

            setParameters(cmd, MySqlDbType.VarChar, "@usr_pasword", newPwd);
            setParameters(cmd, MySqlDbType.VarChar, "@usr_email", usr_email);

            int count =  cmd.ExecuteNonQuery();

            if (count < 1)
                return false;
            return true;
        }

        #endregion

        #region 할당 해제 DISPOSE
        public void Dispose()
        {
            conn.Dispose();
        }
        #endregion

        #region 파라미터 설정
        private void setParameters(MySqlCommand cmd, MySqlDbType type, string ParamName, string ParamValue)
        {
            cmd.Parameters.Add(ParamName, type);
            cmd.Parameters[ParamName].Value = ParamValue;
        }
        #endregion

    }
}
