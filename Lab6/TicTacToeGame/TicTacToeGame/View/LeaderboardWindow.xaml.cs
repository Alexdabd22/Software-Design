using System.Data;
using System.Windows;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class LeaderboardWindow : Window
    {
        private DatabaseManager _databaseManager;

        public LeaderboardWindow(DatabaseManager databaseManager)
        {
            InitializeComponent();
            _databaseManager = databaseManager;
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            var data = _databaseManager.ExecuteQuery(
                "SELECT PlayerID, Username, COUNT(*) AS GamesWon " +
                "FROM Players INNER JOIN Games ON Players.PlayerID = Games.WinnerID " +
                "GROUP BY PlayerID, Username " +
                "ORDER BY GamesWon DESC");
            LeaderboardListView.ItemsSource = data.DefaultView;
        }
    }
}
