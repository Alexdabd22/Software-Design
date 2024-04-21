using System;
using System.Collections.Generic;
using Mediator;

namespace Console2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var runway1 = new Runway();
            var runway2 = new Runway();
            List<Runway> runways = new List<Runway> { runway1, runway2 };

            var aircraft1 = new Aircraft("Plane1");
            var aircraft2 = new Aircraft("Plane2");
            var aircraft3 = new Aircraft("Plane3");
            List<Aircraft> aircrafts = new List<Aircraft> { aircraft1, aircraft2, aircraft3 };

            var commandCentre = new CommandCentre(runways);

            Console.WriteLine("Land and takeoff:");
            commandCentre.HandleLandingRequest(aircraft1);
            commandCentre.HandleTakeOffRequest(aircraft1);

            Console.WriteLine("\nAttempting to take off without landing:");
            commandCentre.HandleTakeOffRequest(aircraft2);

            Console.WriteLine("\nLand and takeoff:");
            commandCentre.HandleLandingRequest(aircraft2);
            commandCentre.HandleTakeOffRequest(aircraft2);

            Console.WriteLine("\nAttempting to land when no runways are available:");
            commandCentre.HandleLandingRequest(aircraft3);

            Console.WriteLine("\nLanding another aircraft after one takes off:");
            commandCentre.HandleTakeOffRequest(aircraft2);
            commandCentre.HandleLandingRequest(aircraft3);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
