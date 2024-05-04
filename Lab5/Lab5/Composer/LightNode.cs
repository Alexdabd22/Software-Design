using System;
using System.Collections.Generic;
using System.Linq;
using State;

namespace Composer
{
    public abstract class LightNode
    {
        public abstract string OuterHtml(int indentLevel = 0);
    }
}

