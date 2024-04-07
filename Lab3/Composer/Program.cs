using System;
using System.Collections.Generic;
using ComposerClassLibrary;

namespace Composer
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new LightElementNode("table", "block", false, new List<string> { "table" }, null);

            var thead = new LightElementNode("thead");
            var trHead = new LightElementNode("tr");
            trHead.AddChild(new LightElementNode("th", "block", false, null, new List<LightNode> { new LightTextNode("Заголовок 1") }));
            trHead.AddChild(new LightElementNode("th", "block", false, null, new List<LightNode> { new LightTextNode("Заголовок 2") }));
            thead.AddChild(trHead);

            var tbody = new LightElementNode("tbody");
            for (int i = 0; i < 3; i++)
            {
                var trBody = new LightElementNode("tr");
                for (int j = 0; j < 2; j++)
                {
                    trBody.AddChild(new LightElementNode("td", "block", false, null, new List<LightNode> { new LightTextNode($"Комiрка {i + 1},{j + 1}") }));
                }
                tbody.AddChild(trBody);
            }

            table.AddChild(thead);
            table.AddChild(tbody);

            Console.WriteLine(table.OuterHtml());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
