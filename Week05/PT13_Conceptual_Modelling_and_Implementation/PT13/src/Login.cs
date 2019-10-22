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

        // Used to reset password
        public Login(string userName) : this(userName, "password") { }

        public Login(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public string UserName { get => _userName; }
        public string Password { get => _password; }
    }

}