using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public class Ebook : Device
    {
        public int MemorySizeGB { get; private set; }
        public string DisplayResolution { get; private set; }

        public Ebook(string brand, int memory, string resolution) : base(brand)
        {
            MemorySizeGB = memory;
            DisplayResolution = resolution;
        }

        public override string Describe()
        {
            return $"[Ebook] Brand: {Brand}, Memory: {MemorySizeGB}GB, Display Resolution: {DisplayResolution}";
        }
    }

}
