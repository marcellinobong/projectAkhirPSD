using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class UserController
    {
        public static string Login(string email, string password, bool rememberMeStatus)
        {
            string message = "";

            User activeUser = UserHandler.Login(email, password);

            if (!activeUser.loggedIn) message += "Must be filled and appropriate with the data in the database <br/ >";
            else
            {
                HttpContext.Current.Session.Add("activeUser", activeUser);

                if (rememberMeStatus)
                {
                    HttpCookie cookie = new HttpCookie("activeUser");
                    cookie.Value = activeUser.email + "|" + activeUser.password;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }

            return message;
        }
    }
}