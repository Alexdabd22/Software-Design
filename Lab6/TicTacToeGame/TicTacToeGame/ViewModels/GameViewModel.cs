using System.Collections.Generic;
using System.ComponentModel;
using TicTacToeGame.Commands;
using TicTacToeGame.Models;

namespace TicTacToeGame.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
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

        private readonly Stack<ICommand> _commandHistory;

        public GameViewModel(int boardSize)
        {
            BoardSize = boardSize;
            gameModel = new GameModel(BoardSize);
            _commandHistory = new Stack<ICommand>();
        }

        public int GetCellStatus(int row, int column)
        {
            return gameModel.Board[row, column];
        }

        public void MakeMove(int row, int column)
        {
            var command = new MakeMoveCommand(this, row, column, CurrentPlayer);
            command.Execute();
            _commandHistory.Push(command);
            CheckGameState();
        }

        public void MakeMoveInternal(int row, int column, int player)
        {
            gameModel.MakeMove(row, column, player);
            OnPropertyChanged("BoardUpdated");
        }

        public void UndoMove(int row, int column, int previousValue)
        {
            gameModel.UndoMove(row, column, previousValue);
            OnPropertyChanged("BoardUpdated");
        }

        public void Undo()
        {
            if (_commandHistory.Count > 0)
            {
                var command = _commandHistory.Pop();
                command.Undo();
                CheckGameState();
            }
        }

        public void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
            OnPropertyChanged("PlayerChanged");
        }

        public void PerformAiMove()
        {
            gameModel.AiMakeMove();
            OnPropertyChanged("AiMoved");
            ChangePlayer();
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
            if (CheckForWinner())
            {
                OnPropertyChanged("Winner");
            }
            else if (IsDraw())
            {
                OnPropertyChanged("Draw");
            }
            else
            {
                ChangePlayer();
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetGame()
        {
            gameModel = new GameModel(BoardSize);
            CurrentPlayer = 1;
            _commandHistory.Clear();
            OnPropertyChanged("Reset");
        }
    }
}




