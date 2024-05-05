using System;
using CommonLibrary;


namespace State
{
    public class HiddenState : ILightNodeState
    {
        public void Show(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} показано.");
            node.State = new VisibleState();
        }

        public void Hide(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} уже приховано.");
        }
    }
}
