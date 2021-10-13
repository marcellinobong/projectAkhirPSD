using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class FlowerTypeFactory
    {
        public static MsFlowerType CreateFlowerType(string name)
        {
            MsFlowerType data = new MsFlowerType();
            data.FlowerTypeName = name;

            return data;
        }
    }
}