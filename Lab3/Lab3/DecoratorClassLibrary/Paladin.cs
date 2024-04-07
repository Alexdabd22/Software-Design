
namespace DecoratorClassLibrary
{
    public class Paladin : Hero
    {
        public Paladin(string name) : base(name, 120, 60) 
        {
            Inventory += ", Hammer";
        }
    }
}
