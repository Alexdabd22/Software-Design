using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicTacToeGame.ViewModels;

namespace TicTacToeGame
{
    public partial class GameWindow : Window
    {
        private GameViewModel gameViewModel;

        public GameWindow(bool playWithAI, string username, int boardSize)
        {
            InitializeComponent();
            gameViewModel = new GameViewModel(boardSize) { PlayWithAI = playWithAI, Username = username };
            DataContext = gameViewModel;
            InitializeGame();
        }

        private void InitializeGame()
        {
            MainGrid.Children.Clear();
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < gameViewModel.BoardSize; i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition());
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < gameViewModel.BoardSize; i++)
            {
                for (int j = 0; j < gameViewModel.BoardSize; j++)
                {
                    Button button = new Button
                    {
                        FontSize = 32,
                        Content = string.Empty
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
            if (button == null || button.Content.ToString() != string.Empty)
                return;

            if (!gameViewModel.PlayWithAI || gameViewModel.CurrentPlayer == 1)
            {
                button.Content = gameViewModel.CurrentPlayer == 1 ? "X" : "O";
                gameViewModel.MakeMove(Grid.GetRow(button), Grid.GetColumn(button));
                CheckGameState();
            }

            if (gameViewModel.PlayWithAI && gameViewModel.CurrentPlayer == 2)
            {
                Dispatcher.InvokeAsync(() =>
                {
                    gameViewModel.PerformAiMove();
                    UpdateUiForAiMove();
                    CheckGameState();
                });
            }
        }

        private void UpdateUiForAiMove()
        {
            for (int i = 0; i < gameViewModel.BoardSize; i++)
            {
                for (int j = 0; j < gameViewModel.BoardSize; j++)
                {
                    var button = MainGrid.Children
                        .Cast<Button>()
                        .FirstOrDefault(b => Grid.GetRow(b) == i && Grid.GetColumn(b) == j);

                    if (button != null && gameViewModel.GetCellStatus(i, j) == 2)
                    {
                        button.Content = "O";
                    }
                }
            }
        }

        private void CheckGameState()
        {
            if (gameViewModel.CheckForWinner())
            {
                MessageBox.Show($"Player {gameViewModel.CurrentPlayer} wins!");
                ResetGame();
            }
            else if (gameViewModel.IsDraw())
            {
                MessageBox.Show("The game is a draw!");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            foreach (Button btn in MainGrid.Children)
            {
                btn.Content = string.Empty;
            }
            gameViewModel.ResetGame();
        }
    }
}




