using System;
using Composer;
using Command;

namespace ConsoleCommand
{
    internal class Program
    {
        static void Main()
        {
            var commandManager = new CommandManager();

            var textNode = new LightTextNode("Initial text");

            Console.WriteLine("Initial Text Node:");
            Console.WriteLine(textNode.OuterHtml());

            var changeText1 = new ChangeTextCommand(textNode, "Updated text 1");
            var changeText2 = new ChangeTextCommand(textNode, "Updated text 2");

            commandManager.ExecuteCommand(changeText1);
            Console.WriteLine("\nAfter executing changeText1:");
            Console.WriteLine(textNode.OuterHtml());

            commandManager.ExecuteCommand(changeText2);
            Console.WriteLine("\nAfter executing changeText2:");
            Console.WriteLine(textNode.OuterHtml());

            commandManager.Undo();
            Console.WriteLine("\nAfter undoing changeText2:");
            Console.WriteLine(textNode.OuterHtml());

            commandManager.Undo();
            Console.WriteLine("\nAfter undoing changeText1:");
            Console.WriteLine(textNode.OuterHtml());
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
