using System;
using System.Windows.Threading;

namespace TicTacToeGame.Commands
{
    public class ResumeGameCommand : ICommand
    {
        private readonly DispatcherTimer _timer;
        private readonly Action _onResumed;

        public ResumeGameCommand(DispatcherTimer timer, Action onResumed)
        {
            _timer = timer;
            _onResumed = onResumed;
        }

        public void Execute()
        {
            _timer.Start();
            _onResumed();
        }

        public void Undo()
        {
            _timer.Stop();
        }
    }
}
