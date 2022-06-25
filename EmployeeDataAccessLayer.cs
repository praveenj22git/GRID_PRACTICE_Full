using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    //Business object to hold employee related data
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }

    public class EmployeeDataAccessLayer
    {
        //Method to return all employees
        public static List<Employee> GetEmployeesByDepartment(int departmentId)
        {
            List<Employee> listEmployees = new List<Employee>();

            string CS = ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeesByDepartmentId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@DepartmentId", departmentId);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();



                    employee.DepartmentName = rdr["DepartmentName"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }
    }
}