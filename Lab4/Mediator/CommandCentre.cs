using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    public class CommandCentre : IMediator
    {
        private List<Runway> runways;
        private Dictionary<Aircraft, Runway> aircraftRunwayMap = new Dictionary<Aircraft, Runway>();

        public CommandCentre(List<Runway> runways)
        {
            this.runways = runways ?? throw new ArgumentNullException(nameof(runways));
        }

        public void HandleLandingRequest(Aircraft aircraft)
        {
            var runway = runways.FirstOrDefault(r => !r.IsOccupied);
            if (runway != null)
            {
                runway.SetOccupied();
                aircraftRunwayMap[aircraft] = runway; 
                Console.WriteLine($"Aircraft {aircraft.Name} has landed on Runway {runway.Id}.");
            }
            else
            {
                Console.WriteLine("No available runway for landing.");
            }
        }

        public void HandleTakeOffRequest(Aircraft aircraft)
        {
            if (aircraftRunwayMap.TryGetValue(aircraft, out Runway runway) && runway.IsOccupied)
            {
                runway.SetFree();
                aircraftRunwayMap.Remove(aircraft);  
                Console.WriteLine($"Aircraft {aircraft.Name} has taken off from Runway {runway.Id}.");
            }
            else
            {
                Console.WriteLine("Aircraft is not on a correct runway or runway is not busy.");
            }
        }
    }
}
