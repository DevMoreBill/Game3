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
        private GameBoard gameBoard; // Добавляем поле для ссылки на игровую доску

        public Game(int size)
        {
            grid = new bool[size, size];
            playerXTurn = true;
        }

        public void AssignGameBoard(GameBoard board) // Метод для передачи ссылки на игровую доску
        {
            gameBoard = board;
        }

        public bool MakeMove(int row, int col)
        {
            if (grid[row, col])
            {
                return false;
            }

            grid[row, col] = playerXTurn;
            gameBoard.GetCellButton(row, col).Text = playerXTurn ? "X" : "O";

            if (HasWon(row, col, playerXTurn))
            {
                MessageBox.Show((playerXTurn ? "X" : "O") + " wins!");
                ResetGame();
                return true; // Возвращаем true после обработки выигрыша
            }
            else
            {
                playerXTurn = !playerXTurn;
            }
            return true; // возвращаем true после удачного хода
        }

        private bool HasWon(int row, int col, bool isPlayerX)
        {
            int count = 0;
            bool[,] currentGrid = (bool[,])grid.Clone();

            // Проверка горизонтальных линий для символа "X"
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (currentGrid[i, col] == isPlayerX)
                {
                    count++;
                    if (count == 5)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            // Проверка вертикальных линий для символа "X"
            count = 0;
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (currentGrid[row, j] == isPlayerX)
                {
                    count++;
                    if (count == 5)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            // Проверка диагоналей слева направо и сверху вниз для символа "X"
            count = 0;
            for (int i = -4; i <= 4; i++)
            {
                if (IsInGrid(row + i, col + i) && currentGrid[row + i, col + i] == isPlayerX)
                {
                    count++;
                    if (count == 5)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            // Проверка диагоналей справа налево и сверху вниз для символа "X"
            count = 0;
            for (int i = -4; i <= 4; i++)
            {
                if (IsInGrid(row + i, col - i) && currentGrid[row + i, col - i] == isPlayerX)
                {
                    count++;
                    if (count == 5)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            return false; // возвращаем false, если победное условие не выполнено
        }

        private bool IsInGrid(int row, int col)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
        }

        private void ResetGame()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = false;
                    gameBoard.GetCellButton(i, j).Text = "";
                }
            }
        }
    }
}
