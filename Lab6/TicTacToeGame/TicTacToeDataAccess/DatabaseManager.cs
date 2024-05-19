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
            if (!File.Exists(_databasePath))
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

                var command = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Players (" +
                    "PlayerID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Username TEXT NOT NULL, " +
                    "Email TEXT UNIQUE, " +
                    "PasswordHash TEXT, " +
                    "CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP)", connection);
                command.ExecuteNonQuery();

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

        public void InsertPlayer(string username, string email, string passwordHash)
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

        public bool VerifyUser(string email, string passwordHash, out string username)
        {
            username = string.Empty;

            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "SELECT Username FROM Players WHERE Email = @Email AND PasswordHash = @PasswordHash", connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        username = reader["Username"].ToString();
                        return true;
                    }
                }
            }

            return false;
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



