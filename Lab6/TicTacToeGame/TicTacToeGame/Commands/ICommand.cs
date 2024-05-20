namespace TicTacToeGame.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}