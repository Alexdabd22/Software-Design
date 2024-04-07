using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorClassLibrary
{
    public abstract class HeroDecorator : Hero
    {
        protected Hero hero;

        public HeroDecorator(Hero hero) : base(hero.Name, hero.Health, hero.Attack)
        {
            this.hero = hero;
        }

        public override void DisplayStats()
        {
            hero.DisplayStats(); 
        }
    }
}
