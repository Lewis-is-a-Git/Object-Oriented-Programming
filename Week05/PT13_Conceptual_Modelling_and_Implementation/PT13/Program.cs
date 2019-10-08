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

            Admin RootAdmin = new Admin("Admin", "Admin")
            {
                Credentials = "admin"
            };
            users.Add(RootAdmin);
            MainMenu mainMenu = new MainMenu();

            products.Add(new Product("Bus Oil", 5.00m, 30, ProductType.BUS));
            products.Add(new Product("Bike Oil", 2.00m, 34, ProductType.MOTORCYCLE));

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
                    }
                    while (!mainMenu.Login(users, userName, password));
                    Console.Clear();
                }
                currentUser = mainMenu.UserName;
                Console.WriteLine("Enter a command to select a function: ");
                Console.WriteLine("User Management: user");
                Console.WriteLine("Stock Management: stock");
                Console.WriteLine("Sales Managemen: sales");
                Console.WriteLine("Delivery Management: delivery");
                Console.WriteLine("Order Placement: order");
                Console.WriteLine("Check Stock Availability: check");
                Console.WriteLine("Logout: logout");
                Console.WriteLine("Exit: exit");

                menuChoice = Console.ReadLine().ToLower();
                if (menuChoice == "exit") { Environment.Exit(0); }

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
                        orders = mainMenu.OrderPlacement(orders, products, currentUser);
                        products = mainMenu.Products;
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
                    default:
                        Console.WriteLine("Enter a command from the list...");
                        break;
                }
            }
        }
    }
}
