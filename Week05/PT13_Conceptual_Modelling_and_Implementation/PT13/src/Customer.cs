// FileName: Customer.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    public class Customer : User
    {
        private List<Product> _products;

        public Customer() { }
        public Customer(string username, string password) : base(username, password) { }

        public List<Product> Products
        {
            get { return _products; }
        }

        public List<Order> CreateOrder(List<Order> orders, List<Product> products, string currentUser)
        {

            List<String> productNames = new List<String>();
            List<int> productQuantity = new List<int>();
            string more = "yes";
            int productCounter = 0;
            while (more == "yes")
            {
                Console.WriteLine("Enter product Name: ");
                productNames.Add(Console.ReadLine());
                Console.WriteLine("Enter quantity: ");
                productQuantity.Add(int.Parse(Console.ReadLine()));

                Console.WriteLine("Would you like to add another product? yes/no");
                more = Console.ReadLine().ToLower();
                productCounter++;
            }
            orders = CreateOrder(orders, productNames, productQuantity, products, currentUser);

            return orders;
        }

        /// <summary>
        /// Second Create Order to bypass Console.ReadLine() Used for testing
        /// </summary>
        /// <returns>The order.</returns>
        /// <param name="orders">Orders.</param>
        /// <param name="productNames">Product names.</param>
        /// <param name="productQuantity">Product quantity.</param>
        /// <param name="products">Products.</param>
        /// <param name="currentUser">Current user.</param>
        public List<Order> CreateOrder(List<Order> orders, List<string> productNames, List<int> productQuantity, List<Product> products, string currentUser)
        {
            Order order = new Order(currentUser, products);
            for (int c = 0; c < productNames.Count; c++)
            {
                Product addProduct = products.Find(p => p.Name == productNames[c]);
                int remaining = addProduct.Quantity - productQuantity[c];
                order.AddProduct(addProduct, productQuantity[c]);
                products.Remove(addProduct);
                addProduct.Quantity = remaining;
                products.Add(addProduct);
            }

            orders.Add(order);
            _products = products;
            return orders;
        }

        public bool CheckOrder(List<Order> orders, string currentUser)
        {
            // show a list fo orders with the sam eiusername and show status
            List<Order> userOrders = orders.FindAll(o => o.OrderName == currentUser);
            if (userOrders == null) { return false; }
            Console.WriteLine("List of orders for User: " + currentUser);
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
            return true;
        }
    }
}
