using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoLibrary
{
    public class TextDocument
    {
        public List<string> Content { get; set; }


        public TextDocument()
        {
            Content = new List<string>();
        }

        public TextDocumentMemento CreateMemento()
        {
            return new TextDocumentMemento(new List<string>(Content));
        }

        public void Restore(TextDocumentMemento memento)
        {
            Content = new List<string>(memento.Content);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Content);
        }
    }
}
