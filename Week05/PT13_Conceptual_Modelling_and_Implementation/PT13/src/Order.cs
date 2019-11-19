// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;
using PT13.src;

namespace PT13
{
    /// <summary>
    /// Order.
    /// </summary>
    public class Order
    {
        private decimal _totalPrice;          // total price of order
        private readonly String _orderID;     // unique order ID
        private readonly String _orderName;   // name of user that owns order
        private readonly DateTime _orderDate; // date of order
        private List<Product> _orderList;     // List of products in order
        private OrderStatus _orderStatus;     // order status

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PT13.Order"/> class.
        /// </summary>
        /// <param name="userName">User name.</param>
        public Order(string userName)
        {
            _orderName = userName;
            _orderList = new List<Product>();
            _orderDate = DateTime.Now;
            _orderID = _orderName + _orderDate.ToString("yyMMddHHMMss") + _orderDate.Millisecond;
            _orderStatus = OrderStatus.NEW;
            CalculatePrice();
        }


        public OrderStatus OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }
        public string OrderName { get { return _orderName; } }
        public string OrderID { get { return _orderID; } }
        public List<Product> OrderList { get { return _orderList; } }
        public decimal TotalPrice { get { CalculatePrice(); return _totalPrice; } }

        /// <summary>
        /// Calculates the total price.
        /// </summary>
        public void CalculatePrice()
        {
            decimal price = 0;
            foreach (Product p in _orderList)
            {
                price += (p.Quantity * p.Price);
            }
            _totalPrice = price;
        }

        /// <summary>
        /// Adds new product.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <param name="quantity">Quantity.</param>
        /// <param name="products">Products.</param>
        public void AddProduct(Product product, int quantity, List<Product> products)
        {
            Product addProduct = products.Find(p => p.Name == product.Name);
            addProduct.Quantity = quantity;
            _orderList.Add(addProduct);
            CalculatePrice();
        }

        /// <summary>
        /// Displays the order details.
        /// </summary>
        internal void DisplayOrderDetails()
        {
            Console.WriteLine("Order ID: " + _orderID + " Order Date: " + _orderDate + " Order Status: " + _orderStatus.ToString());
            foreach (Product p in _orderList)
            {
                Console.WriteLine("\t" + "Item Name: " + p.Name + " Quantity: " + p.Quantity + " Unit Price: " + p.Price);
            }
            Console.WriteLine("\t Order Total: $" + _totalPrice);
        }
    }
}