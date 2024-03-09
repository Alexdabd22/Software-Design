using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public class Money
    {
        public Currency Currency { get; private set; }

        public Money(Currency currency)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency), "Валюта не може бути нульовою.");
        }

        public override string ToString()
        {
            return Currency.ToString();
        }
    }


}
