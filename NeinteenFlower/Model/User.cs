using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Model
{
    public class User
    {
        public int id;
        public string role, name, email, password;
        public bool loggedIn;
    }
}