using ChainOfResponsibilityLibrary;
using System;


namespace Console1
{
     class Program
     {
        static void Main()
        {
            SupportHandler basic = new BasicSupportHandler();
            SupportHandler intermediate = new IntermediateSupportHandler();
            SupportHandler advanced = new AdvancedSupportHandler();
            SupportHandler ultimate = new UltimateSupportHandler();

            basic.SetSuccessor(intermediate);
            intermediate.SetSuccessor(advanced);
            advanced.SetSuccessor(ultimate);

            do
            {
                Console.WriteLine("Please enter the level of support needed (1-Basic, 2-Intermediate, 3-Advanced, 4-Ultimate): ");
                int level;
                if (!int.TryParse(Console.ReadLine(), out level) || level < 1 || level > 4)
                {
                    Console.WriteLine("Invalid level input. Please enter a number between 1 and 4.");
                    continue;
                }

                UserRequest request = new UserRequest { Level = level };
                basic.HandleRequest(request);

                Console.WriteLine("\nPress 'n' to exit or any other key to continue...");
            } while (Console.ReadKey().Key != ConsoleKey.N);

            Console.WriteLine("\nProgram has exited. Press any key to close.");
            Console.ReadKey();
        }
     }
}
