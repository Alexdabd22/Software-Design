using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyClassLibrary
{
    public class SmartTextChecker : ISmartTextReader
    {
        private ISmartTextReader reader;

        public SmartTextChecker(ISmartTextReader reader)
        {
            this.reader = reader ?? throw new ArgumentNullException(nameof(reader), "Reader cannot be null.");
        }

        public char[][] ReadFile()
        {
            Console.WriteLine("Opening file...");
            var content = reader.ReadFile();
            if (content == null)
            {
                Console.WriteLine("No content to process.");
                return null;
            }

            Console.WriteLine("File successfully read.");
            int lines = content.Length;
            int characters = 0;
            foreach (var line in content)
            {
                characters += line.Length;
            }

            Console.WriteLine($"Total lines: {lines}, Total characters: {characters}");
            Console.WriteLine("File closed.");

            return content;
        }
    }
}
