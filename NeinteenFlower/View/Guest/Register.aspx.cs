using NeinteenFlower.Controller;
using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View.Guest
{
    public partial class Register : System.Web.UI.Page
    {
        private User activeUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                activeUser = UserHandler.GetActiveUser();

                if (activeUser != null) Response.Redirect("../Home.aspx");
            }
        }
        protected void registerButton_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            DateTime DOB = DateTime.Parse(ageTxt.Text);
            string gender = Request.Form["InputGender"];
            string address = addressTxt.Text;
            string phone = phonenumberTxt.Text;
            string email = emailTxt.Text;
            string password = passwordTxt.Text;

            string message = MemberController.CreateMember(name, DOB, gender, address, phone, email, password);

            if (message.Equals(""))
            {
                registerMsg.Text = "Success add new member!";
                registerMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                registerMsg.Text = message;
                registerMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}