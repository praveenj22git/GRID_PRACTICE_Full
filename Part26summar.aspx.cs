using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
    public partial class Part26summar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        int totalUnitPrice = 0;
        int totalQuanitySold = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Loop thru each data row and compute total unit price and quantity sold
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalUnitPrice += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
                totalQuanitySold += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QuantitySold"));
            }
            // Display totals in the gridview footer
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[1].Font.Bold = true;

                e.Row.Cells[2].Text = totalUnitPrice.ToString();
                e.Row.Cells[2].Font.Bold = true;

                e.Row.Cells[3].Text = totalQuanitySold.ToString();
                e.Row.Cells[3].Font.Bold = true;
            }
        }
    }
}