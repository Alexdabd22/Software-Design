using System;
using System.Data;
using System.Windows;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class GameHistoryWindow : Window
    {
        private GameManager _gameManager;

        public GameHistoryWindow()
        {
            InitializeComponent();
            _gameManager = new GameManager();
            LoadGameHistory();
        }

        private void LoadGameHistory()
        {
            GameHistoryListView.ItemsSource = _gameManager.GetGameHistory().DefaultView;
        }
    }
}

