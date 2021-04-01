using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRN_Final_Project.Models
{
    public class User
    {
        private string username;
        private string password;
        private string email;
        private string fullname;

        public User(string username, string password, string email, string fullname)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Fullname = fullname;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Fullname { get => fullname; set => fullname = value; }

    }
}