using TicTacToeGame.ViewModels;

namespace TicTacToeGame.Commands
{
    public class MakeMoveCommand : ICommand
    {
        private readonly GameViewModel _gameViewModel;
        private readonly int _row;
        private readonly int _column;
        private readonly int _player;
        private int _previousValue;

        public MakeMoveCommand(GameViewModel gameViewModel, int row, int column, int player)
        {
            _gameViewModel = gameViewModel;
            _row = row;
            _column = column;
            _player = player;
        }

        public void Execute()
        {
            _previousValue = _gameViewModel.GetCellStatus(_row, _column);
            _gameViewModel.MakeMoveInternal(_row, _column, _player);
        }

        public void Undo()
        {
            _gameViewModel.UndoMove(_row, _column, _previousValue);
        }
    }
}





