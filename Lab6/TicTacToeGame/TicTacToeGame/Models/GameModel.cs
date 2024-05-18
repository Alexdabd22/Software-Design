using System;
using System.Collections.Generic;

namespace TicTacToeGame.Models
{
    public class GameModel
    {
        private static Random random = new Random();
        public int[,] Board { get; private set; } = new int[3, 3]; // 0 - empty, 1 - X, 2 - O

        public void MakeMove(int x, int y, int player)
        {
            if (player < 1 || player > 2)
            {
                throw new ArgumentException("Player must be 1 (X) or 2 (O).");
            }
            if (x < 0 || x > 2 || y < 0 || y > 2)
            {
                throw new ArgumentException("Invalid board position.");
            }
            if (Board[x, y] == 0)
            {
                Board[x, y] = player;
            }
            else
            {
                throw new InvalidOperationException("This position is already taken.");
            }
        }

        public bool CheckForWinner()
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if ((Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2] && Board[i, 0] != 0) ||
                    (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i] && Board[0, i] != 0))
                {
                    return true;
                }
            }
            // Check diagonals
            if ((Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != 0) ||
                (Board[2, 0] == Board[1, 1] && Board[1, 1] == Board[0, 2] && Board[2, 0] != 0))
            {
                return true;
            }
            return false;
        }

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
            return !CheckForWinner();
        }

        public void AiMakeMove()
        {
            // Збираємо всі порожні клітинки
            var emptyCells = new List<(int, int)>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == 0)
                    {
                        emptyCells.Add((i, j));
                    }
                }
            }

            // Вибираємо випадкову порожню клітинку для ходу AI
            if (emptyCells.Count > 0)
            {
                var (x, y) = emptyCells[random.Next(emptyCells.Count)];
                Board[x, y] = 2; // AI завжди ставить "O"
            }
        }

        public void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = 0;
                }
            }
        }
    }
}


