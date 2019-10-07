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
        private String _credentials;
        //private String _userName;
        private List<User> _users;

        public MainMenu()
        {
        }

        public bool Login(List<User> users)
        {

            string userName, password;
            Console.WriteLine("Please Login..");
            Console.WriteLine("Username: ");
            userName = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();

            _users = users;
            User user = users.Find(u => u.UserName == userName);
            if (user == null) { return false; }
            _credentials = user.Credentials;
            bool success = false;
            if (user.Password == password)
            {
                success = true;
            }
            return success;
        }

        public bool Login(List<User> users, string userName, string password)
        {
            _users = users;
            User user = users.Find(u => u.UserName == userName);
            if (user == null) { return false; }
            _credentials = user.Credentials;
            bool success = false;
            if (user.Password == password)
            {
                success = true;
            }
            return success;
        }

        public string UserManagement()
        {
            string choice = "";
            if (_credentials == "admin")
            {
                Console.WriteLine("Choose a Task...");
                Console.WriteLine("To create a new user press: create");
                Console.WriteLine("To Edit a user press: edit");
                Console.WriteLine("To Delete a user press: delete");
                choice = Console.ReadLine().ToLower();
            }
            else
            {
                Console.WriteLine("Cannot access User Management");
                choice = "";
            }

            if (choice == "create")
            {
                Console.WriteLine("Choose what kind of user to create...");
                Console.WriteLine("To create a new admin press: admin");
                Console.WriteLine("To create a new sales press: sales");
                Console.WriteLine("To create a new delivery press: delivery");
                Console.WriteLine("To create a new customer press: customer");
            }
            if (choice == "edit" || choice == "delete")
            {
                Console.WriteLine("Enter username: ");
            }

            return choice;
        }



        public string StockManagement()
        {
            string choice = "";
            if (_credentials == "sales")
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
                choice = "";
            }
            if (choice == "add")
            {
                Console.WriteLine("Creating a new product...");
            }
            if (choice == "edit" || choice == "delete")
            {
                Console.WriteLine("Enter product name: ");
            }
            return choice;

        }
        public string StockAvailability()
        {
            Console.WriteLine("Enter product name to check availablity: ");
            return Console.ReadLine();

        }

        public string OrderPlacement()
        {
            string choice = "";
            if (_credentials == "customer")
            {
                Console.WriteLine("To create a new order enter: create");
                Console.WriteLine("To check an order status enter: status");
                choice = Console.ReadLine();
            }

            return choice;
        }
        public List<Order> SalesManagement(List<User> users, List<Order> orders, List<Product> products)
        {
            if (_credentials == "Sales")
            {
                Console.WriteLine("Pleas select function...");
                Console.WriteLine("To view a list of orders: orders");
                Console.WriteLine("To update order status: status");
                Console.WriteLine("To print sales details: sales");
                switch (Console.ReadLine().ToLower())
                {
                    case ("orders"):
                        foreach (Order o in orders)
                        {
                            Console.WriteLine("Order ID: " + o.OrderID + " Oder name: " + o.OrderName + " Order Status: " + o.OrderStatus.ToString());
                        }
                        break;
                    case ("status"):
                        foreach (Order o in orders)
                        {
                            Console.WriteLine("Order ID: " + o.OrderID + " Oder name: " + o.OrderName + " Order Status: " + o.OrderStatus.ToString());
                            foreach (Product p in o.OrderList)
                            {
                                Product checkQuantity = products.Find(c => c.Name == p.Name);

                                if (p.Quantity <= checkQuantity.Quantity)
                                {
                                    Console.WriteLine(p.Name + " is in stock");
                                }
                                else
                                {
                                    Console.WriteLine(p.Name + " is unavailable");
                                }
                            }
                            Console.WriteLine("To update order status, enter order ID: ");
                            string orderID = Console.ReadLine();
                            Order updateSatusOrder = orders.Find(u => u.OrderID == orderID);
                            Console.WriteLine("Enter New status for order " + orderID + ": ");
                            Console.WriteLine("Options: NEW, PROCESSING, SHIPPING, DELIVERED, CANCELED");
                            string status = Console.ReadLine().ToUpper();
                            OrderStatus actual = OrderStatus.NEW;
                            switch (status)
                            {
                                case ("NEW"):
                                    actual = OrderStatus.NEW;
                                    break;
                                case ("PROCESSING"):
                                    actual = OrderStatus.PROCESSING;
                                    break;
                                case ("SHIPPING"):
                                    actual = OrderStatus.SHIPPING;
                                    break;
                                case ("DELIVERED"):
                                    actual = OrderStatus.DELIVERED;
                                    break;
                                case ("CANCELED"):
                                    actual = OrderStatus.CANCELED;
                                    break;
                                default:
                                    Console.WriteLine("entry invalid order is set to new.");
                                    break;
                            }

                            orders.Remove(updateSatusOrder);
                            updateSatusOrder.OrderStatus = actual;
                            orders.Add(updateSatusOrder);
                        }
                        break;
                    case ("sales"):
                        Console.WriteLine("Enter the Product Type: ");
                        Console.WriteLine("Options: bus, car, motorcycle, truck");
                        string productType = Console.ReadLine().ToLower();
                        ProductType actualType = ProductType.BUS;
                        switch (productType)
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
                            default:
                                Console.WriteLine("Invalid product type. Using BUS.");
                                break;
                        }
                        List<Product> productsOfType = products.FindAll(t => t.ProductType == actualType);
                        foreach (Product p in productsOfType)
                        {
                            Console.WriteLine("Product Name: " + p.Name + " Product Quantity: " + p.Quantity);
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid access permission.");
            }

            return orders;
        }

        public List<Order> DeliveryManagement(List<Order> orders, string orderID)
        {

            if (_credentials == "Delivery")
            {
                Order updateSatusOrder = orders.Find(o => o.OrderID == orderID);
                Console.WriteLine("Enter New status for order " + orderID + ": ");
                Console.WriteLine("Options: NEW, PROCESSING, SHIPPING, DELIVERED, CANCELED");
                string status = Console.ReadLine().ToUpper();
                OrderStatus actual = OrderStatus.NEW;
                switch (status)
                {
                    case ("NEW"):
                        actual = OrderStatus.NEW;
                        break;
                    case ("PROCESSING"):
                        actual = OrderStatus.PROCESSING;
                        break;
                    case ("SHIPPING"):
                        actual = OrderStatus.SHIPPING;
                        break;
                    case ("DELIVERED"):
                        actual = OrderStatus.DELIVERED;
                        break;
                    case ("CANCELED"):
                        actual = OrderStatus.CANCELED;
                        break;
                    default:
                        Console.WriteLine("entry invalid order is set to new.");
                        break;
                }

                orders.Remove(updateSatusOrder);
                updateSatusOrder.OrderStatus = actual;
                orders.Add(updateSatusOrder);
            }
            else
            {
                Console.WriteLine("invalid access permission.");
            }
            return orders;
        }

    }
}
