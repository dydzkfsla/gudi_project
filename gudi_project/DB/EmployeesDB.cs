using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace gudi_project
{
    public class employees
    {
        public string emp_ID { get; set; }
        public string emp_name { get; set; }
        public string emp_from_date { get; set; }
        public string emp_to_date { get; set; }
        public string emp_salary { get; set; }
        public string emp_mgr_code { get; set; }
        public string emp_dep_code { get; set; }

    }
    public class EmployeesDB : IDisposable
    {
        MySqlConnection conn;
        public EmployeesDB()
        {
            conn = new MySqlConnection()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString
            };
            conn.Open();
        }
        #region 직원 정보 Select
        public DataTable GetAllemployess()
        {
            string sql = @"SELECT emp_ID, emp_name, emp_from_date, emp_to_date, emp_salary, emp_mgr_code, emp_dep_code , c1.name as mgrname , c2.name as depname 
                                    FROM employees join code c1 join code c2
                                  on emp_mgr_code = c1.code and emp_dep_code = c2.code; ";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            int count = da.Fill(dt);
            if (count > 0)
                return dt;
            else
                return null;

        }

        #endregion

        #region 직원 정보 Update
        public bool update(employees employees)
        {
            string sql = @"update employees 
                         set emp_name = @emp_name
                         , emp_from_date = @emp_from_date
                         , emp_salary = @emp_salary
                         , emp_mgr_code = @emp_mgr_code
                         , emp_dep_code = @emp_dep_code
                         where emp_ID = @emp_ID";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", employees.emp_ID);
            setParameters(cmd, MySqlDbType.DateTime,"@emp_from_date", employees.emp_from_date);
            setParameters(cmd, MySqlDbType.Int32, "@emp_salary", employees.emp_salary);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_name", employees.emp_name);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_mgr_code", employees.emp_mgr_code);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_dep_code", employees.emp_dep_code);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;

        }

        #endregion

        #region 직원 정보 insert
        public bool insert(employees employees)
        {
            string sql = @"insert into employees (emp_name, emp_from_date, emp_to_date, emp_salary, emp_mgr_code, emp_dep_code) 
            values();";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", employees.emp_ID);
            setParameters(cmd, MySqlDbType.DateTime, "@emp_from_date", employees.emp_from_date);
            setParameters(cmd, MySqlDbType.Int32, "@emp_salary", employees.emp_salary);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_name", employees.emp_name);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_mgr_code", employees.emp_mgr_code);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_dep_code", employees.emp_dep_code);

            if (cmd.ExecuteNonQuery() > 0)
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
