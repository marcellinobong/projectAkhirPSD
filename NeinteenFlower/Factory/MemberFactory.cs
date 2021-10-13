using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class MemberFactory
    {
        public static MsMember CreateMember(string name, DateTime DOB, string gender, string address, string phone, string email, string password, string role = "Member")
        {
            MsMember data = new MsMember();
            data.MemberRole = role;
            data.MemberName = name;
            data.MemberDOB = DOB;
            data.MemberGender = gender;
            data.MemberAddress = address;
            data.MemberPhone = phone;
            data.MemberEmail = email;
            data.MemberPassword = password;

            return data;
        }
    }
}