using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public class Bus
    {
        public string bus_ID { get; set; }
        public string emp_ID { get; set; }
        public string bus_info_ID { get; set; }
        public string bus_from_date { get; set; }
        public string bus_in_code { get; set; }
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

        #region BusSelect
        public DataTable Select()
        {
            string sql = @"SELECT bus_ID, bus.emp_ID, employees.emp_name, bus_info_ID, bus_from_date, bus_in_code, code.name as bus_in_name 
    FROM bus , employees , code
    where bus_in_code = code.code and bus.emp_ID = employees.emp_ID;";
            MySqlDataAdapter cmd = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            return dt;
        }
        #endregion

        #region insert
        public bool insert(Bus bus)
        {
            string sql = @"insert into bus(emp_ID, bus_info_ID, bus_from_date, bus_in_code) 
                           values (@emp_ID, @bus_info_ID, @bus_from_date, @bus_in_code);";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", bus.emp_ID);
            setParameters(cmd, MySqlDbType.Int32, "@bus_info_ID", bus.bus_info_ID);
            setParameters(cmd, MySqlDbType.VarChar, "@bus_from_date", bus.bus_from_date);
            setParameters(cmd, MySqlDbType.VarChar, "@bus_in_code", bus.bus_in_code);

            return cmd.ExecuteNonQuery() == 0 ? false : true;

        }
        #endregion

        #region update
        public bool update(Bus bus)
        {
            string sql = @"update bus set emp_ID = @emp_ID
		,bus_info_ID= @bus_info_ID
		,bus_from_date = @bus_from_date
        ,bus_in_code = @bus_in_code
        where bus_ID = @bus_ID;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@bus_ID", bus.bus_ID);
            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", bus.emp_ID);
            setParameters(cmd, MySqlDbType.Int32, "@bus_info_ID", bus.bus_info_ID);
            setParameters(cmd, MySqlDbType.VarChar, "@bus_from_date", bus.bus_from_date);
            setParameters(cmd, MySqlDbType.VarChar, "@bus_in_code", bus.bus_in_code);

            return cmd.ExecuteNonQuery() == 0 ? false : true;

        }
        #endregion

        #region delete
        public bool delete(Bus bus)
        {
            string sql = @"delete from bus where bus_ID = @bus_ID";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@bus_ID", bus.bus_ID);

            return cmd.ExecuteNonQuery() == 0 ? false : true;

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


        //select * from bus_info where bus_info_ID = (SELECT bus_info_ID FROM gudi06.bus where bus_ID = 1);
    }
}
