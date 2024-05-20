using System;
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
            var data = _databaseManager.ExecuteQuery(
                "SELECT GameID, Player1ID, Player2ID, WinnerID, StartDate, EndDate, " +
                "(strftime('%s', EndDate) - strftime('%s', StartDate)) AS Duration " +
                "FROM Games ORDER BY StartDate DESC");

            // Create a new DataTable to store formatted data
            DataTable formattedData = data.Clone();
            formattedData.Columns["Duration"].DataType = typeof(string);

            foreach (DataRow row in data.Rows)
            {
                DataRow newRow = formattedData.NewRow();
                newRow.ItemArray = row.ItemArray;

                if (row["Duration"] != DBNull.Value && long.TryParse(row["Duration"].ToString(), out long duration))
                {
                    newRow["Duration"] = FormatDuration(duration);
                }
                else
                {
                    newRow["Duration"] = "N/A";
                }
                formattedData.Rows.Add(newRow);
            }

            GameHistoryListView.ItemsSource = formattedData.DefaultView;
        }

        private string FormatDuration(long duration)
        {
            int minutes = (int)(duration / 60);
            int seconds = (int)(duration % 60);
            return $"{minutes:D2}:{seconds:D2}";
        }
    }
}
