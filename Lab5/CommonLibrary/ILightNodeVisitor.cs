using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ILightNodeVisitor
    {
        void VisitElementNode(IElementNode elementNode);
        void VisitTextNode(ITextNode textNode);
    }
}
