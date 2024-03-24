using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription(string subscriberName, IReadOnlyCollection<string> channels)
            : base(subscriberName, 29.99m, 12, channels) { }
    }
}
