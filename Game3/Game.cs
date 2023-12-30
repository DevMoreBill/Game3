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
            playerXTurn = !playerXTurn;

            // Добавляем обозначение X или O на кнопку в зависимости от текущего игрока
            CellButton button = gameBoard.GetCellButton(row, col);
            if (playerXTurn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }

            return true;
        }
    }
}
