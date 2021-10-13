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
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        private static MsEmployee employee;
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

                string strId = Request.QueryString["id"];
                employee = null;

                if (strId != null)
                {
                    MsEmployee employee = EmployeeHandler.GetEmployeeByID(int.Parse(strId));
                    UpdateEmployee.employee = employee;

                    if (employee != null)
                    {
                        InputName.Text = employee.EmployeeName;
                        InputEmail.Text = employee.EmployeeEmail;
                        CalendarDOB.SelectedDate = employee.EmployeeDOB;
                        CalendarDOB.VisibleDate = employee.EmployeeDOB;
                        InputAddress.Text = employee.EmployeeAddress;
                        InputPhone.Text = employee.EmployeePhone.Trim();
                        InputSalary.Text = employee.EmployeeSalary.ToString();
                        DropDownListRole.SelectedValue = employee.EmployeeRole;

                        if (employee.EmployeeGender.Trim().Equals("Male")) RadioButtonMale.Checked = true;
                        else RadioButtonFemale.Checked = true;
                    }
                }

                if (strId == null || employee == null)
                {
                    Response.Redirect("/View/404.aspx");
                }
            }
            else
            {
                InputPassword.Attributes["value"] = InputPassword.Text;
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

            string message = EmployeeController.UpdateEmployee(employee.EmployeeId, name, email, password, DOB, gender, address, phone, salary, role);

            if (message.Equals(""))
            {
                LabelAlertMessage.Text = "Success update employee! Please press \"Back\" button to return to Manage Employee.";
                LabelAlertMessage.ForeColor = System.Drawing.Color.Green;

                InputPassword.Attributes["value"] = "";
            }
            else
            {
                LabelAlertMessage.Text = message;
                LabelAlertMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}