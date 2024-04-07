using System;
using System.IO;

namespace ProxyClassLibrary
{
    public class SmartTextReader : ISmartTextReader
    {
        private string filePath;

        public SmartTextReader(string filePath)
        {
            this.filePath = filePath;
        }

        public char[][] ReadFile()
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                char[][] result = new char[lines.Length][];

                for (int i = 0; i < lines.Length; i++)
                {
                    result[i] = lines[i].ToCharArray();
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return null;
            }
        }
    }
}
