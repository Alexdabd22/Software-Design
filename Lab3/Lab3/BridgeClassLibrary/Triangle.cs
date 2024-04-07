using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeClassLibrary
{
    public class Triangle : Shape
    {
        private float side;

        public Triangle(IRenderer renderer, float side) : base(renderer)
        {
            this.side = side;
        }

        public override void Draw()
        {
            renderer.RenderShape("Triangle");
        }

        public override void Resize(float factor)
        {
            side *= factor;
        }
    }
}
