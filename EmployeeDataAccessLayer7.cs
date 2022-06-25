using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Employee7
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }

    public class EmployeeDataAccessLayer7
    {
        public static List<Employee7> GetEmployees(int startRowIndex, int maximumRows)
        {
            List<Employee7> listEmployees = new List<Employee7>();

            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@StartIndex";
                paramStartIndex.Value = startRowIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter();
                paramMaximumRows.ParameterName = "@MaximumRows";
                paramMaximumRows.Value = maximumRows;
                cmd.Parameters.Add(paramMaximumRows);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee7 employee = new Employee7();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.City = rdr["City"].ToString();

                    listEmployees.Add(employee);
                }
            }
            return listEmployees;
        }

        public static int GetTotalCount()
        {
            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select Count(*) from tblEmployee", con);

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}