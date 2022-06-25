using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Employee5
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }

    public class EmployeeDataAccessLayer5
    {
        public static List<Employee5> GetAllEmployees(int DepartmentId)
        {
            List<Employee5> listEmployees = new List<Employee5>();

            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblEmployee2 where DeptId = @DepartmentId", con);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@DepartmentId";
                parameter.Value = DepartmentId;
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee5 employee = new Employee5();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.EmployeeName = rdr["Name"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }
    }
}