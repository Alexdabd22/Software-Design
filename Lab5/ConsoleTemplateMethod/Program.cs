using System;
using CommonLibrary;
using TemplateMethod;
namespace ConsoleTemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var divLifecycle = new CustomDivElementLifecycle();
            var spanLifecycle = new CustomSpanElementLifecycle();

            Console.WriteLine("=== Рендеринг Div ===");
            divLifecycle.Render();
            Console.WriteLine("\n=== Завершено рендеринг Div ===");

            Console.WriteLine("\n=== Рендеринг Span ===");
            spanLifecycle.Render();
            Console.WriteLine("\n=== Завершено рендеринг Span ===");

            Console.WriteLine("\n=== Порiвняння ===");
            CompareLifecycles(divLifecycle, spanLifecycle);

            Console.ReadLine();
        }

        // Метод для порівняння різних циклів
        static void CompareLifecycles(CustomDivElementLifecycle div, CustomSpanElementLifecycle span)
        {
            Console.WriteLine("\nПорiвнюємо життєвi цикли:");

            Console.WriteLine("\n1. Створення:");
            div.OnCreated();
            span.OnCreated();

            Console.WriteLine("\n2. Застосування стилiв:");
            div.ApplyStyles();
            span.ApplyStyles();

            Console.WriteLine("\n3. Застосування класiв:");
            div.ApplyClassList();
            span.ApplyClassList();
        }
    }
}
