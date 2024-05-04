using System;
using Composer;
using Command;

namespace ConsoleCommand
{
    internal class Program
    {
        static void Main()
        {
            var root = new LightElementNode(new LightElementFlyweight("div", "block"));
            var paragraphNode = new LightElementNode(new LightElementFlyweight("p", "block"));
            root.AddChild(paragraphNode);

            var commandManager = new CommandManager();

            var addClassCommand = new AddClassCommand(paragraphNode, "highlight");

            Console.WriteLine("Before adding class:");
            Console.WriteLine(paragraphNode.OuterHtml());

            commandManager.ExecuteCommand(addClassCommand);

            Console.WriteLine("\nAfter adding class 'highlight':");
            Console.WriteLine(paragraphNode.OuterHtml());

            commandManager.UndoLastCommand();

            Console.WriteLine("\nAfter undoing the add class command:");
            Console.WriteLine(paragraphNode.OuterHtml());

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
