using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public class Euro : Currency
    {
        public Euro(int euros, int cents) : base(euros, cents) { }

        public override string GetCurrencySymbol()
        {
            return "€";
        }
    }

}
