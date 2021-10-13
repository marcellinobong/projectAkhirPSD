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
    public partial class ManageMember : System.Web.UI.Page
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

                List<MsMember> members = MemberHandler.GetMembers();

                MemberTable.DataSource = members;
                MemberTable.DataBind();
            }
        }
        protected void BtnAddNewMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMember.aspx");
        }

        protected void btnUpdateMember_Command(object sender, CommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();

            Response.Redirect("UpdateMember.aspx?id=" + int.Parse(strId));
        }

        protected void btnDeleteMember_Command(object sender, CommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();

            MemberHandler.RemoveMember(int.Parse(strId));

            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonBackToHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home.aspx");
        }
    }
}