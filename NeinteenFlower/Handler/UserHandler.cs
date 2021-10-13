using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class UserHandler
    {
        public static User Login(string email, string password)
        {
            MsMember member = UserRepository.GetMemberByEmailPassword(email, password);

            User activeUser = new User();
            
            if (member != null)
            {
                activeUser.id = member.MemberId;
                activeUser.role = member.MemberRole;
                activeUser.name = member.MemberName;
                activeUser.email = member.MemberEmail;
                activeUser.password = member.MemberPassword;
                activeUser.loggedIn = true;
            } 
            else
            {
                MsEmployee employee = UserRepository.GetEmployeeByEmailPassword(email, password);

                if (employee != null)
                {
                    activeUser.id = employee.EmployeeId;
                    activeUser.role = employee.EmployeeRole;
                    activeUser.name = employee.EmployeeName;
                    activeUser.email = employee.EmployeeEmail;
                    activeUser.password = employee.EmployeePassword;
                    activeUser.loggedIn = true;
                } 
                else
                {
                    activeUser.loggedIn = false;
                }
            }



            return activeUser;
        }

        public static User GetActiveUser()
        {
            return (User)HttpContext.Current.Session["activeUser"];
        }

        public static string GetActiveUserCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["activeUser"];
            if (cookie != null)
            {
                return cookie.Value;        
            } 
            else
            {
                return "null";
            }
        }

        public static void DestroyUserCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["activeUser"];
            cookie.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Remove("activeUser");
            HttpContext.Current.Response.SetCookie(cookie);
        }
    }
}