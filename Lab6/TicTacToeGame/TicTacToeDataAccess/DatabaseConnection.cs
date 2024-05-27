using System;
using System.Data.SQLite;
using System.IO;


namespace TicTacToeDataAccess
{
    public sealed class DatabaseConnection
    {
        private static readonly object lockObj = new object();
        private static DatabaseConnection _instance;
        private SQLiteConnection connection;

        private DatabaseConnection()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TicTacToeGame.db");
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
            connection.Open();
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                    return _instance;
                }
            }
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }
    }

}
