using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MoneyClassLibrary;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Ініціалізація валют
            Dollar dollar = new Dollar(0, 0);
            Euro euro = new Euro(0, 0);

            // Створення продуктів
            Product PC = new Product("Комп'ютер", new Money(new Dollar(500, 0)), "Електронiка");
            Product Phone = new Product("Телефон", new Money(new Euro(10, 50)), "Електронiка");
            Product Tea = new Product("Зелений чай", new Money(new Euro(5, 25)), "Напої");
            Product Coffee = new Product("Кава", new Money(new Dollar(8, 50)), "Напої");

            //знижка на каву 
            int discountAmountCents = 3 * 100 + 25; // Переведення 3 доларів 25 центів у центи
            Coffee.ReducePrice(discountAmountCents);

            List<Product> products = new List<Product> { PC, Phone, Tea, Coffee };

            // Виведення інформації про всі продукти
            Console.WriteLine("Всi продукти:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} -- {product.Category} -- Цiна: {product.Price}");
            }
            // Ініціалізація складу
            Warehouse warehouse = new Warehouse();

            // Ініціалізація модуля звітності
            Reporting reporting = new Reporting(warehouse);

            // Реєстрація прибуття товарів на склад
            Console.WriteLine("\nРеєстрацiя надходження товару:");
            reporting.RegisterArrival(new WarehouseItem(PC, 10, DateTime.Now));
            reporting.RegisterArrival(new WarehouseItem(Phone, 100, DateTime.Now));
            reporting.RegisterArrival(new WarehouseItem(Tea, 120, DateTime.Now));
            reporting.RegisterArrival(new WarehouseItem(Coffee, 80, DateTime.Now));

            // Виведення звіту по інвентаризації
            Console.WriteLine("\nЗвiт про iнвентаризацiю:");
            foreach (var item in reporting.InventoryReport())
            {
                Console.WriteLine($"{item.Product.Name}: {item.Quantity} одиниць");
            }

            // Реєстрація відвантаження товару
            Console.WriteLine("\nОформлення вiдправлення товару:");
            reporting.RegisterShipment("Комп'ютер", 2);
            reporting.RegisterShipment("Телефон", 50);
            reporting.RegisterShipment("Зелений чай", 60);
            reporting.RegisterShipment("Кава", 65);

            // Виведення оновленого звіту по інвентаризації
            Console.WriteLine("\nОновлений звiт про iнвентаризацiю:");
            foreach (var item in reporting.InventoryReport())
            {
                Console.WriteLine($"{item.Product.Name}: {item.Quantity} одиниць");
            }

            Console.WriteLine("\nПродукти в категорії \"Напої\":");
            foreach (var product in products.Where(p => p.Category == "Напої"))
            {
                Console.WriteLine($"{product.Name} -- Цiна: {product.Price}");
            }
            // Виведення всіх накладних
            Console.WriteLine("\nВсi рахунки-фактури:");
            reporting.PrintAllInvoices();

            Console.WriteLine("\nНатиснiть Enter, щоб вийти...");
            Console.ReadLine();
        }
    }
}
