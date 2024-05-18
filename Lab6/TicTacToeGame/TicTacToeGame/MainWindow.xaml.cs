using System;
using System.Windows;


namespace TicTacToeGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayWithAI_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(true);
            gameWindow.Show();
            this.Close();
        }

        private void PlayWithFriend_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(false);
            gameWindow.Show();
            this.Close();
        }
    }
}
