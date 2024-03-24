using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary1
{
    public class Hero
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public List<string> Inventory { get; private set; } = new List<string>();
        public List<string> Deeds { get; private set; } = new List<string>();

        public Hero AddToInventory(string item)
        {
            Inventory.Add(item);
            return this;
        }

        public Hero AddToDeed(string deed)
        {
            Deeds.Add(deed);
            return this;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Height: {Height}, Build: {Build}, Hair Color: {HairColor}, Eye Color: {EyeColor}, " +
                   $"Inventory: [{string.Join(", ", Inventory)}], Deeds: [{string.Join(", ", Deeds)}]";
        }
    }
}
