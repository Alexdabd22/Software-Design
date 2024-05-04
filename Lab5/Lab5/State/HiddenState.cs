using System;

namespace State
{
    public class HiddenState : ILightNodeState
    {
        public void Show(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is now visible.");
            node.State = new VisibleState();
        }

        public void Hide(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is already hidden.");
        }

        public void Select(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} cannot be selected because it's hidden.");
        }

        public void Deselect(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is not selected.");
        }
    }
}
