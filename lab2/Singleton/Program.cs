using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SingletonLibrary;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Single thread:");
                Authenticator authenticator1 = Authenticator.Instance;
                Authenticator authenticator2 = Authenticator.Instance;

                Console.WriteLine($"authenticator1 == authenticator2: {ReferenceEquals(authenticator1, authenticator2)}");
                Console.WriteLine($"Hash code of authenticator1: {authenticator1.GetHashCode()}");
                Console.WriteLine($"Hash code of authenticator2: {authenticator2.GetHashCode()}");

                Console.WriteLine("\nMultithread:");

                Thread thread1 = new Thread(() =>
                {
                    Authenticator authenticator3 = Authenticator.Instance;
                    Console.WriteLine($"Hash code of authenticator3 in Thread 1: {authenticator3.GetHashCode()}");
                });

                Thread thread2 = new Thread(() =>
                {
                    Authenticator authenticator4 = Authenticator.Instance;
                    Console.WriteLine($"Hash code of authenticator4 in Thread 2: {authenticator4.GetHashCode()}");
                });

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

