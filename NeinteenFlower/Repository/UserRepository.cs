using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class UserRepository
    {
        public static MsMember GetMemberByEmailPassword(string email, string password)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsMembers where data.MemberEmail.Equals(email) && data.MemberPassword.Equals(password) select data).FirstOrDefault(); ;
        }
        public static MsEmployee GetEmployeeByEmailPassword(string email, string password)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsEmployees where data.EmployeeEmail.Equals(email) && data.EmployeePassword.Equals(password) select data).FirstOrDefault(); ;
        }
    }
}