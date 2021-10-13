using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class FlowerTypeRepository
    {
        public static List<MsFlowerType> GetFlowerTypes()
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsFlowerTypes select data).ToList();
        }
        public static void InsertFlowerType(MsFlowerType ft)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            db.MsFlowerTypes.Add(ft);
            db.SaveChanges();
        }

        public static MsFlowerType GetFlowerTypeByID(int id)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return db.MsFlowerTypes.Find(id);
        }
    }
}