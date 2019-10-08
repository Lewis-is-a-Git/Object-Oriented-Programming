// FileName: TestStockManagement.cs
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
    /// Test stock management.
    /// </summary>
    [TestFixture]
    public class TestStockManagement
    {
        /// <summary>
        /// Tests the add new product.
        /// </summary>
        [Test]
        public void TestAddNewProduct()
        {
            // Test that adding stock to an order reduces the quantity of products
            Assert.AreEqual(true, false); // Not implemented yet
        }


    }
}
