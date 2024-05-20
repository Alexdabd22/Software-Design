using System;
using System.Windows.Threading;

namespace TicTacToeGame.Commands
{
    public class StopTimerCommand : ICommand
    {
        private readonly DispatcherTimer _timer;

        public StopTimerCommand(DispatcherTimer timer)
        {
            _timer = timer;
        }

        public void Execute()
        {
            _timer.Stop();
        }

        public void Undo()
        {
            _timer.Start();
        }
    }
}
