using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
    public partial class InsertUpdatedeletepart23 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void lbInsert_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;



            SqlDataSource1.InsertParameters["Gender"].DefaultValue =
                ((DropDownList)GridView1.FooterRow.FindControl("ddlInsertGender")).SelectedValue;
            SqlDataSource1.InsertParameters["City"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
            SqlDataSource1.Insert();
        }
    }
}