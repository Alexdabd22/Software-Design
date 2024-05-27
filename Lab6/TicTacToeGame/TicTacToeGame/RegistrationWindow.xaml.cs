using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using TicTacToeGame.DataAccess;
using TicTacToeModels;
using TicTacToeGame.Commands;

namespace TicTacToeGame
{
    public partial class RegistrationWindow : Window
    {
        private PlayerManager _playerManager;

        public RegistrationWindow()
        {
            InitializeComponent();
            _playerManager = new PlayerManager();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string passwordHash = ComputeSha256Hash(PasswordBox.Password);

            var player = new Player(0, username, email, passwordHash, DateTime.Now);
            var command = new RegisterPlayerCommand(_playerManager, player);
            command.Execute();

            MessageBox.Show("Registration successful!");
            this.Close();
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



