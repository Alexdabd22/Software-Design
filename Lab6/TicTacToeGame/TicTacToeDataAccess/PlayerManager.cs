using System;
using System.Data;
using System.Data.SQLite;
using TicTacToeModels;

namespace TicTacToeGame.DataAccess
{
    public class PlayerManager
    {
        private readonly string _databasePath;

        public PlayerManager(string databasePath)
        {
            _databasePath = databasePath;
        }

        public void InsertPlayer(Player player)
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "INSERT INTO Players (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)", connection);
                command.Parameters.AddWithValue("@Username", player.Username);
                command.Parameters.AddWithValue("@Email", player.Email);
                command.Parameters.AddWithValue("@PasswordHash", player.PasswordHash);
                command.ExecuteNonQuery();
            }
        }

        public Player GetPlayerByEmailAndPassword(string email, string passwordHash)
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "SELECT * FROM Players WHERE Email = @Email AND PasswordHash = @PasswordHash", connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Player(
                            Convert.ToInt32(reader["PlayerID"]),
                            reader["Username"].ToString(),
                            reader["Email"].ToString(),
                            reader["PasswordHash"].ToString(),
                            Convert.ToDateTime(reader["CreatedAt"])
                        );
                    }
                }
            }

            return null;
        }

        public int GetPlayerID(string username)
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "SELECT PlayerID FROM Players WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["PlayerID"]);
                    }
                    else
                    {
                        throw new Exception("Player not found");
                    }
                }
            }
        }

        public void DeletePlayer(string username)
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Players WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.ExecuteNonQuery();
            }
        }
    }
}
