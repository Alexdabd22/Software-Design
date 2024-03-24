using System;
using System.Text;
using AbstractFactoriLibrary1;

namespace AbstractFactori
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 

            while (true)
            {
                Console.WriteLine("Виберіть опцію:");
                Console.WriteLine("1. Вивести інформацію про Kiaomi");
                Console.WriteLine("2. Вивести інформацію про IProne");
                Console.WriteLine("3. Вивести інформацію про Balaxy");
                Console.WriteLine("4. Вивести інформацію про всі бренди");
                Console.WriteLine("5. Вихід");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        PrintBrandInformation("Kiaomi", new KiaomiFactory());
                        break;
                    case "2":
                        PrintBrandInformation("IProne", new IProneFactory());
                        break;
                    case "3":
                        PrintBrandInformation("Balaxy", new BalaxyFactory());
                        break;
                    case "4":
                        PrintAllBrandsInformation();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, виберіть опцію зі списку.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void PrintBrandInformation(string brand, IDeviceFactory factory)
        {
            Console.WriteLine($"Інформація про {brand}:");
            var smartphone = factory.CreateSmartphone();
            var ebook = factory.CreateEbook();
            var laptop = factory.CreateLaptop();
            var netbook = factory.CreateNetbook();

            Console.WriteLine($"{smartphone.Describe()}");
            Console.WriteLine($"{ebook.Describe()}");
            Console.WriteLine($"{laptop.Describe()}");
            Console.WriteLine($"{netbook.Describe()}");
        }

        static void PrintAllBrandsInformation()
        {
            Console.WriteLine("Інформація про всі бренди:");
            PrintBrandInformation("Kiaomi", new KiaomiFactory());
            PrintBrandInformation("IProne", new IProneFactory());
            PrintBrandInformation("Balaxy", new BalaxyFactory());
        }
    }
}
