using System;
using ProxyClassLibrary;
using System.IO;
using System.Text.RegularExpressions;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"C:\Users\VINGA\Desktop\КПЗ\Lab3\Lab3\file04.txt";

            File.WriteAllText(filePath, "WriteAllText");

            ISmartTextReader reader = new SmartTextReader(filePath);

            ISmartTextReader checker = new SmartTextChecker(reader);

            Console.WriteLine("Reading file with SmartTextChecker:");
            char[][] chars = checker.ReadFile();
            if (chars != null)
            {
                foreach (var line in chars)
                {
                    Console.WriteLine(string.Join("", line));
                }
            }

            Console.WriteLine();

            string pattern = @".*\.txt$";
            ISmartTextReader locker = new SmartTextReaderLocker(reader, pattern);

            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            Console.WriteLine("Attempting to read file with SmartTextReaderLocker:");
            char[][] content = locker.ReadFile();
            if (content != null)
            {
                Console.WriteLine("Content of the file:");
                foreach (var line in content)
                {
                    Console.WriteLine(string.Join("", line));
                }
            }
            else
            {
                Console.WriteLine("Failed to read file.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

}
