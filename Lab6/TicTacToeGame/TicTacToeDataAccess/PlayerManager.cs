using System;
using System.Data;
using System.Data.SQLite;
using TicTacToeDataAccess;
using TicTacToeModels;

namespace TicTacToeGame.DataAccess
{
    public class PlayerManager
    {
        private readonly SQLiteConnection _connection;

        public PlayerManager()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public void InsertPlayer(Player player)
        {
            using (var command = new SQLiteCommand(
                "INSERT INTO Players (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)",
                DatabaseConnection.Instance.GetConnection()))
            {
                command.Parameters.AddWithValue("@Username", player.Username);
                command.Parameters.AddWithValue("@Email", player.Email);
                command.Parameters.AddWithValue("@PasswordHash", player.PasswordHash);
                command.ExecuteNonQuery();
            }
        }

        public Player GetPlayerByEmailAndPassword(string email, string passwordHash)
        {
            using (var command = new SQLiteCommand(
                "SELECT * FROM Players WHERE Email = @Email AND PasswordHash = @PasswordHash",
                DatabaseConnection.Instance.GetConnection()))
            {
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
            using (var command = new SQLiteCommand(
                "SELECT PlayerID FROM Players WHERE Username = @Username",
                DatabaseConnection.Instance.GetConnection()))
            {
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
            using (var command = new SQLiteCommand(
                "DELETE FROM Players WHERE Username = @Username",
                DatabaseConnection.Instance.GetConnection()))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.ExecuteNonQuery();
            }
        }
    }
}
