using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

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

        #region 정비사 직원 확인
        public DataTable GetMechanicemployess()
        {
            string sql = @"select emp_ID , emp_name from employees
                            where emp_dep_code = 'DE03';";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);

            return dt;
        }
        #endregion


        #endregion

        #region 직원 정보 Update
        #region employees 기반 Update
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

        #region 직원 퇴사
        public bool updateTodateNow(string emp_ID)
        {
            string sql = @"update employees 
                         set emp_to_date =date_format(now(), '%Y-%m-%d')
                         where emp_ID = @emp_ID;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", emp_ID);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 직원 퇴사 취소
        public bool updateTodateBreak(string emp_ID)
        {
            string sql = @"update employees 
                         set emp_to_date = '9999-12-30'
                         where emp_ID = @emp_ID;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", emp_ID);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 직원 퇴사일 변경
        public bool updateTodate(employees employees)
        {
            string sql = @"update employees 
                         set emp_to_date = @emp_to_date
                         where emp_ID = @emp_ID;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", employees.emp_ID);
            setParameters(cmd, MySqlDbType.DateTime, "@emp_to_date", employees.emp_to_date);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        #endregion

        #endregion

        #region 직원 정보 insert
        public bool insert(employees employees)
        {
            string sql = @"insert into employees (emp_name, emp_from_date, emp_to_date, emp_salary, emp_mgr_code, emp_dep_code) 
            values(@emp_name , @emp_from_date , '9999-12-30' ,@emp_salary ,@emp_mgr_code,@emp_dep_code);";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.VarChar, "@emp_name", employees.emp_name);
            setParameters(cmd, MySqlDbType.DateTime, "@emp_from_date", employees.emp_from_date);
            setParameters(cmd, MySqlDbType.Int32, "@emp_salary", employees.emp_salary);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_mgr_code", employees.emp_mgr_code);
            setParameters(cmd, MySqlDbType.VarChar, "@emp_dep_code", employees.emp_dep_code);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;

        }

        #endregion

        #region 직원 정보 delete
        public bool delete(employees employees)
        {
            string sql = @"delete from employees where emp_ID = @emp_ID;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            setParameters(cmd, MySqlDbType.Int32, "@emp_ID", employees.emp_ID);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;

        }

        #endregion

        #region 종합 쿼리

        #region 엑셀 저장
        public bool AllDataImportExcel(DataTable dt)
        {
            
            MySqlTransaction transaction  = conn.BeginTransaction();

            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = "delete from employees;ALTER TABLE employees AUTO_INCREMENT=1;",
                Transaction = transaction
            };
            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"insert into 
         employees(emp_name  ,emp_from_date  ,emp_to_date,  emp_salary  , emp_mgr_code  ,emp_dep_code) 
            values(@emp_name ,@emp_from_date ,@emp_to_date ,@emp_salary , @emp_mgr_code ,@emp_dep_code);";

                foreach (DataRow row in dt.Rows)
                {
                    cmd.Parameters.Clear();
                    employees temp = getEmployees(row);
                    DateTime emp_to_date = Convert.ToDateTime(temp.emp_to_date);
                    DateTime emp_from_date = Convert.ToDateTime(temp.emp_from_date);

                    setParameters(cmd, MySqlDbType.VarChar, "@emp_to_date", emp_to_date.ToString("yyyy-MM-dd"));
                    setParameters(cmd, MySqlDbType.VarChar, "@emp_name", temp.emp_name);
                    setParameters(cmd, MySqlDbType.VarChar, "@emp_from_date", emp_from_date.ToString("yyyy-MM-dd"));
                    setParameters(cmd, MySqlDbType.Int32, "@emp_salary", temp.emp_salary);
                    setParameters(cmd, MySqlDbType.VarChar, "@emp_mgr_code", temp.emp_mgr_code);
                    setParameters(cmd, MySqlDbType.VarChar, "@emp_dep_code", temp.emp_dep_code);

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                transaction.Rollback();
                return false;
            }


        }

        #endregion

        #endregion

        #region 파라미터 설정
        private void setParameters(MySqlCommand cmd, MySqlDbType type, string ParamName, string ParamValue)
        {
            cmd.Parameters.Add(ParamName, type);
            cmd.Parameters[ParamName].Value = ParamValue;
        }
        #endregion

        public static employees getEmployees(DataRow row)
        {
            employees employee = new employees();
            employee.emp_ID = row["emp_ID"].ToString();
            employee.emp_name = row["emp_name"].ToString();
            employee.emp_salary = row["emp_salary"].ToString();
            employee.emp_from_date = row["emp_from_date"].ToString();
            employee.emp_to_date = row["emp_to_date"].ToString();
            employee.emp_dep_code = row["emp_dep_code"].ToString();
            employee.emp_mgr_code = row["emp_mgr_code"].ToString();
            return employee;
        }

        public void Dispose()
        {
            conn.Dispose();
        }


    }
}
