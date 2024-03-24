using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public class BalaxyFactory : IDeviceFactory
    {
        public Ebook CreateEbook()
        {
            return new Ebook("Balaxy", 256, "3000 x 1500");
        }

        public Laptop CreateLaptop()
        {
            return new Laptop("Balaxy", "RTX 2070", "Full HD", false);
        }

        public Netbook CreateNetbook()
        {
            return new Netbook("Balaxy", "Intel Core i9", 1024, 32);
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone("Balaxy", "Android", "+380123456789");
        }
    }
}
