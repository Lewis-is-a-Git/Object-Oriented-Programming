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
    /// User management test.
    /// </summary>
    [TestFixture]
    public class UserManagementTest
    {
        /// <summary>
        /// Tests the create new user.
        /// </summary>
        [Test]
        public void TestCreateNewUser()
        {
            List<User> users = new List<User>();
            // Create Admin
            Administrator admin = new Administrator("Admin", "Password");

            // Admin Creates a new user
            users = admin.CreateUser(users, "sales", "sales", "sales");
            Assert.AreEqual(1, users.Count, "Admin created Sales user and added to users");
        }

        /// <summary>
        /// Tests the reset password.
        /// </summary>
        [Test]
        public void TestResetPassword()
        {
            string oldPass = "Pass";
            string newPass = "password";
            Customer customer = new Customer("User", oldPass);
            customer.ResetPassword(oldPass, newPass);
            Assert.AreEqual(newPass, customer.Password, "The users password is reset to password");
        }

        /// <summary>
        /// Tests the delete user.
        /// </summary>
        [Test]
        public void TestDeleteUser()
        {
            List<User> users = new List<User>();
            // Create Admin
            Administrator admin = new Administrator("Admin", "Password");
            DeliveryPerson deliveryBoi = new DeliveryPerson("Duser", "Dpass");
            users.Add(admin);
            Assert.AreEqual(1, users.Count, "Admin created.");

            // Add User to delete to users
            users.Add(deliveryBoi);
            // Delete user from users
            users = admin.DeleteUser(users, "Duser");

            CollectionAssert.DoesNotContain(users, deliveryBoi, "User deleted from users.");
        }
    }
}
