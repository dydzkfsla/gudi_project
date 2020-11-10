using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public string  trv_info_img          {get; set;}
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

        #region 대표 정보 확인
        public List<Travel_info> MainTravel()
        {
            try
            {
                List<Travel_info> Infos = new List<Travel_info>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select 
                trv_info_ID, bus_ID, bus_emp_ID, guid_emp_ID, date_format(trv_info_start_date, '%Y-%m-%d') as trv_info_start_date
                , trv_info_name, trv_info_img,trv_info_price, trv_info_tel, trv_info_Data
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
                    temp.trv_info_img = reader.GetString("trv_info_img");
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

        public void Dispose()
        {
            conn.Dispose();
        }

    }
}
