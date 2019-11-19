// FileName: TestLogin.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 8/10/2019
using System;
using System.Collections.Generic;
using NUnit.Framework;
using PT13.src;

namespace PT13.Testing
{
    /// <summary>
    /// Login test.
    /// </summary>
    [TestFixture]
    public class LoginTest
    {
        /// <summary>
        /// Tests the login.
        /// </summary>
        [Test]
        public void TestLogin()
        {
            // Create users
            List<User> users = new List<User>
            {
                new Administrator("Admin", "Admin")
            };

            // Create main menu
            MainMenu main = new MainMenu();

            // Attempt Login with correct details
            bool loginAttempt = main.Login(users, "Admin", "Admin");
            Assert.AreEqual(true, loginAttempt, "Login Correctly");

            // Attempt Login with incorrect details
            bool loginAttempt2 = main.Login(users, "Admin", "dkfj");
            Assert.AreEqual(false, loginAttempt2, "Failed Login");
        }
    }
}
