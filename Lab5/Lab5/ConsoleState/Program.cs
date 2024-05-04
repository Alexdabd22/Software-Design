using System;
using System.Linq;
using Composer;  
using State;    

namespace ConsoleState
{
    class Program
    {
        static void Main(string[] args)
        {
            Composer.LightElementNode element = new Composer.LightElementNode(new Composer.LightElementFlyweight("div"));

            element.Show();
            Console.WriteLine("Element is visible.");

            element.Hide();
            Console.WriteLine("Element is hidden.");

            element.Select();
            Console.WriteLine("Element is selected.");

            element.Deselect();
            Console.WriteLine("Element is deselected.");

            Console.ReadLine();
        }
    }
}

