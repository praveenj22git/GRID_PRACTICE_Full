using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRID_PRACTICE
{
        public partial class DeleteMul28 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // Load data on initial get request
                if (!IsPostBack)
                {
                    GetData();
                }
            }

            // Method to retrieve data and bind to gridview
            public void GetData()
            {
                GridView1.DataSource = EmployeeDataAccessLayer3.GetAllEmployees();
                GridView1.DataBind();
            }

            // Eventhandler method to select or deselect all rows depending
            // on if the checkbox in header row is selected or deselected



            protected void cbDeleteHeader_CheckedChanged(object sender, EventArgs e)
            {
                foreach (GridViewRow gridViewRow in GridView1.Rows)
                {
                    ((CheckBox)gridViewRow.FindControl("cbDelete")).Checked = ((CheckBox)sender).Checked;
                }
            }

            // Select or deselect the checkbox in the header row, when the selection
            // of checkboxes in gridview data rows change
            protected void cbDelete_CheckedChanged(object sender, EventArgs e)
            {
                CheckBox headerCheckBox =
                    (CheckBox)GridView1.HeaderRow.FindControl("cbDeleteHeader");
                if (headerCheckBox.Checked)
                {
                    headerCheckBox.Checked = ((CheckBox)sender).Checked;
                }
                else
                {
                    bool allCheckBoxesChecked = true;
                    foreach (GridViewRow gridViewRow in GridView1.Rows)
                    {
                        if (!((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                        {
                            allCheckBoxesChecked = false;
                            break;
                        }
                    }
                    headerCheckBox.Checked = allCheckBoxesChecked;
                }
            }

            // Method to delete selected employee rows in gridview
            protected void btnDelete_Click(object sender, EventArgs e)
            {
                List<string> lstEmployeeIdsToDelete = new List<string>();
                foreach (GridViewRow gridViewRow in GridView1.Rows)
                {
                    if (((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                    {
                        string employeeId =
                            ((Label)gridViewRow.FindControl("lblEmployeeId")).Text;
                        lstEmployeeIdsToDelete.Add(employeeId);
                    }
                }
                if (lstEmployeeIdsToDelete.Count > 0)
                {
                    EmployeeDataAccessLayer3.DeleteEmployees(lstEmployeeIdsToDelete);
                    GetData();
                    lblMessage.ForeColor = System.Drawing.Color.Navy;
                    lblMessage.Text = lstEmployeeIdsToDelete.Count.ToString() +
                        " row(s) deleted";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "No rows selected to delete";
                }
            }
        }
    }