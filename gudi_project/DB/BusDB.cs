using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class Bus
    {
    }

    public class BusDB : IDisposable
    {
        MySqlConnection conn = null;

        public BusDB()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn.Open();
        }

        public void Dispose()
        {
            conn.Dispose();
        }


        //select * from bus_info where bus_info_ID = (SELECT bus_info_ID FROM gudi06.bus where bus_ID = 1);
    }
}
