using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower
{
    public class Singleton
    {
        private static NeinteenFlowerEntities2 db;
        public static NeinteenFlowerEntities2 getDB()
        {
            if (db == null) db = new NeinteenFlowerEntities2();

            return db;
        }
    }
}