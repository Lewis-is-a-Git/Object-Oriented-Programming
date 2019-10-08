// FileName: Delivery.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    public class Delivery : User
    {
        public Delivery() { }
        public Delivery(string username, string password) : base(username, password) { }

        public List<Order> UpdateOrderStatus(List<Order> orders)
        {
            Console.WriteLine("Enter Order ID: ");
            string orderID = Console.ReadLine();
            Order updateSatusOrder = orders.Find(o => o.OrderID == orderID);
            Console.WriteLine("Enter New status for order " + orderID + ": ");
            Console.WriteLine("Options: NEW, PROCESSING, SHIPPING, DELIVERED, CANCELED");
            string status = Console.ReadLine().ToUpper();
            OrderStatus actual = OrderStatus.NEW; ;
            switch (status)
            {
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
                    Console.WriteLine("entry invalid, order " + orderID + " is reset to new.");
                    break;
            }
            orders = UpdateOrderStatus(orders, updateSatusOrder, actual);

            return orders;
        }

        /// <summary>
        /// Second Update Order status to bypass Console.ReadLine() for Testing
        /// </summary>
        /// <returns>The order status.</returns>
        /// <param name="orders">Orders.</param>
        /// <param name="updateSatusOrder">Update satus order.</param>
        /// <param name="status">Status.</param>
        public List<Order> UpdateOrderStatus(List<Order> orders, Order updateSatusOrder, OrderStatus actual)
        {
            orders.Remove(updateSatusOrder);
            updateSatusOrder.OrderStatus = actual;
            orders.Add(updateSatusOrder);

            return orders;
        }
    }
}
