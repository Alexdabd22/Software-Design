using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TicTacToeGame.ViewModels;
using TicTacToeDataAccess;
using System.Windows.Input;

namespace TicTacToeGame
{
    public partial class GameWindow : Window
    {
        private GameViewModel gameViewModel;
        private DispatcherTimer timer;
        private DateTime gameStartTime;
        private TimeSpan totalPausedTime;
        private DateTime pauseStartTime;
        private DatabaseManager dbManager;
        private bool isPaused = false;

        public GameWindow(bool playWithAI, string username, int boardSize)
        {
            InitializeComponent();
            gameViewModel = new GameViewModel(boardSize) { PlayWithAI = playWithAI, Username = username };
            DataContext = gameViewModel;
            dbManager = new DatabaseManager("TicTacToeGame.db");
            InitializeGame();
            StartGameTimer();
            this.PreviewKeyDown += Window_PreviewKeyDown;
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
                StopGameTimer();
                MessageBox.Show($"Player {gameViewModel.CurrentPlayer} wins!");
                SaveGameResult(gameViewModel.CurrentPlayer);
                CloseGame();
            }
            else if (gameViewModel.IsDraw())
            {
                StopGameTimer();
                MessageBox.Show("The game is a draw!");
                SaveGameResult(0); // 0 означає нічия
                CloseGame();
            }
        }

        private void PauseGame()
        {
            if (!isPaused)
            {
                timer.Stop();
                pauseStartTime = DateTime.Now;
                isPaused = true;
                MessageBox.Show("Game is paused. Press Enter to resume.");
            }
        }

        private void ResumeGame()
        {
            if (isPaused)
            {
                totalPausedTime += DateTime.Now - pauseStartTime;
                timer.Start();
                isPaused = false;
                this.Focus(); // Знову встановлюємо фокус на вікні гри
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && !isPaused)
            {
                PauseGame();
            }
            else if (e.Key == Key.Enter && isPaused)
            {
                ResumeGame();
            }
        }

        private void SaveGameResult(int winner)
        {
            int player1ID = 0;
            int player2ID = 0;

            if (!string.IsNullOrEmpty(gameViewModel.Username))
            {
                player1ID = dbManager.GetPlayerID(gameViewModel.Username);
                player2ID = gameViewModel.PlayWithAI ? 0 : 2;
            }

            int winnerID = winner == 0 ? 0 : (winner == 1 ? player1ID : player2ID);

            dbManager.InsertGameResult(player1ID, player2ID, winnerID, gameStartTime, DateTime.Now);
        }

        private void StartGameTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            gameStartTime = DateTime.Now;
            totalPausedTime = TimeSpan.Zero;
            timer.Start();
        }

        private void StopGameTimer()
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                var timeSinceStart = DateTime.Now - gameStartTime - totalPausedTime;
                TimerTextBlock.Text = $"Time: {timeSinceStart.Minutes:D2}:{timeSinceStart.Seconds:D2}";
            }
        }

        private void CloseGame()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
