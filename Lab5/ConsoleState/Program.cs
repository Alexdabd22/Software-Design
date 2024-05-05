using System;
using Composer;


namespace ConsoleState
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new LightElementNode(new LightElementFlyweight("div"), false);
            root.AddClass("container");

            var paragraphNode = new LightElementNode(new LightElementFlyweight("p"), false);
            var textNode = new LightTextNode("Привiт, свiт!");

            paragraphNode.AddChild(textNode);
            root.AddChild(paragraphNode);

            Console.WriteLine("Зараз вузол root видимий:");
            Console.WriteLine(root.OuterHtml());

            Console.WriteLine("\nЗмiнюємо стан вузла root на прихований...");
            root.Hide();
            Console.WriteLine(root.OuterHtml());

            Console.WriteLine("\nВiдновлюємо видимiсть вузла root...");
            root.Show();
            Console.WriteLine(root.OuterHtml());

            Console.ReadLine();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
