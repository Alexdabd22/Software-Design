using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3.Factories
{
    public interface ISubscriptionFactory
    {
        Subscription CreateSubscription(string subscriberName);
    }
}

