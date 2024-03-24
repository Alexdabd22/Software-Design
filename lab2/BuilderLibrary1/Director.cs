using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary1
{
    public class Director
    {
        public Hero BuildHero(IHeroBuilder builder)
        {
            return builder.SetName("Arthur")
                          .SetHeight(1.8)
                          .SetBuild("Athletic")
                          .SetHairColor("Blond")
                          .SetEyeColor("Blue")
                          .AddToInventory("Sword")
                          .AddToInventory("Shield")
                          .AddToDeed("Saved the village")
                          .Build();
        }

        public Enemy BuildEnemy(IEnemyBuilder builder)
        {
            return builder.SetName("Zorgon")
                          .SetEyeColor("Red")
                          .SetAttackDamage(50)
                          .SetWeapon("Fire Staff")
                          .AddToInventory("Magic Potion")
                          .AddToDeed("Invaded the northern lands")
                          .Build();
        }
    }
}
