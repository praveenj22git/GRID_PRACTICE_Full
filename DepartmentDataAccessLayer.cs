using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    //Business object to hold department related data
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class DepartmentDataAccessLayer
    {
        //Method to return all departments
        public static List<Department> GetAllDepartments()
        {
            List<Department> listDepartments = new List<Department>();

            string CS = ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetDepartments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Department department = new Department();
                    department.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                    department.DepartmentName = rdr["Name"].ToString();

                    listDepartments.Add(department);
                }
            }

            return listDepartments;
        }
    }
}