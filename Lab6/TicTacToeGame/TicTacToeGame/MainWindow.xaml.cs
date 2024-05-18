using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TicTacToeGame.ViewModels;


namespace TicTacToeGame
{
    public partial class MainWindow : Window
    {
        private GameViewModel gameViewModel;

        public MainWindow()
        {
            InitializeComponent();
            gameViewModel = new GameViewModel();
            DataContext = gameViewModel;

            InitializeGameBoard();
            gameViewModel.PropertyChanged += GameViewModel_PropertyChanged;
        }

        private void InitializeGameBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var button = new Button
                    {
                        Content = string.Empty,
                        FontSize = 32
                    };
                    button.Click += Button_Click;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    MainGrid.Children.Add(button);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content.ToString() == string.Empty)
            {
                button.Content = gameViewModel.CurrentPlayer == 1 ? "X" : "O";
                gameViewModel.MakeMove(Grid.GetRow(button), Grid.GetColumn(button));
                if (gameViewModel.CheckForWinner())
                {
                    MessageBox.Show($"Player {gameViewModel.CurrentPlayer} wins!");
                    InitializeGameBoard();
                }
            }
        }
        private void GameViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Winner")
            {
                MessageBox.Show($"Player {gameViewModel.CurrentPlayer} wins!");
                InitializeGameBoard();
            }
            else if (e.PropertyName == "Draw")
            {
                MessageBox.Show("The game is a draw!");
                InitializeGameBoard();
            }
        }

    }
}
