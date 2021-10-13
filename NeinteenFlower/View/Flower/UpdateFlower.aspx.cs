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
    public partial class EditFlower : System.Web.UI.Page
    {
        public MsFlower flower;
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

                string strId = Request.QueryString["id"];
                bool hasFlower = false;

                if (strId != null)
                {
                    MsFlower flower = FlowerHandler.GetFlower(int.Parse(strId));
                    this.flower = flower;

                    if (flower != null)
                    {
                        InputId.Text = flower.FlowerId.ToString();
                        InputName.Text = flower.FlowerName;
                        InputDescription.Text = flower.FlowerDescription;
                        InputPrice.Text = flower.FlowerPrice.ToString();

                        List<MsFlowerType> flowerTypes = FlowerTypeRepository.GetFlowerTypes();
                        RepeaterFlowerType.DataSource = flowerTypes;
                        RepeaterFlowerType.DataBind();

                        hasFlower = true;
                    }
                }

                if (!hasFlower)
                {
                    Response.Redirect("/View/404.aspx");
                }
            }
            
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(InputId.Text);
            string name = InputName.Text;
            int typeId = int.Parse(Request.Form["InputTypeId"]);
            int price = int.Parse(InputPrice.Text);
            string description = InputDescription.Text;

            var file = InputImage.PostedFile;
            string imageUrl = "Picture/" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "-";

            string message = FlowerController.UpdateFlower(id, name, typeId, description, price, imageUrl + Uri.EscapeDataString(file.FileName));

            if (message.Equals(""))
            {
                file.SaveAs(MapPath("~/" + imageUrl + file.FileName));

                LabelAlertMessage.Text = "Success update flower!";
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