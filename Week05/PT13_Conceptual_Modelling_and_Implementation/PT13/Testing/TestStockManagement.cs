// FileName: TestStockManagement.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 8/10/2019
using System;
using System.Collections.Generic;
using NUnit.Framework;
using PT13.src;
namespace PT13.Testing
{
    /// <summary>
    /// Test stock management.
    /// </summary>
    [TestFixture]
    public class TestStockManagement
    {
        /// <summary>
        /// Tests the add new product.
        /// </summary>
        [Test]
        public void TestAddNewProduct()
        {
            // Create Customer
            string customerUsername = "User";
            Customer customer = new Customer(customerUsername, "pass");

            // Create Products in stock
            Product oil = new Product("5W-30", 23.54m, 3, ProductType.TRUCK);
            string orderedProductName = "10W-40";
            int orderedProductQuantity = 34;
            int numberOrdered = 30;
            List<Product> products = new List<Product>
            {
                // Products: string name, decimal price, int quantity, ProductType type
                new Product(orderedProductName, 3.50m, orderedProductQuantity, ProductType.CAR),
                new Product("15W-5", 40.2m, 2, ProductType.MOTORCYCLE),
                oil
            };

            // Create Order
            List<Order> orders = new List<Order>();
            Order order = new Order(customerUsername, products);
            order.AddProduct(oil, 2);

            // Add Order to the orders list
            List<string> productNames = new List<string>
            {
                orderedProductName
            };
            List<int> productQuantity = new List<int>
            {
                numberOrdered
            };
            orders = customer.CreateOrder(orders, productNames, productQuantity, products, customer.UserName);
            Assert.IsNotEmpty(orders, "Order Created");

            Product orderedProduct = products.Find(p => p.Name == orderedProductName);

            Assert.AreEqual(orderedProductQuantity - numberOrdered, orderedProduct.Quantity, "Adding Items to an order takes it from stock.");


        }


    }
}
