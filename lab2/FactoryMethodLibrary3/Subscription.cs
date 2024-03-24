using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodLibrary3
{
    public abstract class Subscription
    {
        public string SubscriberName { get; }
        public decimal MonthlyFee { get; }
        public int MinimumSubscriptionPeriod { get; }
        public IReadOnlyCollection<string> IncludedChannels { get; }

        protected Subscription(string subscriberName, decimal monthlyFee, int minimumPeriod, IReadOnlyCollection<string> channels)
        {
            if (string.IsNullOrEmpty(subscriberName)) throw new ArgumentException("Subscriber name cannot be null or empty");
            if (monthlyFee < 0) throw new ArgumentOutOfRangeException(nameof(monthlyFee), "Monthly fee must be non-negative");
            if (minimumPeriod < 1) throw new ArgumentOutOfRangeException(nameof(minimumPeriod), "Minimum period must be at least 1");
            if (channels == null || channels.Count == 0) throw new ArgumentException("Channels cannot be null or empty");

            SubscriberName = subscriberName;
            MonthlyFee = monthlyFee;
            MinimumSubscriptionPeriod = minimumPeriod;
            IncludedChannels = new List<string>(channels);
        }

        public override string ToString()
        {
            return $"Subscription for {SubscriberName}: {MonthlyFee:0.00}, Subscriber name: {SubscriberName}, Minimum subscription period: {MinimumSubscriptionPeriod}\n\tIncluded channels: [{string.Join(", ", IncludedChannels)}]";
        }

    }
}
