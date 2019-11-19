// FileName: Admin.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;
namespace PT13.src
{
    /// <summary>
    /// Administrator.
    /// </summary>
    public class Administrator : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PT13.src.Administrator"/> class.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public Administrator(string username, string password) : base(username, password) { }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="users">Users.</param>
        public List<User> CreateUser(List<User> users)
        {
            Console.WriteLine("Choose what kind of user to create...");
            Console.WriteLine("To create a new admin press: admin");
            Console.WriteLine("To create a new sales press: sales");
            Console.WriteLine("To create a new delivery press: delivery");
            Console.WriteLine("To create a new customer press: customer");
            string choice = "";
            choice = Console.ReadLine().ToLower();
            // if the user chose a command
            if (choice == "admin" || choice == "sales" ||
                choice == "delivery" || choice == "customer")
            {
                Console.WriteLine("Enter new User: username: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter new User: password: ");
                string pass = Console.ReadLine();
                // check for existing user with same name
                User existingUser = users.Find(u => u.UserName == name);
                if (existingUser != null)
                {
                    Console.WriteLine("User with that username already exists.");
                }
                else
                {
                    // Call second Create user to actuall create a new user
                    users = CreateUser(users, choice, name, pass);
                    Console.WriteLine("New user created.");
                }
            }
            else
            {
                Console.WriteLine("Command not recognised");
            }
            return users;
        }

        /// <summary>
        /// Second Create User class to bypass the Console.ReadLine(), used for testing
        /// </summary>
        /// <returns>Updated List of users</returns>
        /// <param name="users">Users.</param>
        /// <param name="choice">Choice.</param>
        public List<User> CreateUser(List<User> users, string choice, string name, string pass)
        {
            // Choose which type of user to create
            switch (choice)
            {
                case ("admin"):
                    users.Add(new Administrator(name, pass));
                    break;
                case ("sales"):
                    users.Add(new SalesPerson(name, pass));
                    break;
                case ("delivery"):
                    users.Add(new DeliveryPerson(name, pass));
                    break;
                case ("customer"):
                    users.Add(new Customer(name, pass));
                    break;
            }
            return users;
        }

        /// <summary>
        /// Edits a user.
        /// </summary>
        /// <returns>Updated list of users</returns>
        /// <param name="users">Users.</param>
        public List<User> EditUser(List<User> users)
        {
            Console.WriteLine("Enter username to edit: ");
            string editUsername = Console.ReadLine();

            // check if users exists
            User user = users.Find(u => u.UserName == editUsername);
            if (user != null)
            {
                users.Remove(user); // remove the old user
                Console.WriteLine("Edit User: " + user.UserName);
                Console.WriteLine("Select function...");
                Console.WriteLine("Reset Password: reset");
                Console.WriteLine("Change User Name: name");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case ("reset"):
                        Console.WriteLine("Enter new password: ");
                        user.ResetPassword(user.Password, Console.ReadLine());
                        break;
                    case ("name"):
                        Console.WriteLine("Enter new user name: ");
                        user.EditUser(user.Password, Console.ReadLine());
                        break;
                }
                users.Add(user); // add the updated user back to the list of users
            }
            else
            {
                Console.WriteLine("Cannot find user with username: " + editUsername);
            }
            return users;
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <returns>Updated List of users</returns>
        /// <param name="users">Users.</param>
        /// <param name="deleteUserName">Delete user name.</param>
        public List<User> DeleteUser(List<User> users, string deleteUserName)
        {
            User deleteUser = users.Find(u => u.UserName == deleteUserName);
            if (deleteUser != null)
            {
                users.Remove(deleteUser);
                Console.WriteLine("User " + deleteUser.UserName + " deleted.");
            }
            else
            {
                Console.WriteLine("Cannot Find user: " + deleteUserName);
            }

            return users;
        }
    }
}
