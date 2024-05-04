using System;

namespace State
{
    public class VisibleState : ILightNodeState
    {
        public void Show(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is already visible.");
        }

        public void Hide(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is now hidden.");
            node.State = new HiddenState();
        }

        public void Select(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is now selected.");
            node.State = new SelectedState();
        }

        public void Deselect(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is not selected.");
        }
    }
}
