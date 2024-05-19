using System;
using System.Windows;
using TicTacToeDataAccess;
using System.IO;

namespace TicTacToeGame
{
    public partial class MainWindow : Window
    {
        private const string DatabaseFileName = "TicTacToeGame.db";
        private DatabaseManager dbManager;
        private string loggedInUsername;

        public MainWindow()
        {
            InitializeComponent();
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseFileName);
            dbManager = new DatabaseManager(dbPath);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                loggedInUsername = loginWindow.LoggedInUsername;
                WelcomeTextBlock.Text = $"Welcome, {loggedInUsername}!";
            }
        }

        private void PlayWithAI_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(true, loggedInUsername);
            gameWindow.Show();
            this.Close();
        }

        private void PlayWithFriend_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(false, loggedInUsername);
            gameWindow.Show();
            this.Close();
        }
    }
}


