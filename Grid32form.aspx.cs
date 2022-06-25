using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
    public partial class Grid32form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource =
        DepartmentDataAccessLayer1.GetAllDepartmentsandEmployees();
            GridView1.DataBind();
        }
    }
}