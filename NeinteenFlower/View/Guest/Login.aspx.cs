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
    public partial class Login : System.Web.UI.Page
    {
        private User activeUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                activeUser = UserHandler.GetActiveUser();

                if (activeUser != null) Response.Redirect("../Home.aspx");

                string userCookie = UserHandler.GetActiveUserCookie();
                if (userCookie != "null")
                {
                    string email = userCookie.Split('|')[0];
                    string password = userCookie.Split('|')[1];

                    emailTxt.Text = email;
                    passwordTxt.Attributes.Add("value", password);
                    rememberMe.Checked = true;
                } 
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            bool rememberMeStatus = rememberMe.Checked;
            string message = UserController.Login(email, password, rememberMeStatus);
            if (message.Equals(""))
            {
                Response.Redirect("../Home.aspx");
            }
            else
            {
                loginMsg.Text = message;
                loginMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}