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

            Admin RootAdmin = new Admin("Admin", "Admin");
            users.Add(RootAdmin);
            MainMenu mainMenu = new MainMenu();

            products.Add(new Product("Bus Oil", 5.00m, 30, ProductType.BUS));
            products.Add(new Product("Bike Oil", 2.00m, 34, ProductType.MOTORCYCLE));

            string currentUser, userName = "";

            string menuChoice = "logout";
            while (true)
            {
                if (menuChoice == "logout")
                {
                    Console.WriteLine("Welcome to Total Oil Malaysia Sdn Bhd online management system.");
                    do
                    {
                        Console.WriteLine("Please enter Username: ");
                        userName = Console.ReadLine();
                        Console.WriteLine("Please Enter Password: ");
                    } while (mainMenu.Login(users, userName, Console.ReadLine()));
                    Console.Clear();
                }
                currentUser = userName;
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
                        switch (mainMenu.UserManagement())
                        {
                            case ("create"):  // Create
                                switch (Console.ReadLine().ToLower())
                                {
                                    case ("admin"):
                                        users.Add(new Admin());
                                        break;
                                    case ("sales"):
                                        users.Add(new Sales());
                                        break;
                                    case ("delivery"):
                                        users.Add(new Delivery());
                                        break;
                                    case ("customer"):
                                        users.Add(new Customer());
                                        break;
                                }
                                break;
                            case ("edit"):  // Edit
                                string EdituserName = Console.ReadLine();
                                User user = users.Find(u => u.UserName == EdituserName);
                                users.Remove(user);
                                Console.WriteLine("Edit User: " + user.UserName);
                                Console.WriteLine("Slect function...");
                                Console.WriteLine("Reset Password: reset");
                                Console.WriteLine("Change User Name: name");
                                Console.WriteLine("Change Access Credentials: access");
                                switch (Console.ReadLine().ToLower())
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
                                break;
                            case ("delete"):  // Delete
                                string deleteUserName = Console.ReadLine();
                                User deleteUser = users.Find(u => u.UserName == deleteUserName);
                                users.Remove(deleteUser);
                                Console.WriteLine("deleted");
                                break;
                        }
                        Console.WriteLine("You must log out to update user accounts.");
                        break;
                    case ("stock"):
                        switch (mainMenu.StockManagement())
                        {
                            case ("add"):
                                Console.WriteLine("Enter the Product Name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter the Product Price: ");
                                decimal price = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the Product Quantity: ");
                                int quantity = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the Product Type: ");
                                string type = Console.ReadLine().ToLower();
                                ProductType actualType = ProductType.BUS;
                                switch (type)
                                {
                                    case ("car"):
                                        actualType = ProductType.CAR;
                                        break;
                                    case ("motorcycle"):
                                        actualType = ProductType.MOTORCYCLE;
                                        break;
                                    case ("truck"):
                                        actualType = ProductType.TRUCK;
                                        break;
                                }
                                products.Add(new Product(name, price, quantity, actualType));
                                break;
                            case ("edit"):
                                string EditproductName = Console.ReadLine();
                                Product Editproduct = products.Find(p => p.Name == EditproductName);
                                products.Remove(Editproduct);
                                Console.WriteLine("Enter the Product Name: ");
                                string Editname = Console.ReadLine();
                                Console.WriteLine("Enter the Product Price: ");
                                decimal Editprice = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the Product Quantity: ");
                                int Editquantity = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the Product Type: ");
                                string Edittype = Console.ReadLine().ToLower();
                                ProductType EditactualType = ProductType.BUS;
                                switch (Edittype)
                                {
                                    case ("car"):
                                        EditactualType = ProductType.CAR;
                                        break;
                                    case ("motorcycle"):
                                        EditactualType = ProductType.MOTORCYCLE;
                                        break;
                                    case ("truck"):
                                        EditactualType = ProductType.TRUCK;
                                        break;
                                }
                                products.Add(new Product(Editname, Editprice, Editquantity, EditactualType));

                                break;
                            case ("delete"):
                                string DeleteProductName = Console.ReadLine();
                                Product DeleteProduct = products.Find(p => p.Name == DeleteProductName);
                                products.Remove(DeleteProduct);
                                break;
                        }
                        break;

                    case ("check"):
                        string productName = mainMenu.StockAvailability();
                        Product product = products.Find(p => p.Name == productName);
                        Console.WriteLine("There are " + product.Quantity + " " + product.Name + "(s) available");
                        break;
                    case ("order"):
                        if (mainMenu.OrderPlacement().ToLower() == "create")
                        {
                            Order order = new Order(userName, products);
                            string more = "yes";
                            while (more == "yes")
                            {
                                Console.WriteLine("Enter product Name: ");
                                string addProductName = Console.ReadLine();
                                Console.WriteLine("Enter quantity: ");
                                int addProductQuantity = int.Parse(Console.ReadLine());
                                Product addProduct = products.Find(p => p.Name == addProductName);
                                int remaining = addProduct.Quantity - addProductQuantity;
                                order.AddProduct(addProduct, addProductQuantity);
                                products.Remove(addProduct);
                                addProduct.Quantity = remaining;
                                products.Add(addProduct);

                                Console.WriteLine("Would you like to add another product? yes/no");
                                more = Console.ReadLine().ToLower();
                            }
                            orders.Add(order);
                        }
                        else if (mainMenu.OrderPlacement().ToLower() == "check")
                        {
                            // show a list fo orders with the sam eiusername and show status
                            List<Order> userOrders = orders.FindAll(o => o.OrderName == userName);
                            Console.WriteLine("List of orders for User: " + userName);
                            if (userOrders.Count > 0)
                            {
                                foreach (Order o in userOrders)
                                {
                                    Console.WriteLine("Order ID: " + o.OrderID + " Order Status: " + o.OrderStatus.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("No orders foudn for this user.");
                            }

                        }

                        break;
                    case ("sales"):
                        orders = mainMenu.SalesManagement(users, orders, products);
                        break;
                    case ("delivery"):
                        Console.WriteLine("Enter Order ID: ");
                        string orderID = Console.ReadLine();
                        orders = mainMenu.DeliveryManagement(orders, orderID);
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
