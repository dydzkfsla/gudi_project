using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class Travel_info 
    {
        public string  trv_info_ID           {get; set;}
        public string  bus_ID                {get; set;}
        public string  bus_emp_ID            {get; set;}
        public string  guid_emp_ID           {get; set;}
        public string  trv_info_start_date   {get; set;}
        public string  trv_info_name         {get; set;}
        public string  trv_info_price        {get; set;}
        public byte[]  trv_info_img          {get; set;}
        public string  trv_info_tel          {get; set;}
        public string  trv_info_Data          {get; set;}
    }


    public class Travel_infoDB : IDisposable
    {
        MySqlConnection conn = null;
        public Travel_infoDB()
        {
            string strconn = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new MySqlConnection(strconn);
            conn.Open();
        }
        #region select
        
        #region select ID List
        public List<string> SelectIDList()
        {
            List<string> vs = new List<string>();
            string sql = @"select trv_info_ID
                from travel_info";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vs.Add(reader.GetString("trv_info_ID"));
            }

            return vs;
        }

        #endregion

        #region select
        public DataTable select()
        {
            string sql = @"SELECT trv_info_ID, bus_ID, bus_emp_ID, guid_emp_ID
    , E1.emp_name AS  bus_emp_name, E2.emp_name as guid_emp_name
    , trv_info_start_date, trv_info_name, trv_info_price
    , trv_info_img, trv_info_tel, trv_info_Data  
    FROM travel_info join employees E1 join employees E2
    on bus_emp_ID = E1.emp_ID AND guid_emp_ID = E2.emp_ID;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        #endregion

        #endregion

        #region insert
        public bool insert(Travel_info temp)
        {
            string sql = @"insert into 
    travel_info(bus_ID, bus_emp_ID, guid_emp_ID, trv_info_start_date, trv_info_name, trv_info_price, trv_info_img, trv_info_tel, trv_info_Data)
    values(@bus_ID, @bus_emp_ID, @guid_emp_ID, @trv_info_start_date, @trv_info_name, @trv_info_price, @trv_info_img, @trv_info_tel, @trv_info_Data)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.setParameters(MySqlDbType.Int32, "@bus_ID", temp.bus_ID);
            cmd.setParameters(MySqlDbType.Int32, "@bus_emp_ID", temp.bus_emp_ID);
            cmd.setParameters(MySqlDbType.Int32, "@guid_emp_ID", temp.guid_emp_ID);
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_start_date", temp.trv_info_start_date);
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_name", temp.trv_info_name);
            cmd.setParameters(MySqlDbType.Int32, "@trv_info_price", temp.trv_info_price);
            cmd.Parameters.Add("@trv_info_img" , MySqlDbType.Blob);
            cmd.Parameters["@trv_info_img"].Value = temp.trv_info_img;
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_tel", temp.trv_info_tel);
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_Data", temp.trv_info_Data);

            return cmd.ExecuteNonQuery() == 0 ? false : true;

        }
        #endregion

        #region update
        public bool update(Travel_info temp)
        {
            string sql = @"update travel_info set
    bus_ID = @bus_ID, bus_emp_ID = @bus_emp_ID,
    guid_emp_ID = @guid_emp_ID, trv_info_start_date = @trv_info_start_date,
    trv_info_name = @trv_info_name, trv_info_price = @trv_info_price,
    trv_info_img = @trv_info_img , trv_info_tel = @trv_info_tel,
    trv_info_Data =@trv_info_Data
    where trv_info_ID =  @trv_info_ID;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.setParameters(MySqlDbType.Int32, "@trv_info_ID", temp.trv_info_ID);
            cmd.setParameters(MySqlDbType.Int32, "@bus_ID", temp.bus_ID);
            cmd.setParameters(MySqlDbType.Int32, "@bus_emp_ID", temp.bus_emp_ID);
            cmd.setParameters(MySqlDbType.Int32, "@guid_emp_ID", temp.guid_emp_ID);
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_start_date", temp.trv_info_start_date);
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_name", temp.trv_info_name);
            cmd.setParameters(MySqlDbType.Int32, "@trv_info_price", temp.trv_info_price);
            cmd.Parameters.Add("@trv_info_img", MySqlDbType.Blob);
            cmd.Parameters["@trv_info_img"].Value = temp.trv_info_img;
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_tel", temp.trv_info_tel);
            cmd.setParameters(MySqlDbType.VarChar, "@trv_info_Data", temp.trv_info_Data);

            return cmd.ExecuteNonQuery() == 0 ? false : true;

        }
        #endregion

        #region delete
        public bool delete(Travel_info temp)
        {
            string sql = @"delete from travel_info where trv_info_ID = @trv_info_ID;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.setParameters(MySqlDbType.Int32, "@trv_info_ID", temp.trv_info_ID);

            return cmd.ExecuteNonQuery() == 0 ? false : true;

        }
        #endregion

        #region 대표 정보 확인
        public List<Travel_info> MainTravel()
        {
            try
            {
                List<Travel_info> Infos = new List<Travel_info>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select 
                trv_info_img, trv_info_ID, bus_ID, bus_emp_ID, guid_emp_ID, date_format(trv_info_start_date, '%Y-%m-%d') as trv_info_start_date
                , trv_info_name,trv_info_price, trv_info_tel, trv_info_Data
                from travel_info
                where  trv_info_start_date > date_format(NOW(), '%y-%m-%d')
                order by trv_info_start_date asc limit 5";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Travel_info temp = new Travel_info();
                    temp.trv_info_ID = reader.GetString("trv_info_ID");
                    temp.bus_ID = reader.GetString("bus_ID");
                    temp.bus_emp_ID = reader.GetString("bus_emp_ID");
                    temp.guid_emp_ID = reader.GetString("guid_emp_ID");
                    temp.trv_info_start_date = reader.GetString("trv_info_start_date");
                    temp.trv_info_name = reader.GetString("trv_info_name");
                    temp.trv_info_price = reader.GetString("trv_info_price");
                    temp.trv_info_img = (byte[])reader.GetValue(0);
                    temp.trv_info_tel = reader.GetString("trv_info_tel");
                    temp.trv_info_Data = reader.GetString("trv_info_Data");

                    Infos.Add(temp);
                }
                if (Infos.Count > 0)
                    return Infos;
                else
                    return null;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<Travel_info> MainTravel(string from_date, string to_date)
        {
            try
            {
                List<Travel_info> Infos = new List<Travel_info>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"
                    SELECT  trv_info_img, trv_info_ID, bus_ID, bus_emp_ID, guid_emp_ID, trv_info_start_date, trv_info_name, trv_info_price, trv_info_tel, trv_info_Data
                    FROM gudi06.travel_info
                    where trv_info_start_date > @from_date
                    and trv_info_start_date< @to_date;";


                setParameters(cmd, MySqlDbType.VarChar, "@from_date", from_date);
                setParameters(cmd, MySqlDbType.VarChar, "@to_date", to_date);

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Travel_info temp = new Travel_info();
                    temp.trv_info_ID = reader.GetString("trv_info_ID");
                    temp.bus_ID = reader.GetString("bus_ID");
                    temp.bus_emp_ID = reader.GetString("bus_emp_ID");
                    temp.guid_emp_ID = reader.GetString("guid_emp_ID");
                    temp.trv_info_start_date = reader.GetString("trv_info_start_date");
                    temp.trv_info_name = reader.GetString("trv_info_name");
                    temp.trv_info_price = reader.GetString("trv_info_price");
                    temp.trv_info_img = (byte[])reader.GetValue(0);
                    temp.trv_info_tel = reader.GetString("trv_info_tel");
                    temp.trv_info_Data = reader.GetString("trv_info_Data");

                    Infos.Add(temp);
                }
                if (Infos.Count > 0)
                    return Infos;
                else
                    return null;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        #endregion

        #region 남은 좌석 확인
        public int getremainderSeat(string bus_ID, string trv_info_ID)
        {
            Bus_InfoDB Busdb = new Bus_InfoDB();
            int Allseat = Busdb.BusSeat(bus_ID);
            Busdb.Dispose();
            seatDB Seatdb = new seatDB();
            int SeatCount = Seatdb.SeatList(trv_info_ID).Count;
            Seatdb.Dispose();

            return Allseat - SeatCount;
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
