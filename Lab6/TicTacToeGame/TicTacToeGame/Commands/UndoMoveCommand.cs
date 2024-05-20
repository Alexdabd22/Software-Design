using TicTacToeGame.ViewModels;

namespace TicTacToeGame.Commands
{
    public class UndoMoveCommand : ICommand
    {
        private readonly GameViewModel _gameViewModel;

        public UndoMoveCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }

        public void Execute()
        {
            _gameViewModel.Undo();
        }

        public void Undo()
        {
        }
    }
}
