using NeinteenFlower.Controller;
using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View.Member
{
    public partial class EditMember : System.Web.UI.Page
    {
        public MsMember member;
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
                bool hasMember = false;

                if (strId != null)
                {
                    MsMember member = MemberHandler.GetMemberById(int.Parse(strId));
                    this.member = member;

                    if (member != null)
                    {
                        InputId.Text = member.MemberId.ToString();
                        InputName.Text = member.MemberName;
                        InputDOB.Text = member.MemberDOB.ToString();
                        InputAddress.Text = member.MemberAddress;
                        InputPhone.Text = member.MemberPhone.ToString().Trim();
                        InputEmail.Text = member.MemberEmail;
                        
                        hasMember = true;
                    }
                }

                if (!hasMember)
                {
                    Response.Redirect("/View/404.aspx");
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(InputId.Text);
            string name = InputName.Text;
            DateTime DOB = DateTime.Parse(InputDOB.Text);
            string gender = Request.Form["InputGender"];
            string address = InputAddress.Text;
            string phone = InputPhone.Text;
            string email = InputEmail.Text;
            string password = InputPassword.Text;

            string message = MemberController.UpdateMember(id, name, DOB, gender, address, phone, email, password);

            if (message.Equals(""))
            {
                LabelAlertMessage.Text = "Success update member!";
                LabelAlertMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LabelAlertMessage.Text = message;
                LabelAlertMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ButtonBackToManagePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMember.aspx");
        }
    }
}