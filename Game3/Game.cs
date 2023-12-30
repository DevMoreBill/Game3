using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class Game
    {
        private bool[,] grid;
        private bool playerXTurn;

        public Game(int size)
        {
            grid = new bool[size, size];
            playerXTurn = true;
        }

        public bool MakeMove(int row, int col)
        {
            if (grid[row, col])
            {
                return false;
            }

            grid[row, col] = true;

            // Добавляем обозначение X или O на кнопку в зависимости от текущего игрока
            if (playerXTurn)
            {
                gameBoard.GetCellButton(row, col).Text = "X";
            }
            else
            {
                gameBoard.GetCellButton(row, col).Text = "O";
            }

            playerXTurn = !playerXTurn;
            return true;
        }
    }
}
