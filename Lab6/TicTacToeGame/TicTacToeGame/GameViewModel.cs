using System;
using System.Collections.Generic;
using System.ComponentModel;
using TicTacToeGame.Models;

namespace TicTacToeGame.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // 1 - X, 2 - O
        public int CurrentPlayer { get; private set; } = 1; 
        private GameModel gameModel = new GameModel();

        public void MakeMove(int x, int y)
        {
            if (gameModel.Board[x, y] == 0) // Тільки якщо клітинка вільна
            {
                gameModel.MakeMove(x, y, CurrentPlayer);
                if (gameModel.CheckForWinner())
                {
                    OnPropertyChanged("Winner");
                }
                else if (gameModel.IsDraw())
                {
                    OnPropertyChanged("Draw");
                }
                // Змінити гравця
                CurrentPlayer = 3 - CurrentPlayer;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public bool CheckForWinner()
        {
            // Перевірка на переможця в gameModel
            return gameModel.CheckForWinner();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}