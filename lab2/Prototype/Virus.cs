using System.Collections.Generic;

namespace PrototypeLibrary
{
    public class Virus : IPrototype<Virus>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(string name, string type, double weight, int age)
        {
            Name = name;
            Type = type;
            Weight = weight;
            Age = age;
            Children = new List<Virus>();
        }

        public Virus Clone()
        {
            Virus clone = (Virus)this.MemberwiseClone();
            clone.Children = new List<Virus>(this.Children.Count);
            foreach (Virus child in this.Children)
            {
                clone.Children.Add(child.Clone());
            }
            return clone;
        }
    }
}
