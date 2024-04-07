using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorClassLibrary
{
    public class MagicRing : HeroDecorator
    {
        public MagicRing(Hero hero) : base(hero)
        {
            hero.Inventory += ", Magic Ring";
        }
    }
}
