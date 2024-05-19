using System.ComponentModel;
using TicTacToeGame.Models;

namespace TicTacToeGame.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private GameModel gameModel = new GameModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public bool PlayWithAI { get; set; }
        public int CurrentPlayer { get; private set; } = 1;

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

        public int GetCellStatus(int row, int column)
        {
            return gameModel.Board[row, column];
        }

        public void MakeMove(int row, int column)
        {
            if (gameModel.Board[row, column] == 0)
            {
                gameModel.MakeMove(row, column, CurrentPlayer);
                OnPropertyChanged("BoardUpdated");

                if (gameModel.CheckForWinner())
                {
                    OnPropertyChanged("Winner");
                }
                else if (gameModel.IsDraw())
                {
                    OnPropertyChanged("Draw");
                }
                else
                {
                    ChangePlayer();
                }
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
        }

        public bool IsDraw()
        {
            return gameModel.IsDraw();
        }

        public bool CheckForWinner()
        {
            return gameModel.CheckForWinner();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ResetGame()
        {
            gameModel = new GameModel();
            CurrentPlayer = 1;
            OnPropertyChanged("Reset");
        }
    }
}
