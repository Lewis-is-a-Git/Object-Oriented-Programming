// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;
using PT13.src;

namespace PT13
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Product> products = new List<Product>(); // Stock
            List<User> users = new List<User>();
            List<Order> orders = new List<Order>();

            // Create initial user to access the program
            Administrator RootAdmin = new Administrator("admin", "admin");
            users.Add(RootAdmin);
            MainMenu mainMenu = new MainMenu();

            // Add dummy data to the program for demonstration
            // Add some products to make orders from
            products.Add(new Product("Bus Oil", 5.00m, 30, ProductType.BUS));
            products.Add(new Product("Bike Oil", 2.00m, 30, ProductType.MOTORCYCLE));

            // add two orders to the order list
            Customer cus = new Customer("Customer", "pass");
            (orders, products) = cus.CreateOrder(orders, new List<string>() { "Bus Oil" },
                new List<int>() { 10 }, products, "Customer");
            (orders, products) = cus.CreateOrder(orders, new List<string>() { "Bike Oil" },
                new List<int>() { 10 }, products, "Customer");
            Console.Clear(); // Clear Screen to hide adding dummy data

            // start the program logged out with no username
            string currentUser = "";
            string menuChoice = "logout";
            while (true)
            {
                if (menuChoice == "logout")
                {
                    Console.WriteLine("Welcome to Total Oil Malaysia Sdn Bhd online management system.");
                    string userName, password;
                    do
                    {
                        Console.WriteLine("Please Login..");
                        Console.WriteLine("Username: ");
                        userName = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        password = Console.ReadLine();
                        Console.Clear();
                    }
                    while (!mainMenu.Login(users, userName, password));
                }
                // set current username
                currentUser = mainMenu.UserName;
                // Display Main Menu
                Console.WriteLine("Welcome " + currentUser);
                Console.WriteLine("----------------------MAIN MENU-----------------------");
                Console.WriteLine("| Enter a command to select a function...            |");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("| User Management:     user                          |");
                Console.WriteLine("| Stock Management:    stock                         |");
                Console.WriteLine("| Stock Availability:  check                         |");
                Console.WriteLine("| Order Management:    order                         |");
                Console.WriteLine("| Sales Management:    sales                         |");
                Console.WriteLine("| Delivery Management: delivery                      |");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Logout: logout");
                Console.WriteLine("Exit:   exit");
                Console.Write("Command: ");
                menuChoice = Console.ReadLine().ToLower();
                Console.Clear();

                switch (menuChoice)
                {
                    case ("user"):
                        users = mainMenu.UserManagement(users);
                        break;
                    case ("stock"):
                        products = mainMenu.StockManagement(products);
                        break;

                    case ("check"):
                        mainMenu.StockAvailability(products);
                        break;
                    case ("order"):
                        (orders, products) = mainMenu.OrderManagement(orders, products, currentUser);
                        break;
                    case ("sales"):
                        orders = mainMenu.SalesManagement(users, orders, products);
                        break;
                    case ("delivery"):

                        orders = mainMenu.DeliveryManagement(orders);
                        break;
                    case ("logout"):
                        Console.Clear();
                        Console.WriteLine("Logging out...");
                        break;
                    case ("exit"):
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter a command from the list...");
                        break;
                }
            }
        }
    }
}
