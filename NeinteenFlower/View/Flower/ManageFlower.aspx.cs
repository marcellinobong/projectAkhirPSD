using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View.Flower
{
    public partial class ManageFlower : System.Web.UI.Page
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
                    if (!activeUser.role.Equals("Employee")) Response.Redirect("../Home.aspx");
                }

                List<MsFlowerModel> flowers = FlowerHandler.GetFlowers();

                RepeaterFlower.DataSource = flowers;
                RepeaterFlower.DataBind();
            }
        }

        protected void BtnAddNewFlower_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertFlower.aspx");
        }

        protected void BtnEditFlower_Command(object sender, CommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();

            Response.Redirect("UpdateFlower.aspx?id=" + int.Parse(strId));
        }

        protected void BtnRemoveFlower_Command(object sender, CommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();

            FlowerHandler.RemoveFlower(int.Parse(strId));

            Response.Redirect(Request.RawUrl);
        }
    }
}