// FileName: User.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Security.Cryptography;
using System.Text;

namespace PT13.src
{
    internal class Login
    {
        private readonly string _userName;
        private readonly string _password;

        public Login()
        {
            Console.WriteLine("Creating new user...");
            Console.WriteLine("Please enter a username: ");
            _userName = Console.ReadLine();
            Console.WriteLine("Please enter a password: ");
            _password = Console.ReadLine();
        }

        public Login(string userName) : this(userName, "password")
        {

        }

        public Login(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public string UserName { get => _userName; }
        public string Password { get => _password; }
        public string Credentials
        {
            // Login Verification
            get
            {
                string credentials = "";
                if (_userName == "Admin" && _password == "Admin")
                {
                    credentials = "admin";
                }
                if (_userName == "Sales" && _password == "Sales")
                {
                    credentials = "sales";
                }
                if (_userName == "Delivery" && _password == "Delivery")
                {
                    credentials = "delivery";
                }
                if (_userName == "Customer" && _password == "Customer")
                {
                    credentials = "customer";
                }

                return credentials;

            }
        }

    }
}