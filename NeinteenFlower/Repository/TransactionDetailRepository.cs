using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class TransactionDetailRepository
    {
        public static void InsertTransactionDetail(TrDetail t)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            db.TrDetails.Add(t);
            db.SaveChanges();
        }
    }
}