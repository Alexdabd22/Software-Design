using System;
using System.Text.RegularExpressions;


namespace ProxyClassLibrary
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private ISmartTextReader reader;
        private Regex pattern;

        public SmartTextReaderLocker(ISmartTextReader reader, string pattern)
        {
            this.reader = reader;
            this.pattern = new Regex(pattern);
        }

        public char[][] ReadFile()
        {
            if (!pattern.IsMatch(reader.GetType().ToString()))
            {
                Console.WriteLine("Access denied!");
                return null;
            }

            return reader.ReadFile();
        }
    }
}
