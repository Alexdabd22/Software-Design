using System;
using System.Data;

namespace TicTacToeDataAccess
{
    public class GameManager
    {
        private readonly DatabaseManager _databaseManager;

        public GameManager()
        {
            _databaseManager = new DatabaseManager();
        }

        public DataTable GetGameHistory()
        {
            var data = _databaseManager.ExecuteQuery(
                "SELECT GameID, Player1ID, Player2ID, WinnerID, StartDate, EndDate, " +
                "(strftime('%s', EndDate) - strftime('%s', StartDate)) AS Duration " +
                "FROM Games ORDER BY StartDate DESC");

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

            string FormatDuration(long duration)
            {
                // Форматування тривалості у вигляді рядка
                TimeSpan timeSpan = TimeSpan.FromSeconds(duration);
                return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }

            return formattedData;
        }

        public DataTable GetLeaderboard()
        {
            var data = _databaseManager.ExecuteQuery(
                "SELECT PlayerID, Username, COUNT(*) AS GamesWon " +
                "FROM Players INNER JOIN Games ON Players.PlayerID = Games.WinnerID " +
                "GROUP BY PlayerID, Username " +
                "ORDER BY GamesWon DESC");
            return data;
        }  
    }
}
