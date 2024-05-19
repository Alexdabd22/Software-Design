using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicTacToeGame.ViewModels;

namespace TicTacToeGame
{
    public partial class GameWindow : Window
    {
        private GameViewModel gameViewModel;

        public GameWindow(bool playWithAI, string username)
        {
            InitializeComponent();
            gameViewModel = new GameViewModel { PlayWithAI = playWithAI, Username = username };
            DataContext = gameViewModel;
            InitializeGame();
        }

        private void InitializeGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
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

            // Check if it's player vs player
            if (!gameViewModel.PlayWithAI)
            {
                // Alternate turns between X and O
                button.Content = gameViewModel.CurrentPlayer == 1 ? "X" : "O";
                gameViewModel.MakeMove(Grid.GetRow(button), Grid.GetColumn(button));
                CheckGameState();
            }
            else
            {
                // If it's player vs AI, ensure only player can place "X"
                if (gameViewModel.CurrentPlayer == 1)
                {
                    button.Content = "X";
                    gameViewModel.MakeMove(Grid.GetRow(button), Grid.GetColumn(button));
                    CheckGameState();

                    // Perform AI move if AI mode is active and it's AI's turn
                    if (!gameViewModel.CheckForWinner() && !gameViewModel.IsDraw() && gameViewModel.CurrentPlayer == 2)
                    {
                        Dispatcher.InvokeAsync(() =>
                        {
                            gameViewModel.PerformAiMove();  // AI makes its move
                            UpdateUiForAiMove();  // Update the UI after AI move
                            CheckGameState();  // Check game state after AI move
                        });
                    }
                }
            }
        }

        private void UpdateUiForAiMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
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
