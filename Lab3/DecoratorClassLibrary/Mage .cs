
namespace DecoratorClassLibrary
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name, 100, 70) 
        {
            Inventory += ", Magic Staff";
        }
    }
}
