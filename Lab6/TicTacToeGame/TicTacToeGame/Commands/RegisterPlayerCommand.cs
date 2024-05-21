using TicTacToeModels;
using TicTacToeGame.DataAccess;

namespace TicTacToeGame.Commands
{
    public class RegisterPlayerCommand : ICommand
    {
        private readonly PlayerManager _playerManager;
        private readonly Player _player;

        public RegisterPlayerCommand(PlayerManager playerManager, Player player)
        {
            _playerManager = playerManager;
            _player = player;
        }

        public void Execute()
        {
            _playerManager.InsertPlayer(_player);
        }

        public void Undo()
        {
            _playerManager.DeletePlayer(_player.Username);
        }
    }
}
