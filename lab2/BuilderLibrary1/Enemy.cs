using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary1
{
    public class Enemy
    {
        public string Name { get; set; }
        public string EyeColor { get; set; }
        public int AttackDamage { get; set; }
        public string Weapon { get; set; }
        public List<string> Inventory { get; private set; } = new List<string>();
        public List<string> Deeds { get; private set; } = new List<string>();

        public Enemy AddToInventory(string item)
        {
            Inventory.Add(item);
            return this;
        }

        public Enemy AddToDeed(string deed)
        {
            Deeds.Add(deed);
            return this;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Eye Color: {EyeColor}, Attack Damage: {AttackDamage}, Weapon: {Weapon}, " +
                   $"Inventory: [{string.Join(", ", Inventory)}], Deeds: [{string.Join(", ", Deeds)}]";
        }
    }
}
