// FileName: TestProduct.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 8/10/2019
using System;
using NUnit.Framework;
using PT13.src;
using System.Collections.Generic;
namespace PT13.Testing
{
    /// <summary>
    /// Test product.
    /// </summary>
    [TestFixture]
    public class TestProduct
    {
        /// <summary>
        /// Tests the create product.
        /// </summary>
        [Test]
        public void TestCreateProduct()
        {
            List<Product> products = new List<Product>();

            string pName = "Car Oil 5L";
            decimal pPrice = 40.00m;
            int pQuantity = 20;
            ProductType pType = ProductType.CAR;
            Product p = new Product(pName, pPrice, pQuantity, pType);

            products.Add(p);

            Assert.AreEqual(1, products.Count, "A product has been created and added to products.");

        }

        /// <summary>
        /// Tests the delete product.
        /// </summary>
        [Test]
        public void TestDeleteProduct()
        {
            List<Product> products = new List<Product>();
            // Create product to remove from list
            string pName = "Car Oil 5L";
            decimal pPrice = 40.00m;
            int pQuantity = 20;
            ProductType pType = ProductType.CAR;
            Product p = new Product(pName, pPrice, pQuantity, pType);
            products.Add(p);
            Assert.AreEqual(1, products.Count, "A product has been created and added to products.");

            Sales s = new Sales("User", "Pass")
            {
                Credentials = "sales"
            };
            s.DeleteProduct(products, pName);
            Assert.IsEmpty(products, "Product has been deleted from products.");
        }
    }
}
