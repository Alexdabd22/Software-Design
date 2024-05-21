using System;

namespace TicTacToeModels
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public Player(int playerID, string username, string email, string passwordHash, DateTime createdAt)
        {
            PlayerID = playerID;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
        }
    }
}
