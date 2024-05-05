using System;
using CommonLibrary;
using Composer;


namespace Visitor
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
