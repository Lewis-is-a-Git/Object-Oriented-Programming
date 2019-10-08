﻿// FileName: TestOrder.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 8/10/2019
using System;
using System.Collections.Generic;
using NUnit.Framework;
using PT13.src;
namespace PT13.Testing
{
    [TestFixture]
    public class TestOrder
    {
        [Test]
        public void TestCreateNewOrder()
        {
            // Create Customer
            string customerUsername = "User";
            Customer customer = new Customer(customerUsername, "pass");

            // Create Products in stock
            Product oil = new Product("5W-30", 23.54m, 3, ProductType.TRUCK);
            List<Product> products = new List<Product>
            {
                // Products: string name, decimal price, int quantity, ProductType type
                new Product("10W-40", 3.50m, 34, ProductType.CAR),
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
                "10W-40"
            };
            List<int> productQuantity = new List<int>
            {
                30
            };
            orders = customer.CreateOrder(orders, productNames, productQuantity, products, customer.UserName);

            Assert.IsNotEmpty(orders, "Order Created");
        }

        [Test]
        public void TestCheckOrder()
        {
            // Create Products
            Product oil = new Product("5W-30", 23.54m, 3, ProductType.TRUCK);
            List<Product> products = new List<Product>
            {
                // Products: string name, decimal price, int quantity, ProductType type
                new Product("10W-40", 3.50m, 34, ProductType.CAR),
                new Product("15W-5", 40.2m, 2, ProductType.MOTORCYCLE),
                oil
            };

            string customerUsername = "User";

            // Create Order
            List<Order> orders = new List<Order>();
            Order order = new Order(customerUsername, products);
            order.AddProduct(new Product("5W-30", 23.54m, 3, ProductType.TRUCK), 2);
            orders.Add(order);
            Assert.IsNotEmpty(orders, "Order Created");

            Customer customer = new Customer("Customer", "Pass");
            bool success = customer.CheckOrder(orders, customer.UserName);

            Assert.AreEqual(true, success, "Order Checked"); // Not implemented yet
        }
    }
}