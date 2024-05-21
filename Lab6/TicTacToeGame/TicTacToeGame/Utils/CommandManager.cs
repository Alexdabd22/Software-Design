using System.Collections.Generic;
using TicTacToeGame.Commands;

namespace TicTacToeGame.Utils
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _commandHistory;

        public CommandManager()
        {
            _commandHistory = new Stack<ICommand>();
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void Undo()
        {
            if (_commandHistory.Count > 0)
            {
                var command = _commandHistory.Pop();
                command.Undo();
            }
        }

        public void ClearHistory()
        {
            _commandHistory.Clear();
        }
    }
}

