using FactoryMethodLibrary3.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3
{
    public class MobileAppFactory : ISubscriptionFactory
    {
        public Subscription CreateSubscription(string subscriberName)
        {
            var allChannels = new List<string>() { "Channel 4", "Channel 5", "Channel 6" };
            return new DomesticSubscription(subscriberName, allChannels);
        }
    }
}
