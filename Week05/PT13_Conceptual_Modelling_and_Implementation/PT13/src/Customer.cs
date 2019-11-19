// FileName: Customer.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    /// <summary>
    /// Customer.
    /// </summary>
    public class Customer : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PT13.src.Customer"/> class.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public Customer(string username, string password) : base(username, password) { }

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <returns>Updated orders and products</returns>
        /// <param name="orders">Orders.</param>
        /// <param name="products">Products.</param>
        /// <param name="currentUser">Current user.</param>
        public (List<Order>, List<Product>) CreateOrder(List<Order> orders, List<Product> products, string currentUser)
        {
            // Create a list by adding the names and the quantity of the desired products
            List<String> productNames = new List<String>();
            List<int> productQuantity = new List<int>();
            string more = "yes"; // change this value to stop adding more products to this order
            while (more == "yes")
            {
                Console.WriteLine("Enter product Name: ");
                productNames.Add(Console.ReadLine());
                Console.WriteLine("Enter quantity: ");
                productQuantity.Add(int.Parse(Console.ReadLine()));

                Console.WriteLine("Would you like to add another product? yes/no");
                more = Console.ReadLine().ToLower();
            }
            (orders, products) = CreateOrder(orders, productNames, productQuantity, products, currentUser);

            return (orders, products);
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
        public (List<Order>, List<Product>) CreateOrder(List<Order> orders, List<string> productNames, List<int> productQuantity, List<Product> products, string currentUser)
        {
            // Create new empty order
            Order order = new Order(currentUser);
            // check all the product names entered to see if the product exists in stock
            for (int c = 0; c < productNames.Count; c++)
            {
                Product addProduct = products.Find(p => p.Name == productNames[c]);
                // if the product exists
                if (addProduct != null)
                {
                    // take the quanitity ordered out of the list of avaible stock
                    int remaining = addProduct.Quantity - productQuantity[c];
                    // add the product to the order
                    order.AddProduct(addProduct, productQuantity[c], products);

                    // Update the list of available products with the new quantity
                    // Product quanitity is removed form stock when an order is placed
                    products.Remove(addProduct);
                    // Add updated product back to stock
                    Product clonedProduct = new Product(addProduct.Name, addProduct.Price, remaining, addProduct.ProductType);
                    products.Add(clonedProduct);

                    // Verify if product was added to order
                    Product verifyOrderedProduct = order.OrderList.Find(p => p.Name == addProduct.Name);
                    if (verifyOrderedProduct != null)
                    {
                        Console.WriteLine(verifyOrderedProduct.Quantity + " " +
                            verifyOrderedProduct.Name + " added to order.");
                    }
                    else
                    {
                        Console.WriteLine("Product not added to order.");
                    }

                }
                else
                {
                    Console.WriteLine("No products found with name " + productNames[c]);
                }
            }
            if (order != null)
            {
                orders.Add(order);
                Console.WriteLine("Thank you for your order.");
                Console.WriteLine("Please pay: $" + order.TotalPrice);
            }
            else
            {
                Console.WriteLine("No order created.");
            }

            return (orders, products);
        }

        /// <summary>
        /// Checks the order status.
        /// </summary>
        /// <returns><c>true</c>, if order was checked, <c>false</c> otherwise.</returns>
        /// <param name="orders">Orders.</param>
        /// <param name="currentUser">Current user.</param>
        public bool CheckOrderStatus(List<Order> orders, string currentUser)
        {
            // show a list of orders with the same username and show status
            List<Order> userOrders = orders.FindAll(o => o.OrderName == currentUser);
            if (userOrders.Capacity != 0)
            {
                if (userOrders == null)
                {
                    Console.WriteLine("No Orders found.");
                    return false;
                }
                Console.WriteLine("List of orders for User: " + currentUser);
                if (userOrders.Count > 0)
                {
                    foreach (Order o in userOrders)
                    {
                        o.DisplayOrderDetails();
                    }
                }
                else
                {
                    Console.WriteLine("No orders found for this user.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No orders for user " + currentUser + " found.");
            }
            return true;
        }
    }
}
