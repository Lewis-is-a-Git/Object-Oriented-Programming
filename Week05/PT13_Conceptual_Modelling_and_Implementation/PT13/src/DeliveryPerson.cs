// FileName: Delivery.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    /// <summary>
    /// Delivery person.
    /// </summary>
    public class DeliveryPerson : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PT13.src.DeliveryPerson"/> class.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public DeliveryPerson(string username, string password) : base(username, password) { }

        /// <summary>
        /// Updates the order status.
        /// </summary>
        /// <returns>Updated List of orders</returns>
        /// <param name="orders">Orders.</param>
        public List<Order> UpdateOrderStatus(List<Order> orders)
        {
            Console.WriteLine("List of order ID's:");
            int i = 0;
            foreach (Order o in orders)
            {
                Console.WriteLine("[" + i++ + "] " + o.OrderID);
            }

            Console.WriteLine("Select Order ID []: ");
            int selectID = int.Parse(Console.ReadLine());
            Order updateSatusOrder = orders[selectID];
            if (updateSatusOrder != null)
            {
                Console.WriteLine("Enter New status for order " + updateSatusOrder.OrderID + ": ");
                Console.WriteLine("Options: NEW, PROCESSING, SHIPPING, DELIVERED, CANCELED");
                string status = Console.ReadLine().ToUpper();
                OrderStatus actual = updateSatusOrder.OrderStatus;
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
                        Console.WriteLine("entry invalid, order " + updateSatusOrder.OrderID + " is " + updateSatusOrder.OrderStatus);
                        break;
                }
                orders = UpdateOrderStatus(orders, updateSatusOrder, actual);
                Console.WriteLine("Updated Order: " + updateSatusOrder.OrderID + " Status = " + updateSatusOrder.OrderStatus);
            }
            else
            {
                Console.WriteLine("Cannot find order with orderID: " + selectID);
            }
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
