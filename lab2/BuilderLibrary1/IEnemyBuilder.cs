using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary1
{
    public interface IEnemyBuilder
    {
        IEnemyBuilder SetName(string name);
        IEnemyBuilder SetEyeColor(string eyeColor);
        IEnemyBuilder SetAttackDamage(int attackDamage);
        IEnemyBuilder SetWeapon(string weapon);
        IEnemyBuilder AddToInventory(string item);
        IEnemyBuilder AddToDeed(string deed);
        Enemy Build();
    }

}
