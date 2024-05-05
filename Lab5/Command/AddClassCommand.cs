using System;
using Composer;


namespace Command
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _class;

        public AddClassCommand(LightElementNode element, string cssClass)
        {
            _element = element;
            _class = cssClass;
        }

        public void Execute()
        {
            _element.AddClass(_class);
        }

        public void Undo()
        {
            _element.RemoveClass(_class);
        }
    }
}
