// FileName: Admin.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
using System.Collections.Generic;

namespace PT13.src
{
    /// <summary>
    /// Sales person.
    /// </summary>
    public class SalesPerson : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PT13.src.SalesPerson"/> class.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public SalesPerson(string username, string password) : base(username, password) { }

        /// <summary>
        /// Adds a new product to stock.
        /// </summary>
        /// <returns>The product.</returns>
        /// <param name="products">Products.</param>
        public List<Product> AddProduct(List<Product> products)
        {
            Console.WriteLine("Creating a new product...");
            Console.WriteLine("Enter the Product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Product Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Product Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Product Type (car, motorcycle, truck, bus): ");
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
            Console.WriteLine("Product successfully added to stock.");

            return products;
        }

        /// <summary>
        /// Edits a product.
        /// </summary>
        /// <returns>The product.</returns>
        /// <param name="products">Products.</param>
        public List<Product> EditProduct(List<Product> products)
        {
            Console.WriteLine("Enter name of product to Edit: ");
            string editProductName = Console.ReadLine();
            Product editProduct = products.Find(p => p.Name == editProductName);
            if (editProduct == null)
            {
                Console.WriteLine("Cannot find product with name: " + editProductName);
                return products;
            }
            products.Remove(editProduct);
            Console.WriteLine("Enter the new Product Name: ");
            string editName = Console.ReadLine();
            Console.WriteLine("Enter the new Product Price: ");
            decimal editPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Product Quantity: ");
            int editQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Product Type: ");
            string editType = Console.ReadLine().ToLower();
            ProductType editActualType = ProductType.BUS;
            switch (editType)
            {
                case ("car"):
                    editActualType = ProductType.CAR;
                    break;
                case ("motorcycle"):
                    editActualType = ProductType.MOTORCYCLE;
                    break;
                case ("truck"):
                    editActualType = ProductType.TRUCK;
                    break;
            }
            products.Add(new Product(editName, editPrice, editQuantity, editActualType));
            Console.WriteLine("Product successfully updated.");
            return products;
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <returns>The product.</returns>
        /// <param name="products">Products.</param>
        public List<Product> DeleteProduct(List<Product> products)
        {
            Console.WriteLine("Enter product name: ");
            string deleteProductName = Console.ReadLine();
            products = DeleteProduct(products, deleteProductName);

            return products;
        }
        /// <summary>
        /// Second Method to bypass Console.ReadLine() for testing
        /// </summary>
        /// <returns>The product.</returns>
        /// <param name="products">Products.</param>
        /// <param name="deleteProductName">Delete product name.</param>
        public List<Product> DeleteProduct(List<Product> products, string deleteProductName)
        {
            Product product = products.Find(p => p.Name == deleteProductName);
            if (product == null)
            {
                Console.WriteLine("Cannot find product with name: " + deleteProductName);
            }
            else
            {
                products.Remove(product);
                Console.WriteLine("Product Removed from Stock.");
            }
            return products;
        }

        /// <summary>
        /// Displays the orders.
        /// </summary>
        /// <param name="orders">Orders.</param>
        /// <param name="products">Products.</param>
        public void DisplayOrders(List<Order> orders, List<Product> products)
        {
            foreach (Order o in orders)
            {
                Console.WriteLine("Order ID: " + o.OrderID + " Oder name: " + o.OrderName + " Order Status: " + o.OrderStatus.ToString());
                foreach (Product p in o.OrderList)
                {
                    Product checkQuantity = products.Find(c => c.Name == p.Name);
                    // Display the order quantity
                    // A negative number idicates how many needed to fill all the orders
                    Console.WriteLine("\t" + p.Quantity + " " + p.Name +
                        " [" + checkQuantity.Quantity.ToString() + " " + "available]");
                }
            }
        }

        /// <summary>
        /// Updates the order status.
        /// </summary>
        /// <returns>The order status.</returns>
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
                if (updateSatusOrder.OrderStatus != actual)
                {
                    orders = UpdateOrderStatus(orders, updateSatusOrder, actual);
                    Console.WriteLine("Updated Order: " + updateSatusOrder.OrderID + " Status = " + updateSatusOrder.OrderStatus);
                }
            }
            else
            {
                Console.WriteLine("Cannot find order with orderID: " + selectID);
            }
            return orders;
        }

        /// <summary>
        /// Second Update order status to bypass the console readline, for testing
        /// </summary>
        /// <returns>The order status.</returns>
        /// <param name="updateSatusOrder">Update satus order.</param>
        /// <param name="actual">Status.</param>
        public List<Order> UpdateOrderStatus(List<Order> orders, Order updateSatusOrder, OrderStatus actual)
        {
            orders.Remove(updateSatusOrder);
            updateSatusOrder.OrderStatus = actual;
            orders.Add(updateSatusOrder);

            return orders;
        }

        /// <summary>
        /// Prints the sales details.
        /// </summary>
        /// <param name="products">Products.</param>
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
                case ("bus"):
                    actualType = ProductType.BUS;
                    break;
                default:
                    Console.WriteLine("Invalid product type. Using BUS.");
                    break;
            }
            List<Product> productsOfType = products.FindAll(t => t.ProductType == actualType);
            foreach (Product p in productsOfType)
            {
                Console.WriteLine("Product Name: " + p.Name + " Quantity in stock: " + p.Quantity);
            }
        }
    }
}