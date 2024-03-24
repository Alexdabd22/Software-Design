using System;
using BuilderLibrary1;

namespace BuilderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Director director = new Director();

                IHeroBuilder heroBuilder = new HeroBuilder();
                IEnemyBuilder enemyBuilder = new EnemyBuilder();

                Hero hero = director.BuildHero(heroBuilder);
                Enemy enemy = director.BuildEnemy(enemyBuilder);

                Console.WriteLine("Hero Created:");
                Console.WriteLine(hero);
                Console.WriteLine("\nEnemy Created:");
                Console.WriteLine(enemy);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
