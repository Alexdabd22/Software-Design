using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary1
{
    public interface IHeroBuilder
    {
        IHeroBuilder SetName(string name);
        IHeroBuilder SetHeight(double height);
        IHeroBuilder SetBuild(string build);
        IHeroBuilder SetHairColor(string hairColor);
        IHeroBuilder SetEyeColor(string eyeColor);
        IHeroBuilder AddToInventory(string item);
        IHeroBuilder AddToDeed(string deed);
        Hero Build();
    }
}
