// FileName: UserManagement.cs
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
    /// Test User management.
    /// </summary>
    [TestFixture]
    public class TestUserManagement
    {
        /// <summary>
        /// Tests the create new user.
        /// </summary>
        [Test]
        public void TestCreateNewUser()
        {
            List<User> users = new List<User>();
            // Create Admin
            Admin admin = new Admin("Admin", "Password")
            {
                Credentials = "admin"
            };

            // Admin Creates a new user
            users = admin.CreateUser(users, "sales");
            Assert.AreEqual(1, users.Count, "Admin created Sales user and added to users");
        }

        /// <summary>
        /// Tests the delete user.
        /// </summary>
        [Test]
        public void TestDeleteUser()
        {
            List<User> users = new List<User>();
            // Create Admin
            Admin admin = new Admin("Admin", "Password")
            {
                Credentials = "admin"
            };
            Delivery deliveryBoi = new Delivery("Duser", "Dpass");
            users.Add(admin);
            Assert.AreEqual(1, users.Count, "Admin created.");

            // Add User to delete to users
            users.Add(deliveryBoi);
            // Delete user from users
            users = admin.DeleteUser(users, "Duser");

            Assert.Contains(deliveryBoi, users, "User deleted from users.");
        }
    }
    }
}
