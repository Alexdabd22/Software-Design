using System;
using System.Data;
using System.Data.SQLite;
using System.IO;


namespace TicTacToeDataAccess
{
    public class DatabaseManager
    {
        private string _databasePath;

        public DatabaseManager(string databasePath)
        {
            _databasePath = databasePath;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if(!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);
                CreateTables();
            }
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();

                // таблиця players
                var command = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Players (" +
                    "PlayerID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Username TEXT NOT NULL, " +
                    "Email TEXT UNIQUE, " +
                    "PasswordHash TEXT, " +
                    "CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP)", connection);
                command.ExecuteNonQuery();

                // таблиця games 
                command.CommandText =
                    "CREATE TABLE IF NOT EXISTS Games (" +
                    "GameID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Player1ID INTEGER, " +
                    "Player2ID INTEGER, " +
                    "WinnerID INTEGER, " +
                    "StartDate DATETIME DEFAULT CURRENT_TIMESTAMP, " +
                    "EndDate DATETIME, " +
                    "FOREIGN KEY (Player1ID) REFERENCES Players(PlayerID), " +
                    "FOREIGN KEY (Player2ID) REFERENCES Players(PlayerID), " +
                    "FOREIGN KEY (WinnerID) REFERENCES Players(PlayerID))";
                command.ExecuteNonQuery();
                // таблиця moves
                command.CommandText =
                    "CREATE TABLE IF NOT EXISTS Moves (" +
                    "MoveID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "GameID INTEGER, " +
                    "PlayerID INTEGER, " +
                    "Position INTEGER, " +
                    "MoveTime DATETIME DEFAULT CURRENT_TIMESTAMP, " +
                    "FOREIGN KEY (GameID) REFERENCES Games(GameID), " +
                    "FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID))";
                command.ExecuteNonQuery();
            }
        }

        public void InsertPlayers(string username,string email, string passwordHash)
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "INSERT INTO Players (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                command.ExecuteNonQuery();
            }
        }

        public DataTable ExecuteQuery(string sql)
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand(sql, connection);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
