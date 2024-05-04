using System;
using System.Collections.Generic;

namespace Command
{
    public class CommandManager
    {
        private readonly Stack<ICommand> executedCommands = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            executedCommands.Push(command);
        }

        public void UndoLastCommand()
        {
            if (executedCommands.Count > 0)
            {
                var command = executedCommands.Pop();
                command.Undo();
            }
        }
    }
}
