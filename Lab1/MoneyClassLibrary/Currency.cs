using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public abstract class Currency
    {
        public int MajorUnit { get; protected set; }
        public int MinorUnit { get; protected set; }

        protected Currency(int majorUnit, int minorUnit)
        {
            if (majorUnit < 0 || minorUnit < 0)
            {
                throw new ArgumentException("Значення для MajorUnit і MinorUnit(копійок) не можуть бути від’ємними.");
            }
            if (minorUnit >= 100)
            {
                throw new ArgumentException("MinorUnit має бути менше 100.");
            }

            MajorUnit = majorUnit;
            MinorUnit = minorUnit;
        }

        public abstract string GetCurrencySymbol();

        public void SetAmount(int majorUnit, int minorUnit)
        {
            MajorUnit = majorUnit;
            MinorUnit = minorUnit;
        }

        public override string ToString()
        {
            return $"{GetCurrencySymbol()}{MajorUnit}.{MinorUnit:D2}";
        }
    }


}
