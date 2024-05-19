using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class RegistrationWindow : Window
    {
        private DatabaseManager _databaseManager;

        public RegistrationWindow()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager("TicTacToeGame.db");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string passwordHash = ComputeSha256Hash(PasswordBox.Password);

            _databaseManager.InsertPlayer(username, email, passwordHash);
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

