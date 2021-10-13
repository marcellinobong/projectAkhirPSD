using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Model
{
    public class MsFlowerModel
    {
        public int FlowerId { get; set; }
        public string FlowerName { get; set; }
        public Nullable<int> FlowerTypeId { get; set; }
        public string FlowerDescription { get; set; }
        public int FlowerPrice { get; set; }
        public string FlowerImage { get; set; }
        public string FlowerTypeName { get; set; }
    }
}