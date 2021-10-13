using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class FlowerController
    {
        public static string CreateFlower(string name, int typeId, string description, int price, string imageUrl)
        {
            string message = "";

            if (name.Length < 5) message += "Minimal length of name is 5 characters.<br/ >";
            if (!imageUrl.EndsWith(".jpg")) message += "Flower image must be an .jpg file.<br/ >";
            if (description.Length <= 50) message += "Description must be longer than 50 characters.<br/ >";

            MsFlowerType flowerType = FlowerTypeHandler.GetFlowerType(typeId);
            string flowerTypeName = flowerType.FlowerTypeName;
            string[] correctFlowerTypeName = { "Daisies", "Lilies", "Roses" };
            if (!correctFlowerTypeName.Contains(flowerTypeName)) message += "Flower type must be either \"Daisies\", \"Lilies\" or \"Roses\".<br/ >";

            if (price < 20 || price > 100) message += "Price must be numeric and between 20 and 100.<br/ >";

            if (message.Equals(""))
            {
                MsFlower flower = FlowerHandler.InsertFlower(name, typeId, description, price, imageUrl);
            }

            return message;
        }

        public static string UpdateFlower(int id, string name, int typeId, string description, int price, string imageUrl)
        {
            string message = "";

            if (name.Length < 5) message += "Minimal length of name is 5 characters.<br/ >";
            if (!imageUrl.EndsWith(".jpg")) message += "Flower image must be an .jpg file.<br/ >";
            if (description.Length <= 50) message += "Description must be longer than 50 characters.<br/ >";

            MsFlowerType flowerType = FlowerTypeHandler.GetFlowerType(typeId);
            string flowerTypeName = flowerType.FlowerTypeName;
            string[] correctFlowerTypeName = { "Daisies", "Lilies", "Roses" };
            if (!correctFlowerTypeName.Contains(flowerTypeName)) message += "Flower type must be either \"Daisies\", \"Lilies\" or \"Roses\".<br/ >";

            if (price < 20 || price > 100) message += "Price must be numeric and between 20 and 100.<br/ >";

            if (message.Equals(""))
            {
                FlowerHandler.UpdateFlower(id, name, typeId, description, price, imageUrl);
            }

            return message;
        }
    }
}