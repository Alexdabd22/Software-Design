using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorClassLibrary
{
    public class Armor : HeroDecorator
    {
        public Armor(Hero hero) : base(hero)
        {
            hero.Inventory += ", Armor";
        }
    }
}
