using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeClassLibrary;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vectorRenderer = new VectorRenderer();
            var rasterRenderer = new RasterRenderer();

            var vectorCircle = new Circle(vectorRenderer, 5);
            var rasterSquare = new Square(rasterRenderer, 4);
            var vectorTriangle = new Triangle(vectorRenderer, 6);

            vectorCircle.Draw();
            rasterSquare.Draw();
            vectorTriangle.Draw();

            vectorCircle.Resize(2);
            vectorCircle.Draw();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
