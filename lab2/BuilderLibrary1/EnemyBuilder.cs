using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary1
{
    public class EnemyBuilder : IEnemyBuilder
    {
        private Enemy _enemy = new Enemy();

        public IEnemyBuilder SetName(string name) { _enemy.Name = name; return this; }
        public IEnemyBuilder SetEyeColor(string eyeColor) { _enemy.EyeColor = eyeColor; return this; }
        public IEnemyBuilder SetAttackDamage(int attackDamage) { _enemy.AttackDamage = attackDamage; return this; }
        public IEnemyBuilder SetWeapon(string weapon) { _enemy.Weapon = weapon; return this; }
        public IEnemyBuilder AddToInventory(string item) { _enemy.AddToInventory(item); return this; }
        public IEnemyBuilder AddToDeed(string deed) { _enemy.AddToDeed(deed); return this; }
        public Enemy Build() { return _enemy; }
    }

}
