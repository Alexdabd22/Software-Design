using System;
using System.Collections.Generic;
using ComposerClassLibrary;

namespace Composer
{
    class Program
    {
        static void Main(string[] args)
        {
            var tableFlyweight = new LightElementFlyweight("table", "block");
            var trFlyweight = new LightElementFlyweight("tr", "block");
            var thFlyweight = new LightElementFlyweight("th", "block");
            var tdFlyweight = new LightElementFlyweight("td", "block");
            var theadFlyweight = new LightElementFlyweight("thead", "block");
            var tbodyFlyweight = new LightElementFlyweight("tbody", "block");

            var table = new LightElementNode(tableFlyweight, false, new List<string> { "table" }, null);
            var thead = new LightElementNode(theadFlyweight);
            var trHead = new LightElementNode(trFlyweight);
            trHead.AddChild(new LightElementNode(thFlyweight, false, null, new List<LightNode> { new LightTextNode("Заголовок 1") }));
            trHead.AddChild(new LightElementNode(thFlyweight, false, null, new List<LightNode> { new LightTextNode("Заголовок 2") }));
            thead.AddChild(trHead);

            var tbody = new LightElementNode(tbodyFlyweight);
            for (int i = 0; i < 3; i++)
            {
                var trBody = new LightElementNode(trFlyweight);
                for (int j = 0; j < 2; j++)
                {
                    trBody.AddChild(new LightElementNode(tdFlyweight, false, null, new List<LightNode> { new LightTextNode($"Комiрка {i + 1},{j + 1}") }));
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
