using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
    public partial class Gridviewfooter33 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // Variable to hold employee count
        int employeeCount = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // If the row is Data row
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Increment employee count
                employeeCount += 1;
            }
            // If the row is a footer row
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                // Clear all the cells in the footer row
                e.Row.Cells.Clear();
                // Create a new table cell
                TableCell tableCell = new TableCell();
                // Set the ColumnSpan 
                tableCell.ColumnSpan = 4;
                // Set the Text alignment
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                // Set the text that you want to display in the footer
                tableCell.Text = "Total Employees Count = " + employeeCount.ToString();
                // Finally add the cell to the footer row
                e.Row.Cells.Add(tableCell);
            }
        }
    }
}