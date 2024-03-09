using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClassLibrary
{
    public class Product
    {
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public string Category { get; private set; }

        public Product(string name, Money price, string category = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Назва продукту не може бути нулем або пробілом.", nameof(name));
            }

            Name = name;
            Price = price ?? throw new ArgumentNullException(nameof(price), "Ціна не може бути нульовою.");
            Category = category; 
        }

        public void ReducePrice(int amountInMinorUnit)
        {
            if (amountInMinorUnit < 0)
            {
                throw new ArgumentException("Сума для зменшення не може бути від’ємною.", nameof(amountInMinorUnit));
            }

            int totalMinorUnits = Price.Currency.MajorUnit * 100 + Price.Currency.MinorUnit - amountInMinorUnit;
            if (totalMinorUnits < 0)
            {
                throw new InvalidOperationException("Ціна не може стати від'ємною після зниження.");
            }

            Price.Currency.SetAmount(totalMinorUnits / 100, totalMinorUnits % 100);
        }
    }


}
