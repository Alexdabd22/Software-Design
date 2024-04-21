using System;
using System.Collections.Generic;
using System.Text;
using MementoLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string filePath = "document.txt";
        TextDocument document = new TextDocument();
        TextEditor editor = new TextEditor(document);
        FileManager fileManager = new FileManager(filePath, editor);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n1. Створити файл");
            Console.WriteLine("2. Подивитися вміст файлу");
            Console.WriteLine("3. Редагувати файл");
            Console.WriteLine("4. Видалити файл");
            Console.WriteLine("5. Вихід і збереження");
            Console.WriteLine("6. Вихід без збереження");
            Console.Write("Оберіть опцію: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    fileManager.CreateFile();
                    break;
                case "2":
                    fileManager.ShowFileContent();
                    break;
                case "3":
                    fileManager.EditFile();
                    break;
                case "4":
                    fileManager.DeleteFile();
                    break;
                case "5":
                    fileManager.ExitAndSave();
                    exit = true;
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("Виходжу з програми без збереження змін.");
                    break;
                default:
                    Console.WriteLine("Невідома опція.");
                    break;
            }
        }
    }
}