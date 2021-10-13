using NeinteenFlower.Controller;
using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View.Flower
{
    public partial class CreateFlower : System.Web.UI.Page
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

                List<MsFlowerType> flowerTypes = FlowerTypeRepository.GetFlowerTypes();

                RepeaterFlowerType.DataSource = flowerTypes;
                RepeaterFlowerType.DataBind();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string name = InputName.Text;
            int typeId = int.Parse(Request.Form["InputTypeId"]);
            int price = int.Parse(InputPrice.Text);
            string description = InputDescription.Text;

            var file = InputImage.PostedFile;
            string imageUrl = "Picture/" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "-";

            string message = FlowerController.CreateFlower(name, typeId, description, price, imageUrl + Uri.EscapeDataString(file.FileName));

            if (message.Equals(""))
            {
                file.SaveAs(MapPath("~/" + imageUrl + file.FileName));
                
                LabelAlertMessage.Text = "Success add new flower!";
                LabelAlertMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LabelAlertMessage.Text = message;
                LabelAlertMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}