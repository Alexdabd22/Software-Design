using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TicTacToeGame.ViewModels;
using TicTacToeDataAccess;
using System.Windows.Input;
using System.ComponentModel;
using TicTacToeGame.Commands;

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
            gameViewModel.PropertyChanged += GameViewModel_PropertyChanged;
            dbManager = new DatabaseManager("TicTacToeGame.db");
            InitializeGame();
            StartGameTimer();
            this.PreviewKeyDown += Window_PreviewKeyDown;
        }

        private void GameViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BoardUpdated")
            {
                UpdateUiForBoard();
            }
            else if (e.PropertyName == "Winner" || e.PropertyName == "Draw")
            {
                StopGameTimer();
                string message = e.PropertyName == "Winner" ? $"Player {gameViewModel.CurrentPlayer} wins!" : "The game is a draw!";
                MessageBox.Show(message);
                SaveGameResult(e.PropertyName == "Winner" ? gameViewModel.CurrentPlayer : 0);
                CloseGame();
            }
            else if (e.PropertyName == "AiMoved")
            {
                UpdateUiForBoard();
            }
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
            }

            if (gameViewModel.PlayWithAI && gameViewModel.CurrentPlayer == 2)
            {
                Dispatcher.InvokeAsync(() =>
                {
                    gameViewModel.PerformAiMove();
                });
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

        private void ExecuteCommand(TicTacToeGame.Commands.ICommand command)
        {
            command.Execute();
        }

        private void ExecuteCommandWithAction(TicTacToeGame.Commands.ICommand command, Action action)
        {
            command.Execute();
            action?.Invoke();
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
                ExecuteCommandWithAction(pauseCommand, null);
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
                ExecuteCommandWithAction(resumeCommand, null);
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
            var startTimerCommand = new StartGameTimerCommand(timer);
            ExecuteCommand(startTimerCommand);
            gameStartTime = DateTime.Now;
            totalPausedTime = TimeSpan.Zero;
        }

        private void StopGameTimer()
        {
            var stopTimerCommand = new StopTimerCommand(timer);
            ExecuteCommand(stopTimerCommand);
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
            ExecuteCommand(undoMoveCommand);
            UpdateUiForBoard();
        }
    }
}
