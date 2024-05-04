using System;

namespace State
{
    public class SelectedState : ILightNodeState
    {
        public void Show(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is already visible and selected.");
        }

        public void Hide(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is now hidden and deselected.");
            node.State = new HiddenState();
        }

        public void Select(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is already selected.");
        }

        public void Deselect(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} is now deselected.");
            node.State = new VisibleState();
        }
    }
}
