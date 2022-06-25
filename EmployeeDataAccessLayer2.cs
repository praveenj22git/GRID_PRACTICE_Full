using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Employee2
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }

    public class EmployeeDataAccessLayer2
    {
        // Select Method for ObjectDataSource control
        public static List<Employee2> GetAllEmployees()
        {
            List<Employee2> listEmployees = new List<Employee2>();

            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblEmployee", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee2 employee = new Employee2();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.City = rdr["City"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }

        // Delete Method for ObjectDataSource control
        public static void DeleteEmployee(int EmployeeId)
        {
            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand
                    ("Delete from tblEmployee where EmployeeId = @EmployeeId", con);
                SqlParameter param = new SqlParameter("@EmployeeId", EmployeeId);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Update Method for ObjectDataSource control
        public static int UpdateEmployee(int EmployeeId, string Name, string Gender, string City)
        {
            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Update tblEmployee SET Name = @Name,  " +
                    "Gender = @Gender, City = @City WHERE EmployeeId = @EmployeeId";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramOriginalEmployeeId = new
                    SqlParameter("@EmployeeId", EmployeeId);
                cmd.Parameters.Add(paramOriginalEmployeeId);
                SqlParameter paramName = new SqlParameter("@Name", Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@City", City);
                cmd.Parameters.Add(paramCity);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Insert Method for ObjectDataSource control
        public static int InsertEmployee(string Name, string Gender, string City)
        {
            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Insert into tblEmployee (Name, Gender, City)" +
                    " values (@Name, @Gender, @City)";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramName = new SqlParameter("@Name", Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@City", City);
                cmd.Parameters.Add(paramCity);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}