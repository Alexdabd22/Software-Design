using System;
using PrototypeLibrary;

class Program
{
    static void Main(string[] args)
    {
        
        Virus parent = new Virus("ParentVirus", "Flu", 1.0, 10);

        
        parent.Children.Add(new Virus("ChildVirus1", "Flu", 0.8, 5));
        parent.Children.Add(new Virus("ChildVirus2", "Flu", 0.9, 6));

        
        parent.Children[0].Children.Add(new Virus("GrandchildVirus1", "Flu", 0.5, 2));
        parent.Children[0].Children.Add(new Virus("GrandchildVirus2", "Flu", 0.4, 3));

        
        Virus clonedParent = parent.Clone();

        // Демонстрація, що клонування було успішним
        Console.WriteLine("Original Parent: " + parent.Name);
        PrintChildren(parent, 1);

        Console.WriteLine("\nCloned Parent: " + clonedParent.Name);
        PrintChildren(clonedParent, 1);
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void PrintChildren(Virus virus, int level)
    {
        foreach (Virus child in virus.Children)
        {
            Console.WriteLine(new String('-', level * 2) + "> " + child.Name);
            PrintChildren(child, level + 1);
        }
    }

}