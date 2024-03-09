using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public class Dollar : Currency
    {
        public Dollar(int dollars, int cents) : base(dollars, cents) { }

        public override string GetCurrencySymbol()
        {
            return "$";
        }
    }

}
