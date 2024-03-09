using System;

namespace MoneyClassLibrary
{
    public class WarehouseItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; set; }
        public DateTime LastDeliveryDate { get; private set; }

        public WarehouseItem(Product product, int quantity, DateTime lastDeliveryDate)
        {
            Product = product;
            Quantity = quantity;
            LastDeliveryDate = lastDeliveryDate;
        }
    }
}
