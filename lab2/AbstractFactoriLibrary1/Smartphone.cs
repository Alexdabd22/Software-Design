using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public class Smartphone : Device
    {
        public string OperatingSystem { get; private set; }
        public string PhoneNumber { get; private set; }

        public Smartphone(string brand, string os, string number) : base(brand)
        {
            OperatingSystem = os;
            PhoneNumber = number;
        }

        public override string Describe()
        {
            return $"[Smartphone] Brand: {Brand}, OS: {OperatingSystem}, Number: {PhoneNumber}";
        }
    }

}
