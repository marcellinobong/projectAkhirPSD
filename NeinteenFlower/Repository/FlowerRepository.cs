using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class FlowerRepository
    {
        public static List<MsFlowerModel> GetFlowers()
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from mf in db.MsFlowers
                           join mft in db.MsFlowerTypes on mf.FlowerTypeId equals mft.FlowerTypeId
                           select new MsFlowerModel
                           {
                               FlowerId = mf.FlowerId,
                               FlowerName = mf.FlowerName,
                               FlowerImage = mf.FlowerImage,
                               FlowerDescription = mf.FlowerDescription,
                               FlowerPrice = mf.FlowerPrice,
                               FlowerTypeName = mft.FlowerTypeName
                           }).ToList();
        }

        public static MsFlower GetFlowerByID(int id)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return db.MsFlowers.Find(id);
        }

        public static void InsertFlower(MsFlower f)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            db.MsFlowers.Add(f);
            db.SaveChanges();
        }

        public static void UpdateFlower(int id, string name, int typeId, string description, int price, string imageUrl)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            MsFlower flower = (from data in db.MsFlowers where data.FlowerId == id select data).FirstOrDefault();
            flower.FlowerName = name;
            flower.FlowerTypeId = typeId;
            flower.FlowerDescription = description;
            flower.FlowerPrice = price;
            flower.FlowerImage = imageUrl;

            db.SaveChanges();
        }

        public static void RemoveFlower(int id)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            MsFlower flower = db.MsFlowers.Single(f => f.FlowerId == id);

            db.MsFlowers.Remove(flower);
            db.SaveChanges();
        }
    }
}