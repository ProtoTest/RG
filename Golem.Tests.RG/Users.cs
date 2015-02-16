using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;

namespace Golem.Tests.RG
{
    class Users
    {
        public static User User1 = new User("RG_user1@mailinator.com","Test123!");
        public static User User2 = new User("RG_user2@mailinator.com","Test123!");
        public static User RandomUser1 = new User("RG_user" + Common.GetRandomString() + "_1@mailinator.com","Test123!");
        public static User RandomUser2 = new User("RG_user" + Common.GetRandomString() + "_2@mailinator.com", "Test123!");

        public class User
        {
            public User(string email, string password)
            {
                this.email = email;
                this.password = password;
            }
            public string email;
            public string password;
        }
    }
}
