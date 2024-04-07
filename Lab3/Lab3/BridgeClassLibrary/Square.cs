using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeClassLibrary
{
    public class Square : Shape
    {
        private float side;

        public Square(IRenderer renderer, float side) : base(renderer)
        {
            this.side = side;
        }

        public override void Draw()
        {
            renderer.RenderShape("Square");
        }

        public override void Resize(float factor)
        {
            side *= factor;
        }
    }
}
