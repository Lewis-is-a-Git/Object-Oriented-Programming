// FileName: Program.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using PT13.src;

namespace PT13
{
    public class Product
    {
        private readonly string _name;
        private decimal _price;
        private int _quantity;
        private readonly ProductType _productType;

        public Product(string name, decimal price, int quantity, ProductType type)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
            _productType = type;
        }

        public string Name { get => _name; }
        public decimal Price { get => _price; set => _price = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public ProductType ProductType { get => _productType; }
    }
}