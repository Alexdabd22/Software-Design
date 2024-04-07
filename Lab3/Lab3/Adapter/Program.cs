using System;
using AdapterClassLibrary;
using System.IO;

namespace Program
{
    internal class Program
    {
        static readonly string LogMessage = "This is a log message!";
        static readonly string ErrorMessage = "This is an error message!";
        static readonly string WarnMessage = "This is a warn message!";

        static readonly string FilePath = "log.txt"; 

        static void Main(string[] args)
        {
            Console.WriteLine("Console logger:");
            ILogger logger = new Logger();
            logger.Log(LogMessage);
            logger.Error(ErrorMessage);
            logger.Warn(WarnMessage);

            Console.WriteLine("\nFileWriter:");
            var fileWriter = new FileWriter(FilePath);
            fileWriter.WriteLine(LogMessage);
            fileWriter.WriteLine(ErrorMessage); 
            fileWriter.WriteLine(WarnMessage);

            Console.WriteLine("\nFile content after logging:");
            ReadLogFile(FilePath);

            Console.WriteLine("\nFileLoggerAdapter:");
            ILogger fileLogger = new FileLoggerAdapter(FilePath);
            fileLogger.Log(LogMessage);
            fileLogger.Error(ErrorMessage);
            fileLogger.Warn(WarnMessage);

            Console.WriteLine("\nFile content after using FileLoggerAdapter:");
            ReadLogFile(FilePath);

            Console.WriteLine("\nPress '0' to delete the log file, or any other key to exit...");
            if (Console.ReadKey().KeyChar == '0')
            {
                DeleteLogFile(FilePath);
            }
        }

        static void ReadLogFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string fileText = File.ReadAllText(filePath);
                Console.WriteLine(fileText);
            }
            else
            {
                Console.WriteLine("Log file not found.");
            }
        }

        static void DeleteLogFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("\nLog file deleted.");
            }
            else
            {
                Console.WriteLine("\nLog file not found.");
            }
        }
    }
}