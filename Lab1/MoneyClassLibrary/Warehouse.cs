using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public class Warehouse
    {
        private List<WarehouseItem> _items = new List<WarehouseItem>();

        public void AddItem(WarehouseItem item)
        {
            _items.Add(item);
        }

        public IEnumerable<WarehouseItem> GetInventory()
        {
            return _items;
        }
    }
}
