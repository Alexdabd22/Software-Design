using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary1
{
    public class HeroBuilder : IHeroBuilder
    {
        private Hero _hero = new Hero();

        public IHeroBuilder SetName(string name) { _hero.Name = name; return this; }
        public IHeroBuilder SetHeight(double height) { _hero.Height = height; return this; }
        public IHeroBuilder SetBuild(string build) { _hero.Build = build; return this; }
        public IHeroBuilder SetHairColor(string hairColor) { _hero.HairColor = hairColor; return this; }
        public IHeroBuilder SetEyeColor(string eyeColor) { _hero.EyeColor = eyeColor; return this; }
        public IHeroBuilder AddToInventory(string item) { _hero.AddToInventory(item); return this; }
        public IHeroBuilder AddToDeed(string deed) { _hero.AddToDeed(deed); return this; }
        public Hero Build() { return _hero; }
    }

}
