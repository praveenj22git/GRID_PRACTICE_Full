using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Employee3
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }

    public class EmployeeDataAccessLayer3
    {
        public static List<Employee3> GetAllEmployees()
        {
            List<Employee3> listEmployees = new List<Employee3>();

            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblEmployee", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee3 employee = new Employee3();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.City = rdr["City"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }

        public static void DeleteEmployees(List<string> EmployeeIds)
        {
            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                List<string> parameters = EmployeeIds.Select((s, i) => "@Parameter" + i.ToString()).ToList();
                string inClause = string.Join(",", parameters);
                string deleteCommandText = "Delete from tblEmployee where EmployeeId IN (" + inClause + ")";
                SqlCommand cmd = new SqlCommand(deleteCommandText, con);

                for (int i = 0; i < parameters.Count; i++)
                {
                    cmd.Parameters.AddWithValue(parameters[i], EmployeeIds[i]);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}