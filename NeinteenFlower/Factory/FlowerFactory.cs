using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class FlowerFactory
    {
        public static MsFlower CreateFlower(string name, int typeId, string description, int price, string imageUrl) 
        {
            MsFlower data = new MsFlower();
            data.FlowerName = name;
            data.FlowerTypeId = typeId;
            data.FlowerDescription = description;
            data.FlowerPrice = price;
            data.FlowerImage = imageUrl;

            return data;
        }
    }
}