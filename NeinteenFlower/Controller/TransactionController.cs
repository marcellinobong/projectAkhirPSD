using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class TransactionController
    {
        public static string PreOrder(int memberId, DateTime transactionDate, int flowerId, int qty)
        {
            string message = "";

            if (qty < 1 || qty > 100) message += "Quantity Must be between 1 to 100.<br/ >";

            if (message.Equals(""))
            {
                TrHeader tHeader = TransactionHandler.PreOrder(memberId, transactionDate, flowerId, qty);
            }

            return message;
        }
    }
}