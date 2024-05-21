using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using TicTacToeGame.DataAccess;
using TicTacToeGame.Models;

namespace TicTacToeGame
{
    public partial class LoginWindow : Window
    {
        private PlayerManager _playerManager;
        public string LoggedInUsername { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
            _playerManager = new PlayerManager("TicTacToeGame.db");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string passwordHash = ComputeSha256Hash(PasswordBox.Password);

            var player = _playerManager.GetPlayerByEmailAndPassword(email, passwordHash);
            if (player != null)
            {
                LoggedInUsername = player.Username;
                MessageBox.Show("Login successful!");
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

