using TicTacToeGame.ViewModels;

namespace TicTacToeGame.Strategy
{
    public interface IGameStrategy
    {
        void CheckGameState(GameViewModel gameViewModel);
    }
}
