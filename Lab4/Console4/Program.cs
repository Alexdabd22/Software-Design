using System.Threading.Tasks;
using System;
using CustomImage = StrategyLibrary.Image;

class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Створення та завантаження зображення з локальної файлової системи
                string localImagePath = @"C:\Users\VINGA\Desktop\КПЗ\Tree.jpeg"; 
                var localImage = new CustomImage(localImagePath);
                await localImage.LoadImageAsync();
                Console.WriteLine("Local image loaded successfully.");

                // Створення та завантаження зображення з мережі
                string networkImageUrl = "https://buffer.com/library/content/images/2023/09/instagram-image-size.jpg"; 
                var networkImage = new CustomImage(networkImageUrl);
                await networkImage.LoadImageAsync();
                Console.WriteLine("Network image loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }