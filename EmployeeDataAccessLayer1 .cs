using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Employee1
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }

    public class EmployeeDataAccessLayer1    {
        public static void UpdateEmployee(int EmployeeId, string Name,
                                   string Gender, string City)
        {
            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Update tblEmployee SET Name = @Name,  " +
                    "Gender = @Gender, City = @City WHERE EmployeeId = @EmployeeId ";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramEmployeeId = new SqlParameter("@EmployeeId", EmployeeId);
                cmd.Parameters.Add(paramEmployeeId);
                SqlParameter paramName = new SqlParameter("@Name", Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@City", City);
                cmd.Parameters.Add(paramCity);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static List<Employee1> GetAllEmployees()
        {
            List<Employee1> listEmployees = new List<Employee1>();

            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblEmployee", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee1 employee1 = new Employee1();
                    employee1.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee1.Name = rdr["Name"].ToString();
                    employee1.Gender = rdr["Gender"].ToString();
                    employee1.City = rdr["City"].ToString();

                    listEmployees.Add(employee1);
                }
            }

            return listEmployees;
        }

    }
}