using System;
using System.IO;

namespace AdapterClassLibrary
{
    public class FileWriter
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }

}
