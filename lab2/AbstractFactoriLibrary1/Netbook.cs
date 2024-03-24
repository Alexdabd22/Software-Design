using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public class Netbook : Device
    {
        public string Processor { get; private set; }
        public int StorageSizeGB { get; private set; }
        public int RamSizeGB { get; private set; }

        public Netbook(string brand, string processor, int storage, int ram) : base(brand)
        {
            Processor = processor;
            StorageSizeGB = storage;
            RamSizeGB = ram;
        }

        public override string Describe()
        {
            return $"[Netbook] Brand: {Brand}, CPU: {Processor}, Storage: {StorageSizeGB}GB, RAM: {RamSizeGB}GB";
        }
    }
}
