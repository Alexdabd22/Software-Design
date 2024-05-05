using CommonLibrary;
using System;


namespace State
{
    public class VisibleState : ILightNodeState
    {
        public void Show(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} уже видимий.");
        }

        public void Hide(LightNode node)
        {
            Console.WriteLine($"{node.GetType().Name} приховано.");
            node.State = new HiddenState();
        }
    }
}
