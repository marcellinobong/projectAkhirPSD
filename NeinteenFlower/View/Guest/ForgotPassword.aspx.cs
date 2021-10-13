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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        private User activeUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                activeUser = UserHandler.GetActiveUser();

                if (activeUser != null) Response.Redirect("../Home.aspx");

                captchaCode.Text = MemberController.GetRandomCaptcha();
            }
        }

        protected void forgotpasswordButton_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string captcha = captchaCode.Text;
            string newpassword = newpasswordTxt.Text;

            string message = MemberController.ForgotPassword(email, captcha, newpassword);

            if (message.Equals(""))
            {
                forgotpasswordMsg.Text = "Success change password!";
                forgotpasswordMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                forgotpasswordMsg.Text = message;
                forgotpasswordMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}