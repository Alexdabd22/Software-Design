using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer
{
    public abstract class LightNode
    {
        public abstract string OuterHtml(int indentLevel = 0);
    }
}

