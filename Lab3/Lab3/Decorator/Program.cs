using DecoratorClassLibrary;
using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Hero warrior = new Warrior("Conan");
            Hero mage = new Mage("Merlin");
            Hero paladin = new Paladin("Arthur");

            
            Console.WriteLine("Initial stats:");
            warrior.DisplayStats();
            mage.DisplayStats();
            paladin.DisplayStats();

            
            Console.WriteLine("\nEquipping inventory:");
            warrior = new Sword(new Armor(warrior)); 
            mage = new MagicRing(mage); 
            paladin = new Sword(new MagicRing(new Armor(paladin))); 

            Console.WriteLine("\nUpdated stats with inventory:");
            warrior.DisplayStats();
            mage.DisplayStats();
            paladin.DisplayStats();


            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
