using System;
using System.Collections.Generic;
using ObserverLibrary;


namespace Console3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var flyweightDiv = new LightElementFlyweight("div", "block");
            var div = new LightElementNode(flyweightDiv);
            var flyweightButton = new LightElementFlyweight("button", "inline");
            var button = new LightElementNode(flyweightButton, false, new List<string> { "btn", "btn-primary" });

            button.AddChild(new LightTextNode("Click me!"));

            
            div.AddEventListener("click", new ClickListener());
            button.AddEventListener("mouseover", new MouseOverListener());

            
            div.AddChild(button);

            
            Console.WriteLine("Simulating events on 'div' and 'button':");

            Console.WriteLine("\nTriggering 'click' event on 'div':");
            div.TriggerEvent("click"); 

            Console.WriteLine("\nTriggering 'mouseover' event on 'button':");
            button.TriggerEvent("mouseover"); 

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
