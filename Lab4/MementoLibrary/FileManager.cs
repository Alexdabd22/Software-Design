using System;
using System.IO;

namespace MementoLibrary
{
    public class FileManager
    {
        private readonly string _filePath;
        private readonly TextEditor _editor;

        public FileManager(string filePath, TextEditor editor)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _editor = editor ?? throw new ArgumentNullException(nameof(editor));
        }

        public void CreateFile()
        {
            if (File.Exists(_filePath))
            {
                Console.WriteLine("Файл вже існує.");
                return;
            }

            File.Create(_filePath).Close();
            Console.WriteLine("Файл створено. Введіть початковий вміст файлу:");
            var initialContent = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(initialContent))
            {
                _editor.Write(initialContent);
                _editor.SaveToFile(_filePath);
            }
        }

        public void ShowFileContent()
        {
            Console.WriteLine("\nВміст файлу:");
            Console.WriteLine(_editor.GetContent());
        }

        public void EditFile()
        {
            ShowFileContent();
            _editor.EditContent();
            _editor.SaveToFile(_filePath);
        }

        public void DeleteFile()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
                Console.WriteLine("Файл успішно видалено.");
            }
            else
            {
                Console.WriteLine("Файл не існує.");
            }
        }

        public void ExitAndSave()
        {
            _editor.SaveToFile(_filePath);
            Console.WriteLine("Зміни збережено. Виходжу з програми.");
        }
    }
}

