using FactoryMethodLibrary3.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3
{
    public class ManagerCallFactory : ISubscriptionFactory
    {
        public Subscription CreateSubscription(string subscriberName)
        {
            var allChannels = new List<string>() { "Premium Channel 1", "Premium Channel 2" };
            return new PremiumSubscription(subscriberName, allChannels);
        }
    }
}
