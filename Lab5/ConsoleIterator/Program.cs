using System;
using Composer;

namespace ConsoleIterator
{
    internal class Program
    {
        static void Main()
        {

            var root = new LightElementNode(new LightElementFlyweight("div", "block"));
            var paragraphNode = new LightElementNode(new LightElementFlyweight("p", "block"));
            var spanNode = new LightElementNode(new LightElementFlyweight("span", "inline"));
            var textNode1 = new LightTextNode("Welcome to the webpage!");
            var textNode2 = new LightTextNode("This is a paragraph.");
            var textNode3 = new LightTextNode("Inline text inside a span.");

            root.AddChild(textNode1);
            root.AddChild(paragraphNode);
            paragraphNode.AddChild(textNode2);
            root.AddChild(spanNode);
            spanNode.AddChild(textNode3);

            Console.WriteLine("Tree traversal using LightNodeIterator with `while`:");
            var iterator = new LightNodeIterator(root);
            while (iterator.MoveNext())
            {
                var currentNode = iterator.Current;
                Console.WriteLine(currentNode.OuterHtml());
            }

            Console.WriteLine("\nDirect children of `root` using `foreach`:");
            foreach (var child in root)
            {
                Console.WriteLine(child.OuterHtml());
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
