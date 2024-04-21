using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLibrary
{
    public class MouseOverListener : IEventListener
    {
        public void HandleEvent(string eventType, LightNode source)
        {
            Console.WriteLine($"Mouse over element with tag: {((LightElementNode)source).Flyweight.TagName}");
        }
    }
}
