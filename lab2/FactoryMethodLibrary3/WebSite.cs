using FactoryMethodLibrary3.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3
{
    public class WebsiteFactory : ISubscriptionFactory
    {
        public Subscription CreateSubscription(string subscriberName)
        {
            var allChannels = new List<string>() { "Channel 1", "Channel 2", "Channel 3" };
            return new EducationalSubscription(subscriberName, allChannels);
        }
    }
}
