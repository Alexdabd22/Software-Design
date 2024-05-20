using System;
using System.Windows.Threading;

namespace TicTacToeGame.Commands
{
    public class PauseGameCommand : ICommand
    {
        private readonly DispatcherTimer _timer;
        private readonly Action _onPaused;

        public PauseGameCommand(DispatcherTimer timer, Action onPaused)
        {
            _timer = timer;
            _onPaused = onPaused;
        }

        public void Execute()
        {
            _timer.Stop();
            _onPaused();
        }

        public void Undo()
        {
            _timer.Start();
        }
    }
}
