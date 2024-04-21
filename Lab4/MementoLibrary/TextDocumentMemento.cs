using System.Collections.Generic;

namespace MementoLibrary
{
    public class TextDocumentMemento
    {
        public List<string> Content { get; private set; }

        public TextDocumentMemento(List<string> content)
        {
            Content = content;
        }
    }
}
