// FileName: Admin.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;
namespace PT13.src
{
    public class Admin : User
    {
        public Admin() { }
        public Admin(string username, string password) : base(username, password) { }

        public List<User> CreateUser(List<User> users)
        {
            Console.WriteLine("Choose what kind of user to create...");
            Console.WriteLine("To create a new admin press: admin");
            Console.WriteLine("To create a new sales press: sales");
            Console.WriteLine("To create a new delivery press: delivery");
            Console.WriteLine("To create a new customer press: customer");
            string choice = "";
            choice = Console.ReadLine().ToLower();
            users = CreateUser(users, choice);
            return users;
        }

        /// <summary>
        /// Second Create User class to bypass the Console.ReadLine() for testing
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="users">Users.</param>
        /// <param name="choice">Choice.</param>
        public List<User> CreateUser(List<User> users, string choice)
        {
            switch (choice)
            {
                case ("admin"):
                    users.Add(new Admin
                    {
                        Credentials = "admin"
                    });
                    break;
                case ("sales"):
                    users.Add(new Sales
                    {
                        Credentials = "sales"
                    });
                    break;
                case ("delivery"):
                    users.Add(new Delivery
                    {
                        Credentials = "delivery"
                    });
                    break;
                case ("customer"):
                    users.Add(new Customer
                    {
                        Credentials = "customer"
                    });
                    break;
            }
            return users;
        }

        public List<User> EditUser(List<User> users)
        {
            Console.WriteLine("Enter username to edit: ");
            string editUsername = Console.ReadLine();
            User user = users.Find(u => u.UserName == editUsername);
            users.Remove(user);
            Console.WriteLine("Edit User: " + user.UserName);
            Console.WriteLine("Slect function...");
            Console.WriteLine("Reset Password: reset");
            Console.WriteLine("Change User Name: name");
            Console.WriteLine("Change Access Credentials: access");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case ("reset"):
                    user.ResetPassword();
                    break;
                case ("name"):
                    Console.WriteLine("Enter new user name: ");
                    user.UserName = Console.ReadLine();
                    break;
                case ("access"):
                    Console.WriteLine("Enter new Access Level:");
                    user.Credentials = Console.ReadLine().ToLower();
                    break;
            }
            users.Add(user);
            return users;
        }

        public List<User> DeleteUser(List<User> users, string deleteUserName)
        {
            User deleteUser = users.Find(u => u.UserName == deleteUserName);
            users.Remove(deleteUser);
            Console.WriteLine("deleted");

            return users;
        }
    }
}
