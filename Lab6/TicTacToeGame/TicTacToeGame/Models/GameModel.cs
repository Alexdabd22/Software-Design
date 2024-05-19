using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeGame.Models
{
    public class GameModel
    {
        public int[,] Board { get; private set; }
        public int BoardSize { get; private set; }

        public GameModel(int boardSize)
        {
            BoardSize = boardSize;
            Board = new int[BoardSize, BoardSize];
        }

        public void MakeMove(int x, int y, int player)
        {
            if (x < 0 || x >= BoardSize || y < 0 || y >= BoardSize)
                throw new ArgumentOutOfRangeException("Move is out of board bounds.");

            if (Board[x, y] == 0)
            {
                Board[x, y] = player;
            }
        }

        public bool CheckForWinner()
        {
            // Check rows and columns
            for (int i = 0; i < BoardSize; i++)
            {
                if (Enumerable.Range(0, BoardSize).All(j => Board[i, j] == Board[i, 0] && Board[i, 0] != 0) ||
                    Enumerable.Range(0, BoardSize).All(j => Board[j, i] == Board[0, i] && Board[0, i] != 0))
                {
                    return true;
                }
            }

            // Check diagonals
            if (Enumerable.Range(0, BoardSize).All(i => Board[i, i] == Board[0, 0] && Board[0, 0] != 0) ||
                Enumerable.Range(0, BoardSize).All(i => Board[i, BoardSize - 1 - i] == Board[0, BoardSize - 1] && Board[0, BoardSize - 1] != 0))
            {
                return true;
            }

            return false;
        }

        public bool IsDraw()
        {
            return Board.Cast<int>().All(cell => cell != 0);
        }

        public void AiMakeMove()
        {
            var random = new Random();
            var emptyCells = new List<(int, int)>();

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (Board[i, j] == 0)
                    {
                        emptyCells.Add((i, j));
                    }
                }
            }

            if (emptyCells.Any())
            {
                var (x, y) = emptyCells[random.Next(emptyCells.Count)];
                Board[x, y] = 2;
            }
        }
    }
}





