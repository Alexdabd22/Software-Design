using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public abstract class Device : IDevice
    {
        public string Brand { get; private set; }

        protected Device(string brand)
        {
            Brand = brand;
        }

        public abstract string Describe();
    }
}
