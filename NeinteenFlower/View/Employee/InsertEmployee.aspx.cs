using NeinteenFlower.Controller;
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
    public partial class InsertEmployee : System.Web.UI.Page
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

                Page.DataBind();
                CalendarDOB.VisibleDate = DateTime.Today.AddYears(-17);
            }
        }

        protected void ButtonBackToManagePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageEmployee.aspx");
        }

        protected void ButtonCalendarDOBPrevYear_Click(object sender, EventArgs e)
        {
            CalendarDOB.VisibleDate = CalendarDOB.VisibleDate.AddYears(-1);
        }

        protected void ButtonCalendarDOBNextYear_Click(object sender, EventArgs e)
        {
            CalendarDOB.VisibleDate = CalendarDOB.VisibleDate.AddYears(1);
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string name = InputName.Text;
            string email = InputEmail.Text;
            string password = InputPassword.Text;
            DateTime DOB = CalendarDOB.SelectedDate;
            string gender = RadioButtonMale.Checked ? RadioButtonMale.Text : RadioButtonFemale.Checked ? RadioButtonFemale.Text : "";
            string address = InputAddress.Text;
            string phone = InputPhone.Text;
            string salary = InputSalary.Text;
            string role = DropDownListRole.SelectedValue;

            string message = EmployeeController.InsertEmployee(name, email, password, DOB, gender, address, phone, salary, role);

            if (message.Equals(""))
            {
                LabelAlertMessage.Text = "Success add new employee! Please press \"Back\" button to return to Manage Employee.";
                LabelAlertMessage.ForeColor = System.Drawing.Color.Green;

                InputName.Text = "";
                InputEmail.Text = "";
                CalendarDOB.VisibleDate = DateTime.Today;
                RadioButtonMale.Checked = false;
                RadioButtonFemale.Checked = false;
                InputAddress.Text = "";
                InputPhone.Text = "";
                InputSalary.Text = "";
                DropDownListRole.SelectedIndex = 0;

            }
            else
            {
                LabelAlertMessage.Text = message;
                LabelAlertMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}