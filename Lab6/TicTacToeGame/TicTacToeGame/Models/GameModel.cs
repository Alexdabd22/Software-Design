namespace TicTacToeGame.Models
{
    public class GameModel
    {
        public int[,] Board { get; private set; } = new int[3, 3]; // 0 - empty, 1 - X, 2 - O

        public void MakeMove(int x, int y, int player)
        {
            if (Board[x, y] == 0) // Якщо клітинка вільна
            {
                Board[x, y] = player;
            }
        }

        public bool CheckForWinner()
        {
            // Перевірка горизонталей і вертикалей
            for (int i = 0; i < 3; i++)
            {
                if ((Board[i, 0] != 0 && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2]) ||
                    (Board[0, i] != 0 && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i]))
                {
                    return true;
                }
            }

            // Перевірка діагоналей
            if ((Board[0, 0] != 0 && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2]) ||
                (Board[0, 2] != 0 && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0]))
            {
                return true;
            }

            return false;
        }
        // Жодної порожньої клітинки не знайдено, тому нічия
        public bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == 0) 
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
    }
}
