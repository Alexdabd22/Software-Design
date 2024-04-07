using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorClassLibrary
{
    public class Sword : HeroDecorator
    {
        public Sword(Hero hero) : base(hero)
        {
            hero.Inventory += ", Sword";
        }
    }
}
