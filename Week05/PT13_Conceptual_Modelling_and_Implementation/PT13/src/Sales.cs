// FileName: Admin.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    public class Sales : User
    {
        public Sales() { }
        public Sales(string username, string password) : base(username, password) { }

        public List<Product> AddProduct(List<Product> products)
        {
            Console.WriteLine("Creating a new product...");
            Console.WriteLine("Enter the Product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Product Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Product Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Product Type: ");
            string type = Console.ReadLine().ToLower();
            ProductType actualType = ProductType.BUS;
            switch (type)
            {
                case ("car"):
                    actualType = ProductType.CAR;
                    break;
                case ("motorcycle"):
                    actualType = ProductType.MOTORCYCLE;
                    break;
                case ("truck"):
                    actualType = ProductType.TRUCK;
                    break;
            }
            products.Add(new Product(name, price, quantity, actualType));

            return products;
        }

        public List<Product> EditProduct(List<Product> products)
        {
            Console.WriteLine("Enter Product name to Edit: ");
            string EditproductName = Console.ReadLine();
            Product Editproduct = products.Find(p => p.Name == EditproductName);
            products.Remove(Editproduct);
            Console.WriteLine("Enter the new Product Name: ");
            string Editname = Console.ReadLine();
            Console.WriteLine("Enter the new Product Price: ");
            decimal Editprice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Product Quantity: ");
            int Editquantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Product Type: ");
            string Edittype = Console.ReadLine().ToLower();
            ProductType EditactualType = ProductType.BUS;
            switch (Edittype)
            {
                case ("car"):
                    EditactualType = ProductType.CAR;
                    break;
                case ("motorcycle"):
                    EditactualType = ProductType.MOTORCYCLE;
                    break;
                case ("truck"):
                    EditactualType = ProductType.TRUCK;
                    break;
            }
            products.Add(new Product(Editname, Editprice, Editquantity, EditactualType));

            return products;
        }

        public List<Product> DeleteProduct(List<Product> products)
        {
            Console.WriteLine("Enter product name: ");
            string DeleteProductName = Console.ReadLine();
            products = DeleteProduct(products, DeleteProductName);

            return products;
        }
        /// <summary>
        /// Second Method to bypass Console.ReadLine() for testing
        /// </summary>
        /// <returns>The product.</returns>
        /// <param name="products">Products.</param>
        /// <param name="DeleteProductName">Delete product name.</param>
        public List<Product> DeleteProduct(List<Product> products, string DeleteProductName)
        {
            Product product = products.Find(p => p.Name == DeleteProductName);
            products.Remove(product);

            return products;
        }

        public void DisplayOrders(List<Order> orders, List<Product> products)
        {
            foreach (Order o in orders)
            {
                Console.WriteLine("Order ID: " + o.OrderID + " Oder name: " + o.OrderName + " Order Status: " + o.OrderStatus.ToString());
                foreach (Product p in o.OrderList)
                {
                    Product checkQuantity = products.Find(c => c.Name == p.Name);

                    if (p.Quantity <= checkQuantity.Quantity)
                    {
                        Console.WriteLine(p.Name + " is in stock");
                    }
                    else
                    {
                        Console.WriteLine(p.Name + " is unavailable");
                    }
                }
            }
        }

        public List<Order> UpdateOrderStatus(List<Order> orders)
        {
            Console.WriteLine("To update order status, enter order ID: ");
            string orderID = Console.ReadLine();
            Order updateSatusOrder = orders.Find(u => u.OrderID == orderID);
            Console.WriteLine("Enter New status for order " + orderID + ": ");
            Console.WriteLine("Options: NEW, PROCESSING, SHIPPING, DELIVERED, CANCELED");
            string status = Console.ReadLine().ToUpper();

            orders = UpdateOrderStatus(orders, updateSatusOrder, status);
            return orders;
        }

        /// <summary>
        /// Second Update order status to bypass the console readline, for testing
        /// </summary>
        /// <returns>The order status.</returns>
        /// <param name="updateSatusOrder">Update satus order.</param>
        /// <param name="status">Status.</param>
        public List<Order> UpdateOrderStatus(List<Order> orders, Order updateSatusOrder, string status)
        {
            OrderStatus actual = OrderStatus.NEW;
            switch (status)
            {
                case ("NEW"):
                    actual = OrderStatus.NEW;
                    break;
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
                    Console.WriteLine("entry invalid order is set to new.");
                    break;
            }
            orders.Remove(updateSatusOrder);
            updateSatusOrder.OrderStatus = actual;
            orders.Add(updateSatusOrder);

            return orders;
        }

        public void PrintSalesDetails(List<Product> products)
        {
            Console.WriteLine("Enter the Product Type: ");
            Console.WriteLine("Options: bus, car, motorcycle, truck");
            string productType = Console.ReadLine().ToLower();
            ProductType actualType = ProductType.BUS;
            switch (productType)
            {
                case ("car"):
                    actualType = ProductType.CAR;
                    break;
                case ("motorcycle"):
                    actualType = ProductType.MOTORCYCLE;
                    break;
                case ("truck"):
                    actualType = ProductType.TRUCK;
                    break;
                default:
                    Console.WriteLine("Invalid product type. Using BUS.");
                    break;
            }
            List<Product> productsOfType = products.FindAll(t => t.ProductType == actualType);
            foreach (Product p in productsOfType)
            {
                Console.WriteLine("Product Name: " + p.Name + " Product Quantity: " + p.Quantity);
            }
        }
    }
}