using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class FlowerHandler
    {
        public static List<MsFlowerModel> GetFlowers()
        {
            return FlowerRepository.GetFlowers();
        }

        public static MsFlower GetFlower(int id)
        {
            return FlowerRepository.GetFlowerByID(id);
        }
        public static MsFlower InsertFlower(string name, int typeId, string description, int price, string imageUrl)
        {
            MsFlower flower = FlowerFactory.CreateFlower(name, typeId, description, price, imageUrl);

            FlowerRepository.InsertFlower(flower);

            return flower;
        }

        public static void UpdateFlower(int id, string name, int typeId, string description, int price, string imageUrl)
        {
            FlowerRepository.UpdateFlower(id, name, typeId, description, price, imageUrl);
        }

        public static void RemoveFlower(int id)
        {
            FlowerRepository.RemoveFlower(id);
        }
    }
}