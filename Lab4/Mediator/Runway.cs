using System;

namespace Mediator
{
    public class Runway
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool IsOccupied { get; private set; }  

        public void SetOccupied()
        {
            IsOccupied = true;
            Console.WriteLine($"Runway {Id} is now occupied.");
        }

        public void SetFree()
        {
            IsOccupied = false;
            Console.WriteLine($"Runway {Id} is now free.");
        }
    }
}
