using System;
using FactoryMethodLibrary3;
using FactoryMethodLibrary3.Factories;
using System.Globalization;


namespace FactoryMethod1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("1. Website");
                Console.WriteLine("2. Mobile App");
                Console.WriteLine("3. Manager Call");

                Console.Write("Choose subscription type: ");
                int choice = int.Parse(Console.ReadLine() ?? string.Empty);

                ISubscriptionFactory factory;
                switch (choice)
                {
                    case 1:
                        factory = new WebsiteFactory();
                        break;
                    case 2:
                        factory = new MobileAppFactory();
                        break;
                    case 3:
                        factory = new ManagerCallFactory();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid choice.");
                }

                Console.Write("Enter subscriber name: ");
                string subscriberName = Console.ReadLine();

                if (string.IsNullOrEmpty(subscriberName))
                {
                    throw new ArgumentException("Subscriber name cannot be empty.");
                }

                Subscription subscription = factory.CreateSubscription(subscriberName);

                Console.WriteLine("Subscription created successfully:");
                Console.WriteLine(subscription);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
