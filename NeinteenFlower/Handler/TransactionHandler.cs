using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class TransactionHandler
    {
        // memberId, transacitonDate, flowerId, quantity
        public static TrHeader PreOrder(int memberId, DateTime transactionDate, int flowerId, int qty)
        {
            TrHeader tHeader = TransactionFactory.CreateTrHeader(memberId, transactionDate);
            TransactionRepository.InsertTransaction(tHeader);

            TrDetail tDetail = TransactionDetailFactory.CreateTrDetail(tHeader.TransactionId, flowerId, qty);
            TransactionDetailRepository.InsertTransactionDetail(tDetail);

            return tHeader;
        }

        public static List<TrHeader> GetMemberTransactions(int memberId)
        {
            return TransactionRepository.GetMemberTransactions(memberId);
        }
    }
}