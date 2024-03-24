using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public class IProneFactory : IDeviceFactory
    {
        public Ebook CreateEbook()
        {
            return new Ebook("IProne", 256, "3000 x 1500");
        }

        public Laptop CreateLaptop()
        {
            return new Laptop("IProne", "M3", "Retina", false);
        }

        public Netbook CreateNetbook()
        {
            return new Netbook("IProne", "Intel Core i7", 512, 16);
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone("IProne", "iOS", "+380987654321");
        }
    }

}
