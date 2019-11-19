// FileName: MainMenu.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    /// <summary>
    /// Main menu.
    /// </summary>
    public class MainMenu
    {
        // Display user name in menu and customer orders
        // Check access permission
        private User _currentUser;

        // Getters
        public string UserName { get { return _currentUser.UserName; } }
        public User CurrentUser { get { return _currentUser; } }

        // Used to check user access permission
        public bool IsAdmin() { return _currentUser is Administrator; }
        public bool IsCustomer() { return _currentUser is Customer; }
        public bool IsDelivery() { return _currentUser is DeliveryPerson; }
        public bool IsSales() { return _currentUser is SalesPerson; }

        /// <summary>
        /// Login with the specified userName and password
        /// </summary>
        /// <returns>Correct Login</returns>
        /// <param name="users">Users.</param>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public bool Login(List<User> users, string userName, string password)
        {
            User user = users.Find(u => u.UserName == userName);
            Console.Clear();

            if (user == null)
            {
                Console.WriteLine("Cannot find user.");
                return false;
            }

            bool success = false;
            if (user.Password == password)
            {
                success = true;
                _currentUser = user;
            }
            else
            {
                Console.WriteLine("Incorrect Password.");
            }
            return success;
        }

        /// <summary>
        /// User management for Administrator.
        /// </summary>
        /// <returns>Updated list of users</returns>
        /// <param name="users">Users.</param>
        public List<User> UserManagement(List<User> users)
        {
            string choice = "";
            if (IsAdmin())
            {
                Console.WriteLine("Choose a Task...");
                Console.WriteLine("To create a new user press: create");
                Console.WriteLine("To Edit a user press: edit");
                Console.WriteLine("To Delete a user press: delete");
                choice = Console.ReadLine().ToLower();
            }
            switch (choice)
            {
                case ("create"):
                    users = (_currentUser as Administrator).CreateUser(users);
                    break;
                case ("edit"):
                    users = (_currentUser as Administrator).EditUser(users);
                    break;
                case ("delete"):
                    Console.WriteLine("Enter username to delete: ");
                    string deleteUserName = Console.ReadLine();
                    users = (_currentUser as Administrator).DeleteUser(users, deleteUserName);
                    break;
                default:
                    Console.WriteLine("Cannot access User Management");
                    Console.WriteLine("Invalid access permission.");
                    break;
            }
            return users;
        }

        /// <summary>
        /// Stocks the management for Sales User.
        /// </summary>
        /// <returns>The management.</returns>
        /// <param name="products">Products.</param>
        public List<Product> StockManagement(List<Product> products)
        {
            string choice = "";
            if (IsSales())
            {
                Console.WriteLine("Choose a Task...");
                Console.WriteLine("To add a new product press: add");
                Console.WriteLine("To Edit a product press: edit");
                Console.WriteLine("To Delete a product press: delete");
                choice = Console.ReadLine().ToLower();
            }
            else
            {
                Console.WriteLine("Cannot access Stock Management");
                Console.WriteLine("Invalid access permission.");
            }
            switch (choice)
            {
                case ("add"):
                    products = (_currentUser as SalesPerson).AddProduct(products);
                    break;
                case ("edit"):
                    products = (_currentUser as SalesPerson).EditProduct(products);
                    break;
                case ("delete"):
                    products = (_currentUser as SalesPerson).DeleteProduct(products);
                    break;
            }
            return products;
        }

        /// <summary>
        /// Check Stock availability.
        /// Any user can check.
        /// </summary>
        /// <param name="products">Products.</param>
        public void StockAvailability(List<Product> products)
        {
            Console.WriteLine("Enter product name to check availablity: ");
            string searchProductName = Console.ReadLine();
            Product product = products.Find(p => p.Name == searchProductName);
            if (product != null)
            {
                Console.WriteLine("There are " + product.Quantity + " " + product.Name + "(s) available");
            }
            else
            {
                Console.WriteLine("Cannot find product.");
            }
        }

        /// <summary>
        /// Customer Order management.
        /// </summary>
        /// <returns>Updated orders and products</returns>
        /// <param name="orders">Orders.</param>
        /// <param name="products">Products.</param>
        /// <param name="currentUser">Current user.</param>
        public (List<Order>, List<Product>) OrderManagement(List<Order> orders, List<Product> products, string currentUser)
        {
            string choice = "";
            if (IsCustomer())
            {
                Console.WriteLine("To create a new order enter: create");
                Console.WriteLine("To check an order status enter: status");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case ("create"):
                        (orders, products) = (_currentUser as Customer).CreateOrder(orders, products, currentUser);
                        break;
                    case ("status"):
                        (_currentUser as Customer).CheckOrderStatus(orders, currentUser);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Cannot access Order Management");
                Console.WriteLine("Customer access Required.");
            }

            return (orders, products);
        }

        /// <summary>
        /// Manage Orders for sales and prints sales details.
        /// </summary>
        /// <returns>Updated list of orders</returns>
        /// <param name="users">Users.</param>
        /// <param name="orders">Orders.</param>
        /// <param name="products">Products.</param>
        public List<Order> SalesManagement(List<User> users, List<Order> orders, List<Product> products)
        {
            if (IsSales())
            {
                Console.WriteLine("Pleas select function...");
                Console.WriteLine("To view a list of orders: orders");
                Console.WriteLine("To update order status: status");
                Console.WriteLine("To print sales details: sales");
                switch (Console.ReadLine().ToLower())
                {
                    case ("orders"):
                        (_currentUser as SalesPerson).DisplayOrders(orders, products);
                        break;
                    case ("status"):
                        orders = (_currentUser as SalesPerson).UpdateOrderStatus(orders);
                        break;
                    case ("sales"):
                        (_currentUser as SalesPerson).PrintSalesDetails(products);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Cannot access Sales Management");
                Console.WriteLine("Sales access Required.");
            }

            return orders;
        }

        /// <summary>
        /// Deliveries management for delivery person.
        /// </summary>
        /// <returns>Updated list of orders.</returns>
        /// <param name="orders">Orders.</param>
        public List<Order> DeliveryManagement(List<Order> orders)
        {
            if (IsDelivery())
            {
                orders = (_currentUser as DeliveryPerson).UpdateOrderStatus(orders);
            }
            else
            {
                Console.WriteLine("Cannot access Delivery Management");
                Console.WriteLine("Delivery access Required.");
            }
            return orders;
        }
    }
}
