using System.ComponentModel;
using TicTacToeGame.Commands;
using TicTacToeGame.Models;
using TicTacToeGame.Observer;
using TicTacToeGame.Strategy;
using TicTacToeGame.Utils;

namespace TicTacToeGame.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged, ISubject
    {
        private IGameStrategy _gameStrategy;
        private GameModel gameModel;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool PlayWithAI { get; set; }
        public int CurrentPlayer { get; private set; } = 1;
        public int BoardSize { get; set; }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        private readonly CommandManager _commandManager;
        private readonly Subject _subject;

        public GameViewModel(int boardSize)
        {
            BoardSize = boardSize;
            gameModel = new GameModel(BoardSize);
            _commandManager = new CommandManager();
            _subject = new Subject();
        }

        public void SetGameStrategy(IGameStrategy gameStrategy)
        {
            _gameStrategy = gameStrategy;
        }

        public int GetCellStatus(int row, int column)
        {
            return gameModel.Board[row, column];
        }

        public void MakeMove(int row, int column)
        {
            var command = new MakeMoveCommand(this, row, column, CurrentPlayer);
            _commandManager.ExecuteCommand(command);
            CheckGameState();
        }

        public void MakeMoveInternal(int row, int column, int player)
        {
            gameModel.MakeMove(row, column, player);
            OnPropertyChanged("BoardUpdated");
            Notify("BoardUpdated");
        }

        public void UndoMove(int row, int column, int previousValue)
        {
            gameModel.UndoMove(row, column, previousValue);
            OnPropertyChanged("BoardUpdated");
            Notify("BoardUpdated");
        }

        public void Undo()
        {
            _commandManager.Undo();
            CheckGameState();
        }

        public void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
            OnPropertyChanged("PlayerChanged");
            Notify("PlayerChanged");
        }

        public void PerformAiMove()
        {
            gameModel.AiMakeMove();
            OnPropertyChanged("AiMoved");
            Notify("AiMoved");
            CheckGameState();
        }

        public bool IsDraw()
        {
            return gameModel.IsDraw();
        }

        public bool CheckForWinner()
        {
            return gameModel.CheckForWinner();
        }

        private void CheckGameState()
        {
            _gameStrategy.CheckGameState(this);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetGame()
        {
            gameModel = new GameModel(BoardSize);
            CurrentPlayer = 1;
            _commandManager.ClearHistory();
            OnPropertyChanged("Reset");
            Notify("Reset");
        }

        public void Attach(IObserver observer)
        {
            _subject.Attach(observer);
        }

        public void Detach(IObserver observer)
        {
            _subject.Detach(observer);
        }

        public void Notify(string propertyName)
        {
            _subject.Notify(propertyName);
        }
    }
}







