using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TicTacToeGame.ViewModels;
using TicTacToeGame.DataAccess;
using System.Windows.Input;
using TicTacToeGame.Commands;
using TicTacToeGame.Observer;
using TicTacToeGame.Strategy;
using TicTacToeModels;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class GameWindow : Window, IObserver
    {
        private GameViewModel gameViewModel;
        private DispatcherTimer timer;
        private DateTime gameStartTime;
        private TimeSpan totalPausedTime;
        private DateTime pauseStartTime;
        private DatabaseManager dbManager;
        private PlayerManager playerManager;
        private bool isPaused = false;

        public GameWindow(bool playWithAI, string username, int boardSize, DatabaseManager dbManager, PlayerManager playerManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.playerManager = playerManager;
            gameViewModel = new GameViewModel(boardSize) { PlayWithAI = playWithAI, Username = username };
            DataContext = gameViewModel;
            gameViewModel.Attach(this);

            if (playWithAI)
            {
                gameViewModel.SetGameStrategy(new PlayerVsAIStrategy());
            }
            else
            {
                gameViewModel.SetGameStrategy(new PlayerVsPlayerStrategy());
            }

            InitializeGame();
            StartGameTimer();
            this.PreviewKeyDown += Window_PreviewKeyDown;
        }

        public void SetPlayerUsername(string username)
        {
            gameViewModel.Username = username;
        }

        public void Update(string propertyName)
        {
            switch (propertyName)
            {
                case "BoardUpdated":
                case "AiMoved":
                    UpdateUiForBoard();
                    break;
                case "Winner":
                    HandleGameEnd($"Player {gameViewModel.CurrentPlayer} wins!", gameViewModel.CurrentPlayer);
                    break;
                case "Draw":
                    HandleGameEnd("The game is a draw!", 0);
                    break;
            }
        }

        private void HandleGameEnd(string message, int winner)
        {
            StopGameTimer();
            MessageBox.Show(message);
            SaveGameResult(winner);
            CloseGame();
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
                    var button = CreateGameButton(i, j);
                    MainGrid.Children.Add(button);
                }
            }
        }
        private Button CreateGameButton(int row, int column)
        {
            var button = new Button
            {
                FontSize = 32,
                Content = string.Empty
            };
            button.Click += Button_Click;
            Grid.SetRow(button, row);
            Grid.SetColumn(button, column);
            return button;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button) || button.Content.ToString() != string.Empty)
                return;

            if (!gameViewModel.PlayWithAI || gameViewModel.CurrentPlayer == 1)
            {
                button.Content = gameViewModel.CurrentPlayer == 1 ? "X" : "O";
                gameViewModel.MakeMove(Grid.GetRow(button), Grid.GetColumn(button));
            }
            else if (gameViewModel.CurrentPlayer == 2)
            {
                Dispatcher.InvokeAsync(() => gameViewModel.PerformAiMove());
            }
        }
        private void UpdateUiForBoard()
        {
            for (int i = 0; i < gameViewModel.BoardSize; i++)
            {
                for (int j = 0; j < gameViewModel.BoardSize; j++)
                {
                    var button = MainGrid.Children
                        .Cast<Button>()
                        .FirstOrDefault(b => Grid.GetRow(b) == i && Grid.GetColumn(b) == j);

                    if (button != null)
                    {
                        int cellStatus = gameViewModel.GetCellStatus(i, j);
                        button.Content = cellStatus == 1 ? "X" : cellStatus == 2 ? "O" : string.Empty;
                    }
                }
            }
        }

        private void PauseGame()
        {
            if (!isPaused)
            {
                var pauseCommand = new PauseGameCommand(timer, () =>
                {
                    pauseStartTime = DateTime.Now;
                    isPaused = true;
                    MessageBox.Show("Game is paused. Press Enter to resume.");
                });
                pauseCommand.Execute();
            }
        }

        private void ResumeGame()
        {
            if (isPaused)
            {
                var resumeCommand = new ResumeGameCommand(timer, () =>
                {
                    totalPausedTime += DateTime.Now - pauseStartTime;
                    isPaused = false;
                    this.Focus();
                });
                resumeCommand.Execute();
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
                player1ID = playerManager.GetPlayerID(gameViewModel.Username);
                player2ID = gameViewModel.PlayWithAI ? 2 : 2;
            }

            int winnerID = winner == 0 ? 0 : (winner == 1 ? player1ID : player2ID);

            dbManager.InsertGameResult(player1ID, player2ID, winnerID, gameStartTime, DateTime.Now);
        }

        private void StartGameTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            var startTimerCommand = new StartGameTimerCommand(timer);
            startTimerCommand.Execute();
            gameStartTime = DateTime.Now;
            totalPausedTime = TimeSpan.Zero;
        }

        private void StopGameTimer()
        {
            var stopTimerCommand = new StopTimerCommand(timer);
            stopTimerCommand.Execute();
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

        private void UndoMove_Click(object sender, RoutedEventArgs e)
        {
            var undoMoveCommand = new UndoMoveCommand(gameViewModel);
            undoMoveCommand.Execute();
            UpdateUiForBoard();
        }
    }
}
