using Composer;
using System;

namespace Command
{
    public class ChangeTextCommand : ICommand
    {
        private readonly LightTextNode _textNode;
        private readonly string _newText;
        private string _previousText;

        public ChangeTextCommand(LightTextNode textNode, string newText)
        {
            _textNode = textNode;
            _newText = newText;
        }

        public void Execute()
        {
            _previousText = _textNode.Text;
            _textNode.SetText(_newText);
        }

        public void Undo()
        {
            _textNode.SetText(_previousText);
        }
    }
}
