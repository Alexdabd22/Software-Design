using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterClassLibrary
{
    public class FileLoggerAdapter : ILogger
    {
        private readonly FileWriter _fileWriter;

        public FileLoggerAdapter(string filePath)
        {
            _fileWriter = new FileWriter(filePath);
        }

        public void Log(string message)
        {
            _fileWriter.WriteLine("[LOG] " + message);
        }

        public void Error(string message)
        {
            _fileWriter.WriteLine("[ERROR] " + message);
        }

        public void Warn(string message)
        {
            _fileWriter.WriteLine("[WARN] " + message);
        }
    }
}
