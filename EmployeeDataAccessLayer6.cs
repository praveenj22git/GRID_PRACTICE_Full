using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Employee6
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }

    public class EmployeeDataAccessLayer6
    {
        public static DataSet GetAllEmployees()
        {
         
            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblEmployee", con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }
    }
}