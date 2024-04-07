
namespace DecoratorClassLibrary
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name, 150, 50) 
        {
            Inventory += ", Sword";
        }
    }
}
