// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;
using PT13.src;

namespace PT13
{
    public class Order
    {
        private decimal _totalPrice;
        private readonly String _orderID;
        private readonly String _orderName;
        private readonly DateTime _orderDate;
        private List<Product> _orderList;
        private List<Product> _stock;
        private OrderStatus _orderStatus;

        public Order(string userName, List<Product> products)
        {
            _orderName = userName;
            _orderList = new List<Product>();
            _stock = products;
            _orderDate = new DateTime();
            _orderID = _orderName + _orderDate.ToShortDateString() + _orderDate.ToShortTimeString();
            _orderStatus = OrderStatus.NEW;
        }


        public OrderStatus OrderStatus { get => _orderStatus; set => _orderStatus = value; }
        public string OrderName => _orderName;
        public string OrderID { get => _orderID; }
        public List<Product> OrderList { get => _orderList; }

        public void CalculatePrice()
        {
            decimal price = 0;
            foreach (Product p in _orderList)
            {
                price += (p.Quantity * p.Price);
            }
            _totalPrice = price;
        }

        public void AddProduct(Product product, int quantity)
        {
            Product addProduct = _stock.Find(p => p.Name == product.Name);
            if (product.Quantity >= quantity)
            {
                addProduct.Quantity = quantity;
                _orderList.Add(addProduct);
            }
            else
            {
                Console.WriteLine("Not enough products in stock.");
            }

        }
    }
}