using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
    public partial class inertdetailview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                GridView2.Visible = false;
            }
            else
            {
                GridView2.Visible = true;
            }
        }
    }
}