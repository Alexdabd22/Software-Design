using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription(string subscriberName, IReadOnlyCollection<string> channels)
            : base(subscriberName, 9.99m, 6, channels) { }
    }
}
