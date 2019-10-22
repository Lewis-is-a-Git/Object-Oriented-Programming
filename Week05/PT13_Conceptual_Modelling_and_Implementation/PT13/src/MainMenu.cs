// FileName: MainMenu.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    public class MainMenu
    {
        private User _currentUser;
        private String _credentials;
        private List<User> _users;
        private List<Product> _products;

        public string UserName { get => _currentUser.UserName; }
        public List<Product> Products { get => _products; }
        public User CurrentUser { get => _currentUser; }

        public bool Login(List<User> users, string userName, string password)
        {
            _users = users;
            User user = users.Find(u => u.UserName == userName);
            Console.Clear();
            if (user == null) { return false; }

            bool success = false;
            if (user.Password == password)
            {
                success = true;
                _currentUser = user;
                _credentials = user.Credentials;
            }
            return success;
        }

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
                    users = (_currentUser as Admin).CreateUser(users);
                    break;
                case ("edit"):
                    users = (_currentUser as Admin).EditUser(users);
                    break;
                case ("delete"):
                    Console.WriteLine("Enter username to delete: ");
                    string deleteUserName = Console.ReadLine();
                    users = (_currentUser as Admin).DeleteUser(users, deleteUserName);
                    break;
                default:
                    Console.WriteLine("Cannot access User Management");
                    break;
            }
            return users;
        }

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
                Console.WriteLine("Cannot access User Management");
            }
            switch (choice)
            {
                case ("add"):
                    products = (_currentUser as Sales).AddProduct(products);
                    break;
                case ("edit"):
                    products = (_currentUser as Sales).EditProduct(products);
                    break;
                case ("delete"):
                    products = (_currentUser as Sales).DeleteProduct(products);
                    break;
            }
            return products;
        }
        public void StockAvailability(List<Product> products)
        {
            Console.WriteLine("Enter product name to check availablity: ");
            Product product = products.Find(p => p.Name == Console.ReadLine());
            Console.WriteLine("There are " + product.Quantity + " " + product.Name + "(s) available");
        }

        public List<Order> OrderPlacement(List<Order> orders, List<Product> products, string currentUser)
        {
            string choice = "";
            if (IsCustomer())
            {
                Console.WriteLine("To create a new order enter: create");
                Console.WriteLine("To check an order status enter: status");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case ("create"):
                    orders = (_currentUser as Customer).CreateOrder(orders, products, currentUser);
                    products = (_currentUser as Customer).Products;
                    break;
                case ("check"):
                    (_currentUser as Customer).CheckOrder(orders, currentUser);
                    break;
            }
            _products = products;
            return orders;
        }
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
                        (_currentUser as Sales).DisplayOrders(orders, products);
                        break;
                    case ("status"):
                        orders = (_currentUser as Sales).UpdateOrderStatus(orders);
                        break;
                    case ("sales"):
                        (_currentUser as Sales).PrintSalesDetails(products);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid access permission.");
            }

            return orders;
        }

        public List<Order> DeliveryManagement(List<Order> orders)
        {

            if (IsDelivery())
            {
                orders = (_currentUser as Delivery).UpdateOrderStatus(orders);
            }
            else
            {
                Console.WriteLine("invalid access permission.");
            }
            return orders;
        }

        public bool IsAdmin() { return _currentUser is Admin; }
        public bool IsCustomer() { return _currentUser is Customer; }
        public bool IsDelivery() { return _currentUser is Delivery; }
        public bool IsSales() { return _currentUser is Sales; }
    }
}
