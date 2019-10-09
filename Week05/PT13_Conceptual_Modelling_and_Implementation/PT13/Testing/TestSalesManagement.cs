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
    [TestFixture]
    public class TestSalesManagement
    {
        [Test]
        public void UpdateOrderStatus()
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
            Order order = new Order(customerUsername, products);
            order.AddProduct(new Product("5W-30", 23.54m, 3, ProductType.TRUCK), 2);
            orders.Add(order);

            // Delivery Find Orders with 
            Sales s = new Sales("User", "Pass");
            orders = s.UpdateOrderStatus(orders, order, "PROCESSING");
            Order updatedOrder = orders.Find(o => o.OrderName == customerUsername);

            Assert.AreEqual(OrderStatus.PROCESSING, updatedOrder.OrderStatus, "OrderStatus has been updated");
        }
    }
}
