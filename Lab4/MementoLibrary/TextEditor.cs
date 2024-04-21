using System;
using System.Collections.Generic;
using System.Linq;

namespace MementoLibrary
{
    public class TextEditor
    {
        private readonly TextDocument _document;
        private readonly Stack<TextDocumentMemento> _history = new Stack<TextDocumentMemento>();

        public TextEditor(TextDocument document)
        {
            _document = document ?? throw new ArgumentNullException(nameof(document));
        }

        public string GetContent()
        {
            return string.Join(Environment.NewLine, _document.Content);
        }
        public void Write(string text)
        {
            _history.Push(_document.CreateMemento());
            _document.Content.Add(text);
        }

        public void Undo()
        {
            if (_history.Any())
            {
                _document.Restore(_history.Pop());
            }
        }

        public void EditContent()
        {
            Console.WriteLine("Поточний вміст файлу:");
            Console.WriteLine(_document);

            Console.WriteLine("\nВведіть новий вміст файлу (введіть 'cancel' для скасування):");
            string newText = Console.ReadLine();

            if (newText.ToLower() != "cancel")
            {
                _document.Content.Clear();
                _document.Content.Add(newText);
                Console.WriteLine("Вміст файлу оновлено.");
            }
            else
            {
                Undo();
                Console.WriteLine("Зміни скасовано.");
            }
        }

        public void SaveToFile(string filePath)
        {
            System.IO.File.WriteAllText(filePath, _document.ToString());
            Console.WriteLine("Документ збережено до файла " + filePath);
        }

        public void ReadFromFile(string filePath)
        {
            string fileContent = System.IO.File.ReadAllText(filePath);
            string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            _document.Content = new List<string>(lines);
        }
    }
}
