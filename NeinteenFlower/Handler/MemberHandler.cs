using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class MemberHandler
    {
        public static MsMember CheckMemberPassword(string password)
        {
            return MemberRepository.CheckMemberPassword(password);
        }
        public static MsMember Login(string email, string password)
        {
            return MemberRepository.Login(email, password);
        }
        public static bool CheckCaptcha(string captchaCode, string userAnswer)
        {
            return MemberRepository.CheckCaptcha(captchaCode, userAnswer);
        }
        public static void UpdatePassword(string email, string captcha)
        {
            MemberRepository.UpdatePassword(email, captcha);
        }
        public static List<MsMember> GetMembers()
        {
            return MemberRepository.GetMembers();
        }

        public static MsMember GetMemberByEmail(string email)
        {
            return MemberRepository.GetMemberByEmail(email);
        }

        public static MsMember GetMemberById(int id)
        {
            return MemberRepository.GetMemberById(id);
        }

        public static MsMember InsertMember(string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            MsMember member = MemberFactory.CreateMember(name, DOB, gender, address, phone, email, password);

            MemberRepository.InsertMember(member);

            return member;
        }

        public static void UpdateMember(int id, string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            MemberRepository.UpdateMember(id, name, DOB, gender, address, phone, email, password);
        }

        public static void RemoveMember(int id)
        {
            MemberRepository.RemoveMember(id);
        }
    }
}