using System;
using HtmlTemplateLibrary;

namespace ConsoleHtmlTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlElementLifecycle divLifecycle = new CustomDivElementLifecycle();
            HtmlElementLifecycle spanLifecycle = new CustomSpanElementLifecycle();

            divLifecycle.Render();
            Console.WriteLine();
            spanLifecycle.Render();

            Console.ReadLine();
        }
    }
}
