using System;
using System.Net.Http;
using System.Threading.Tasks;
using LightweightClassLibrary;

namespace Lightweight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string bookTextUrl = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
            string bookText;

            using (var httpClient = new HttpClient())
            {
                bookText = await httpClient.GetStringAsync(bookTextUrl);
            }

            string[] lines = bookText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            var factory = new LightElementFactory();

            var htmlRootNodeWithoutFlyweight = HTMLConverter.ConvertTextToHtml(lines);
            var memoryUsageBeforeOptimization = MemoryMeasurement.CalculateMemoryUsage(htmlRootNodeWithoutFlyweight);

            var htmlRootNodeWithFlyweight = HTMLConverter.ConvertTextToHtmlUsingFlyweight(lines, factory);
            var memoryUsageAfterOptimization = MemoryMeasurement.CalculateMemoryUsage(htmlRootNodeWithFlyweight);

            // Показуємо HTML в консолі.
            Console.WriteLine(htmlRootNodeWithoutFlyweight.OuterHtml(0));

            Console.WriteLine($"Використання пам'ятi до оптимзацiї: {memoryUsageBeforeOptimization} байт");
            Console.WriteLine($"Використання пам'ятi пiсля оптимiзацiї: {memoryUsageAfterOptimization} байт");

            Console.WriteLine("\nНатиснiть будь-яку клавiшу, щоб вийти...");
            Console.ReadKey();
        }
    }
}
