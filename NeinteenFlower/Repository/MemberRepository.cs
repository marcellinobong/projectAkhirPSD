using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class MemberRepository
    {
        public static MsMember CheckMemberPassword(string password)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsMembers where data.MemberPassword.Equals(password) select data).FirstOrDefault();
        }
        public static MsMember Login(string email, string password)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsMembers where data.MemberEmail.Equals(email) && data.MemberPassword.Equals(password) select data).FirstOrDefault(); ;
        }
        public static bool CheckCaptcha(string captchaCode, string userAnswer)
        {
            if (captchaCode.Equals(userAnswer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void UpdatePassword(string email, string captcha)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();
            MsMember data = (from x in db.MsMembers where x.MemberEmail == email select x).FirstOrDefault();
            data.MemberPassword = captcha;

            db.SaveChanges();
        }
        public static List<MsMember> GetMembers()
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsMembers select data).ToList();
        }

        public static MsMember GetMemberById(int id)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsMembers where data.MemberId.Equals(id) select data).FirstOrDefault();
        }

        public static MsMember GetMemberByEmail(string email)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            return (from data in db.MsMembers where data.MemberEmail.Equals(email) select data).FirstOrDefault();
        }

        public static void InsertMember(MsMember m)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            db.MsMembers.Add(m);
            db.SaveChanges();
        }

        public static void UpdateMember(int id, string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            MsMember data = (from x in db.MsMembers where x.MemberId == id select x).FirstOrDefault();
            data.MemberName = name;
            data.MemberDOB = DOB;
            data.MemberGender = gender;
            data.MemberAddress = address;
            data.MemberPhone = phone;
            data.MemberEmail = email;
            data.MemberPassword = password;

            db.SaveChanges();
        }

        public static void RemoveMember(int id)
        {
            NeinteenFlowerEntities2 db = Singleton.getDB();

            MsMember member = db.MsMembers.Single(m => m.MemberId == id);

            db.MsMembers.Remove(member);
            db.SaveChanges();
        }
    }
}