using System.Data;
using System.Windows;
using TicTacToeDataAccess;

namespace TicTacToeGame
{
    public partial class GameHistoryWindow : Window
    {
        private DatabaseManager _databaseManager;

        public GameHistoryWindow()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager("TicTacToeGame.db");
            LoadGameHistory();
        }

        private void LoadGameHistory()
        {
            var data = _databaseManager.ExecuteQuery("SELECT GameID, Player1ID, Player2ID, WinnerID, StartDate, EndDate, (strftime('%s', EndDate) - strftime('%s', StartDate)) AS Duration FROM Games ORDER BY StartDate DESC");
            GameHistoryListView.ItemsSource = data.DefaultView;
        }
    }
}
