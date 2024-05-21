using TicTacToeGame.ViewModels;

namespace TicTacToeGame.Strategy
{
    public class PlayerVsAIStrategy : IGameStrategy
    {
        public void CheckGameState(GameViewModel gameViewModel)
        {
            if (gameViewModel.CheckForWinner())
            {
                gameViewModel.OnPropertyChanged("Winner");
                gameViewModel.Notify("Winner");
            }
            else if (gameViewModel.IsDraw())
            {
                gameViewModel.OnPropertyChanged("Draw");
                gameViewModel.Notify("Draw");
            }
            else
            {
                gameViewModel.ChangePlayer();
                if (gameViewModel.CurrentPlayer == 2)
                {
                    gameViewModel.PerformAiMove();
                }
            }
        }
    }
}

