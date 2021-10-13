using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class MemberController
    {
        public static string Login(string email, string password)
        {
            string message = "";
            if (MemberHandler.GetMemberByEmail(email) == null) message += "Must be filled and appropriate with the data in the database <br/ >";
            if (MemberHandler.CheckMemberPassword(password) == null) message += "Must be filled and appropriate with the data in the database or Must be the same as the captcha in forgot password page";
            if (message.Equals(""))
            {
                MsMember member = MemberHandler.Login(email, password);
            }
            return message;

        }
        public static string ForgotPassword(string email, string captcha, string newpassword)
        {
            string message = "";
            if (MemberHandler.GetMemberByEmail(email) == null) message += "Email must exist in database <br/ >";
            if (!MemberHandler.CheckCaptcha(captcha, newpassword)) message += " Must be the same as captcha ";
            if (message.Equals(""))
            {
                MemberHandler.UpdatePassword(email, captcha);
            }
            return message;
        }
        public static string GetRandomCaptcha()
        {
            Random random = new Random();
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string letter = new string(Enumerable.Repeat(alphabet, 3).Select(l => l[random.Next(l.Length)]).ToArray());
            int number = random.Next(100, 1000);
            string captcha = letter + number.ToString();
            return captcha;
        }
        public static string CreateMember(string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            string message = "";

            if (MemberHandler.GetMemberByEmail(email) != null || !IsEmailValid(email)) message += "Email must be unique and correct format.<br/ >";
            if (password.Length < 3 || password.Length > 20) message += "Minimal length of password is 3 characters and 20 characters is the maximal.<br/ >";
            if (name.Length < 3 || name.Length > 20 || !name.Replace(" ", "").All(char.IsLetter)) message += "Minimal length of name is 3 characters and 20 characters is the maximal and must be letter.<br/ >";
            if (GetAge(DOB) < 17) message += "Minimal age is 17 years old.<br/ >";
            if (!(gender.Equals("Male") || gender.Equals("Female"))) message += "Gender must be chosen.<br/ >";
            if (!phone.All(char.IsDigit)) message += "Phone number must be numeric.<br/ >";
            if (!address.Contains("Street")) message += "Address must contain the word \"Street\"";

            if (message.Equals(""))
            {
                MsMember member = MemberHandler.InsertMember(name, DOB, gender, address, phone, email, password);
            }

            return message;
        }

        public static string UpdateMember(int id, string name, DateTime DOB, string gender, string address, string phone, string email, string password)
        {
            string message = "";
            
            if (MemberHandler.GetMemberByEmail(email) != null || !IsEmailValid(email)) message += "Email must be unique and correct format.<br/ >";
            if (password.Length < 3 || password.Length > 20) message += "Minimal length of password is 3 characters and 20 characters is the maximal.<br/ >";
            if (name.Length < 3 || name.Length > 20 || !name.Replace(" ", "").All(char.IsLetter)) message += "Minimal length of name is 3 characters and 20 characters is the maximal and must be letter.<br/ >";
            if (GetAge(DOB) < 17) message += "Minimal age is 17 years old.<br/ >";
            if (!(gender.Equals("Male") || gender.Equals("Female"))) message += "Gender must be chosen.<br/ >";
            if (!phone.All(char.IsDigit)) message += "Phone number must be numeric.<br/ >";
            if (!address.Contains("Street")) message += "Address must contain the word \"Street\"";

            if (message.Equals(""))
            {
                MemberHandler.UpdateMember(id, name, DOB, gender, address, phone, email, password);
            }

            return message;
        }

        private static double GetAge(DateTime DOB)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - DOB.Year;
            if (now.Month > DOB.Month || (now.Month == DOB.Month && now.Day < DOB.Day)) --age;

            return age;
        }

        private static bool IsEmailValid(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}