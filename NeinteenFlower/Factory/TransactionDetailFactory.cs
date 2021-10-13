using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class TransactionDetailFactory
    {
        public static TrDetail CreateTrDetail(int transactionId, int flowerId, int qty)
        {
            TrDetail data = new TrDetail();
            data.TransactionId = transactionId;
            data.FlowerId = flowerId;
            data.Quantity = qty;

            return data;
        }
    }
}