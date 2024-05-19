using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TicTacToeGame.ViewModels;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class GameWindow : Window
    {
        private GameViewModel gameViewModel;
        private DispatcherTimer timer;
        private DateTime startTime;
        private DatabaseManager dbManager;

        public GameWindow(bool playWithAI, string username, int boardSize)
        {
            InitializeComponent();
            gameViewModel = new GameViewModel(boardSize) { PlayWithAI = playWithAI, Username = username };
            DataContext = gameViewModel;
            dbManager = new DatabaseManager("TicTacToeGame.db");
            InitializeGame();
            StartGameTimer();
        }

        private void InitializeGame()
        {
            MainGrid.Children.Clear(); // Очищення перед додаванням нових кнопок
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

        private void SaveGameResult(int winner)
        {
            int player1ID = 0;
            int player2ID = 0;

            if (!string.IsNullOrEmpty(gameViewModel.Username))
            {
                player1ID = dbManager.GetPlayerID(gameViewModel.Username);
                player2ID = gameViewModel.PlayWithAI ? 0 : 2; // Використання 2 як ID другого гравця у випадку гри проти іншого користувача.
            }

            int winnerID = winner == 0 ? 0 : (winner == 1 ? player1ID : player2ID);

            dbManager.InsertGameResult(player1ID, player2ID, winnerID, startTime, DateTime.Now);
        }

        private void StartGameTimer()
        {
            startTime = DateTime.Now;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void StopGameTimer()
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            TimerTextBlock.Text = $"Time: {elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
        }

        private void CloseGame()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

