using TicTacToeDataAccess;

namespace TicTacToeGame.Commands
{
    public class RegisterPlayerCommand : ICommand
    {
        private readonly DatabaseManager _databaseManager;
        private readonly string _username;
        private readonly string _email;
        private readonly string _passwordHash;

        public RegisterPlayerCommand(DatabaseManager databaseManager, string username, string email, string passwordHash)
        {
            _databaseManager = databaseManager;
            _username = username;
            _email = email;
            _passwordHash = passwordHash;
        }

        public void Execute()
        {
            _databaseManager.InsertPlayer(_username, _email, _passwordHash);
        }

        public void Undo()
        {

        }
    }
}
