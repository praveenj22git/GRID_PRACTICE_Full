using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Department1
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee5> Employees
        {
            get
            {
                return EmployeeDataAccessLayer5.GetAllEmployees(this.DepartmentId);
            }
        }
    }

    public class DepartmentDataAccessLayer1
    {
        public static List<Department1> GetAllDepartmentsandEmployees()
        {
            List<Department1> listDepartments = new List<Department1>();

            string CS = ConfigurationManager.ConnectionStrings["GridEmployeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblDepartment", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Department1 department = new Department1();
                    department.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                    department.DepartmentName = rdr["Name"].ToString();

                    listDepartments.Add(department);
                }
            }

            return listDepartments;
        }
    }
}