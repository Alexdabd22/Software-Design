using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorClassLibrary
{
    public abstract class Hero
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public string Inventory { get; set; } = "Basic gear";

        public Hero(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
        }

        public virtual void DisplayStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Name}'s Stats: "); 
            Console.ResetColor(); 

            Console.WriteLine($"Health: {Health}, Attack: {Attack}");

            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine($"{Inventory}\n"); 
            Console.ResetColor(); 
        }
    }
}
