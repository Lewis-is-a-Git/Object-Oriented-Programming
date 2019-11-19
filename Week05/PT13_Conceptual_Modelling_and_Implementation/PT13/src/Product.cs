// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using PT13.src;

namespace PT13
{
    /// <summary>
    /// Product.
    /// </summary>
    public class Product
    {
        private readonly string _name;             // product name
        private decimal _price;                    // unit price
        private int _quantity;                     // total available units
        private readonly ProductType _productType; // type of product

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price.</param>
        /// <param name="quantity">Quantity.</param>
        /// <param name="type">Type.</param>
        public Product(string name, decimal price, int quantity, ProductType type)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
            _productType = type;
        }

        public string Name { get { return _name; } }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public ProductType ProductType { get { return _productType; } }
    }
}