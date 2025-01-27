﻿// FileName: TestSalesManagement.cs
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
    /// Sales management test.
    /// </summary>
    [TestFixture]
    public class SalesManagementTest
    {
        /// <summary>
        /// Tests the update order status.
        /// </summary>
        [Test]
        public void TestUpdateOrderStatus()
        {
            // View number of products available and update order
            // quantity can go negative
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
            Order order = new Order(customerUsername);
            order.AddProduct(new Product("5W-30", 23.54m, 3, ProductType.TRUCK), 2, products);
            orders.Add(order);

            // Delivery Find Orders with 
            SalesPerson s = new SalesPerson("User", "Pass");
            orders = s.UpdateOrderStatus(orders, order, OrderStatus.PROCESSING);
            Order updatedOrder = orders.Find(o => o.OrderName == customerUsername);

            Assert.AreEqual(OrderStatus.PROCESSING, updatedOrder.OrderStatus, "OrderStatus has been updated");
        }
    }
}
