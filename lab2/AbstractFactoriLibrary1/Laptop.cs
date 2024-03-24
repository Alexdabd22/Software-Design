using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public class Laptop : Device
    {
        public string GraphicsCard { get; private set; }
        public string ScreenResolution { get; private set; }
        public bool HasTouchScreen { get; private set; }

        public Laptop(string brand, string gpu, string resolution, bool hasTouch) : base(brand)
        {
            GraphicsCard = gpu;
            ScreenResolution = resolution;
            HasTouchScreen = hasTouch;
        }

        public override string Describe()
        {
            return $"[Laptop] Brand: {Brand}, GPU: {GraphicsCard}, Resolution: {ScreenResolution}, Touch: {HasTouchScreen}";
        }
    }

}
