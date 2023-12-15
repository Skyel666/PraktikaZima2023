using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromGruz
{
    public class UserInfo
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public UserInfo(string login, string password, string role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
