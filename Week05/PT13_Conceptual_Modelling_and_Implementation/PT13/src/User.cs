﻿// FileName: User.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
namespace PT13.src
{
    public abstract class User
    {
        protected String _userName;
        private Login _loginID;
        protected String _credentials;
        protected String _password;

        protected User()
        {
            LoginID = new Login();
        }

        protected User(string username, string password)
        {
            LoginID = new Login(username, password);
        }

        public string Credentials { get => _credentials; set => _credentials = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; }
        internal Login LoginID
        {
            set
            {
                _loginID = value;
                _userName = _loginID.UserName;
                _password = _loginID.Password;
            }
        }

        public void ResetPassword()
        {
            LoginID = new Login(_userName);
            Console.WriteLine("Password reset to: password");
        }
    }
}
