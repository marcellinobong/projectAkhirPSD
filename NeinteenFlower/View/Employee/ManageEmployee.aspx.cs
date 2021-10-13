using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View.Employee
{
    public partial class ManageEmployee : System.Web.UI.Page
    {
        private User activeUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                activeUser = UserHandler.GetActiveUser();

                if (activeUser == null) Response.Redirect("../Guest/Login.aspx");
                else
                {
                    if (!activeUser.role.Equals("Administrator") && !activeUser.role.Equals("Admin")) Response.Redirect("../Home.aspx");
                }

                showEmployeeList();
            }
        }

        private void showEmployeeList()
        {
            List<MsEmployee> EmployeeList = EmployeeHandler.GetEmployees();

            EmployeeTable.DataSource = EmployeeList;
            EmployeeTable.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertEmployee.aspx");
        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();

            Response.Redirect("UpdateEmployee.aspx?id=" + int.Parse(strId));
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();

            EmployeeHandler.DeleteEmployeeByID(int.Parse(strId));

            Response.Redirect("ManageEmployee.aspx");
        }

        protected void ButtonBackToHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home.aspx");
        }
    }
}