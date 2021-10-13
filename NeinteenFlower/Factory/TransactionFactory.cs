using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class TransactionFactory
    {
        public static TrHeader CreateTrHeader(int memberId, DateTime transactionDate)
        {
            TrHeader data = new TrHeader();
            data.MemberId = memberId;
            data.TransactionDate = transactionDate;

            return data;
        }
    }
}