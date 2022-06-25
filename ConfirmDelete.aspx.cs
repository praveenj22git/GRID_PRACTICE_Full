using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
    public partial class ConfirmDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            lblMessage.Visible = true;
            // AffectedRows property will be zero, if no rows are deleted
            if (e.AffectedRows > 0)
            {
                lblMessage.Text = "Employee row with EmployeeID = \""
                    + e.Keys[0].ToString() + "\" is successfully deleted";
                lblMessage.ForeColor = System.Drawing.Color.Navy;
            }
            else
            {
                lblMessage.Text = "Employee Row with EmployeeID = \""
                    + e.Keys[0].ToString() + "\" is not deleted due to data conflict";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}