using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public class Reporting
    {
        private Warehouse _warehouse;
        private List<string> _invoices = new List<string>();  

        public Reporting(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void RegisterArrival(WarehouseItem item)
        {
            _warehouse.AddItem(item);
            string arrivalInvoice = $"ПРИЇЗД: {item.Product.Name}, Кiлькiсть: {item.Quantity}, Дата: {DateTime.Now}";
            _invoices.Add(arrivalInvoice);
            Console.WriteLine(arrivalInvoice);  
        }

        public void RegisterShipment(string productName, int quantity)
        {
            // Пошук товару на складі
            var item = _warehouse.GetInventory().FirstOrDefault(i => i.Product.Name == productName);

            if (item != null && quantity <= item.Quantity)
            {
                item.Quantity -= quantity;  
                string shipmentInvoice = $"ВIДПРАВЛЕННЯ: {productName}, Кiлькiсть: {quantity}, Дата: {DateTime.Now}";
                _invoices.Add(shipmentInvoice);
                Console.WriteLine(shipmentInvoice);
            }
            else
            {
                Console.WriteLine($"Помилка: недостатня кiлькiсть {productName} або його немає на складi.");
            }
        }

        public IEnumerable<WarehouseItem> InventoryReport()
        {
            return _warehouse.GetInventory();
        }

        public void PrintAllInvoices()
        {
            foreach (var invoice in _invoices)
            {
                Console.WriteLine(invoice);
            }
        }
    }
}
