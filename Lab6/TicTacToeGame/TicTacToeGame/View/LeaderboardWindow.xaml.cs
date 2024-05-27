using System.Data;
using System.Windows;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class LeaderboardWindow : Window
    {
        private GameManager _gameManager;

        public LeaderboardWindow()
        {
            InitializeComponent();
            _gameManager = new GameManager();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            LeaderboardListView.ItemsSource = _gameManager.GetLeaderboard().DefaultView;
        }
    }
}
