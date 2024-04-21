using System;


namespace Mediator
{
    public class Aircraft
    {
        public string Name { get; }
        public bool IsTakingOff { get; set; }  

        public Aircraft(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void RequestLanding(IMediator mediator)
        {
            Console.WriteLine($"Aircraft {Name} is requesting to land.");
            mediator.HandleLandingRequest(this);
        }

        public void RequestTakeOff(IMediator mediator)
        {
            Console.WriteLine($"Aircraft {Name} is requesting to take off.");
            mediator.HandleTakeOffRequest(this);
        }
    }
}
