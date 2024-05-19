using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class LoginWindow : Window
    {
        private DatabaseManager _databaseManager;
        public string LoggedInUsername { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager("TicTacToeGame.db");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string passwordHash = ComputeSha256Hash(PasswordBox.Password);

            if (_databaseManager.VerifyUser(email, passwordHash, out string username))
            {
                LoggedInUsername = username;
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


