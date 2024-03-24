using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public class KiaomiFactory : IDeviceFactory
    {
        public Ebook CreateEbook()
        {
            return new Ebook("Kiaomi", 256, "3000 x 1500");
        }

        public Laptop CreateLaptop()
        {

            return new Laptop("Kiaomi", "GTX 1030", "HD", false);
        }

        public Netbook CreateNetbook()
        {
            return new Netbook("Kiaomi", "Ryzen 3 1200", 512, 8);
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone("Kiaomi", "Android", "+380123456789");
        }
    }
}
