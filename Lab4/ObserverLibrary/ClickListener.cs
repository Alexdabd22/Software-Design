using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverLibrary
{
    public class ClickListener : IEventListener
    {
        public void HandleEvent(string eventType, LightNode source)
        {
            Console.WriteLine($"Clicked on element with tag: {((LightElementNode)source).Flyweight.TagName}");
        }
    }
}
