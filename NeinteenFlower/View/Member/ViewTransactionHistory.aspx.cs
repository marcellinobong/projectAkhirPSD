using NeinteenFlower.DataSet;
using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View.Member
{
    public partial class ViewTransactionHistory : System.Web.UI.Page
    {
        private User activeUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            activeUser = UserHandler.GetActiveUser();

            if (activeUser == null) Response.Redirect("../Guest/Login.aspx");
            else
            {
                if (!activeUser.role.Equals("Member")) Response.Redirect("../Home.aspx");
            }

            List<TrHeader> transactions = TransactionHandler.GetMemberTransactions(activeUser.id);

            NeinteenFlowerDS allData = GetAllData(transactions);

            NeinteenFlowerCR cr = new NeinteenFlowerCR();
            cr.SetDataSource(allData);
            cr.Refresh();

            CR.ReportSource = cr;
        }

        protected NeinteenFlowerDS GetAllData(List<TrHeader> transactions)
        {
            NeinteenFlowerDS dataSet = new NeinteenFlowerDS();
            var tHeader = dataSet.TrHeader;
            var tDetail = dataSet.TrDetail;
            var msFlower = dataSet.MsFlower;
            var msFlowerType = dataSet.MsFlowerType;
            var msMember = dataSet.MsMember;

            foreach (TrHeader t in transactions)
            {
                var tRow = tHeader.NewRow();
                tRow["TransactionId"] = t.TransactionId;
                tRow["MemberId"] = t.MemberId;
                tRow["TransactionDate"] = t.TransactionDate;
                tHeader.Rows.Add(tRow);

                TrDetail trDetail = TransactionRepository.GetTransactionDetail(t.TransactionId);

                var tdRow = tDetail.NewRow();
                tdRow["TransactionDetailId"] = trDetail.TransactionDetailId;
                tdRow["TransactionId"] = trDetail.TransactionId;
                tdRow["FlowerId"] = trDetail.FlowerId;
                tdRow["Quantity"] = trDetail.Quantity;
                tdRow["SubTotal"] = trDetail.Quantity * trDetail.MsFlower.FlowerPrice;
                tdRow["GrandTotal"] = trDetail.Quantity * trDetail.MsFlower.FlowerPrice;
                tDetail.Rows.Add(tdRow);

                var fRow = msFlower.NewRow();
                fRow["FlowerId"] = trDetail.MsFlower.FlowerId;
                fRow["FlowerName"] = trDetail.MsFlower.FlowerName; 
                fRow["FlowerTypeId"] = trDetail.MsFlower.FlowerTypeId;
                fRow["FlowerPrice"] = trDetail.MsFlower.FlowerPrice;
                msFlower.Rows.Add(fRow);

                var ftRow = msFlowerType.NewRow();
                ftRow["FlowerTypeId"] = trDetail.MsFlower.MsFlowerType.FlowerTypeId;
                ftRow["FlowerTypeName"] = trDetail.MsFlower.MsFlowerType.FlowerTypeName;
                msFlowerType.Rows.Add(ftRow);

                var mRow = msMember.NewRow();
                mRow["MemberId"] = t.MsMember.MemberId;
                mRow["MemberName"] = t.MsMember.MemberName;
                mRow["MemberPhone"] = t.MsMember.MemberPhone;
                mRow["MemberEmail"] = t.MsMember.MemberEmail;
                msMember.Rows.Add(mRow);
            }

            return dataSet;
        }
    }
}