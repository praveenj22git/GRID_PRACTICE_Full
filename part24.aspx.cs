using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
    public partial class part24 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbInsert_Click(object sender, EventArgs e)
        {
            ObjectDataSource1.InsertParameters["Name"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
            ObjectDataSource1.InsertParameters["Gender"].DefaultValue =
                ((DropDownList)GridView1.FooterRow.FindControl("ddlInsertGender")).SelectedValue;
            ObjectDataSource1.InsertParameters["City"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
            ObjectDataSource1.Insert();
        }
    }
}