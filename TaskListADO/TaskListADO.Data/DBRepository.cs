using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TaskListADO.Models;

namespace TaskListADO.Data
{
    public class DBRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["TaskList"].ConnectionString;
        private static string connectionString2 = ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;


        public List<Task> GetAll()
        {
            List<Task> tasks =  new List<Task>();

            //todo: Connect to datbase
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                //todo: Write a sql query to get the data
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Task";

                //you must open the database connection to use it...
                cn.Open();

                //todo: Take the sql data and make it a task objects 
                using (SqlDataReader dr = cmd.ExecuteReader()) // hits f5 in SSMS
                {
                    // we have to read the results
                    while (dr.Read())
                    {
                        //todo: Add task objects  to list
                        Task newTask = new Task()
                        {
                            TasKId = (int)dr["TableId"],
                            Discription = dr["Discription"].ToString(),
                            DateEntered = DateTime.Parse(dr["DateEnterd"].ToString()),
                            Notes = dr["Notes"].ToString()
                        };
                        if (dr["DueDate"] != DBNull.Value)
                        {
                            newTask.DueDate = DateTime.Parse(dr["DueDate"].ToString());
                        }
                        tasks.Add(newTask);
                    }
                }
            }
            return tasks;
        }

        public Task GetById(int id)
        {
            Task task = new Task();

            using (var cn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Task WHERE tableId = @TableId";
                cmd.Parameters.AddWithValue("@TableId", id);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();

                        task.TasKId = (int) dr["tableId"];
                        task.Discription = dr["discription"].ToString();
                        task.DateEntered  = DateTime.Parse(dr["DateEnterd"].ToString());
                        task.Notes = dr["Notes"].ToString();
                        if (dr["DueDate"] != DBNull.Value)
                        {
                            task.DueDate = DateTime.Parse(dr["DueDate"].ToString());
                        }
                    }
                }
            }
            return task;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            var cn = new SqlConnection(connectionString2);
            var cmd = new SqlCommand();
            cmd.CommandText = "spGetEmployeeGrants";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;

            cn.Open();

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Employee newEmployee = employees.FirstOrDefault(m => m.EmployeeId == (int) dr["EmpId"]);
                    if (newEmployee == null)
                    {
                        newEmployee = new Employee()
                        {
                            EmployeeId = (int)dr["EmpId"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Grants = new List<Grant>()
                        };
                        employees.Add(newEmployee);
                    }
                    Grant newGrant = new Grant()
                    {
                        GrantID = int.Parse(dr["GrantId"].ToString()),
                        GrantName = dr["GrantName"].ToString(),
                        Amount = Decimal.Parse(dr["Amount"].ToString())
                    };
                    newEmployee.Grants.Add(newGrant);
                }
            }
            return employees;
        }
    }
}
