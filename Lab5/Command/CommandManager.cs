using System;
using System.Collections.Generic;


namespace Command
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _executedCommands = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _executedCommands.Push(command);
        }

        public void Undo()
        {
            if (_executedCommands.Count > 0)
            {
                var command = _executedCommands.Pop();
                command.Undo();
            }
        }
    }
}
