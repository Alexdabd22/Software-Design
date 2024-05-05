using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer
{
    public class HtmlStructureVisitor : ILightNodeVisitor
    {
        public void VisitElementNode(IElementNode elementNode)
        {
            if (elementNode is LightElementNode concreteElement)
            {
                Console.WriteLine($"Елемент: {concreteElement.TagName}");

                foreach (var child in concreteElement.Children)
                {
                    child.Accept(this);
                }
            }
        }

        public void VisitTextNode(ITextNode textNode)
        {
            if (textNode is LightTextNode concreteText)
            {
                Console.WriteLine($"Текстовий вузол: {concreteText.Text}");
            }
        }
    }
}
