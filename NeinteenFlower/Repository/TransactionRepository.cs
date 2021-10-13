using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class TransactionRepository
    {
        public static void InsertTransaction(TrHeader t)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            db.TrHeaders.Add(t);
            db.SaveChanges();
        }

        public static List<TrHeader> GetMemberTransactions(int memberId)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.TrHeaders where data.MemberId == memberId select data).ToList();
        }

        public static TrDetail GetTransactionDetail(int transactionId)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.TrDetails where data.TransactionId == transactionId select data).FirstOrDefault();
        }
    }
}