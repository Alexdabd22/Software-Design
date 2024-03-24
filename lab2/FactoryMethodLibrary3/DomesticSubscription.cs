using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3
{
    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription(string subscriberName, IReadOnlyCollection<string> channels)
            : base(subscriberName, 14.99m, 1, channels) { }
    }
}
