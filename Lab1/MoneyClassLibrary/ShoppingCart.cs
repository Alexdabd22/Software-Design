using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public class ShoppingCart
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public decimal TotalPrice()
        {
            return _products.Sum(p => p.Price.Currency.MajorUnit + p.Price.Currency.MinorUnit / 100m);
        }
    }
}
