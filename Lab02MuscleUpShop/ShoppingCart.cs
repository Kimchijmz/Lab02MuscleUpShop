using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02MuscleUpShop
{
    internal class ShoppingCart 
    {
        private List<Product> _inStoreProducts;
        private int _quantity;
        private decimal _totalItems = 0;
        public decimal _totalPrice;

        public List<Product> InStoreProducts { get { return _inStoreProducts; } set { _inStoreProducts = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }    
        public decimal TotalItems { get { return _totalItems; } set { _totalItems = value; } }
        public decimal TotalPrice { get { return _totalPrice; } set { _totalPrice = value; } }

        public override string ToString()
        {
            return $"{Quantity} st\t {InStoreProducts} \ttotal : {TotalPrice}";
        }
        public void Display()
        {
            foreach (Product product in InStoreProducts)
            {
                Console.WriteLine($"{product.ProductName} , {product.Price}");
            }
        }
        /*public bool SameItems(string items)
        {
            return this.InStoreProducts.ProductName.Equals(TotalItems);
        }*/


        public ShoppingCart()
        {
            this._inStoreProducts = new List<Product>();
            Quantity = 0;
            TotalItems = 0;

        }
    }
}
