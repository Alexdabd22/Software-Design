using System.Windows.Threading;

namespace TicTacToeGame.Commands
{
    public class StartGameTimerCommand : ICommand
    {
        private readonly DispatcherTimer _timer;

        public StartGameTimerCommand(DispatcherTimer timer)
        {
            _timer = timer;
        }

        public void Execute()
        {
            _timer.Start();
        }

        public void Undo()
        {
            _timer.Stop();
        }
    }
}
