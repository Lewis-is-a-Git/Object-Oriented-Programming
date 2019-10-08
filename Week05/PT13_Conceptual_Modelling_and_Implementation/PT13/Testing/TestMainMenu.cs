// FileName: TestMainMenu.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 8/10/2019
using System.Collections.Generic;
using NUnit.Framework;
using PT13.src;

namespace PT13.Testing
{
    /// <summary>
    /// Test main menu.
    /// </summary>
    [TestFixture]
    public class TestMainMenu
    {
        /// <summary>
        /// Tests the access permissions.
        /// </summary>
        [Test]
        public void TestAccessPermissions()
        {
            // create customer user
            List<User> users = new List<User>
            {
                new Admin("Admin", "Admin")
            };

            // Create main menu
            MainMenu main = new MainMenu();

            // Attempt Login with correct details
            bool loginAttempt = main.Login(users, "Admin", "Admin");
            Assert.IsTrue(loginAttempt, "The user has logged in");

            // test access to admin
            Assert.IsTrue(main.IsAdmin(), "The current user has access to admin");
            // Test access to sales
            Assert.IsFalse(main.IsSales(), "The current user is not sales");
        }
    }
}
