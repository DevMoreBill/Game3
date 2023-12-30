using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class GameBoard
    {
        private CellButton[,] cellButtons;

        public GameBoard(int size, Form form)
        {
            cellButtons = new CellButton[size, size];
            const int buttonSize = 40;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var button = new CellButton(row, col)
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(col * buttonSize, row * buttonSize),
                        Tag = new int[] { row, col }
                    };
                    button.Click += CellButton_Click;
                    cellButtons[row, col] = button;
                    form.Controls.Add(button);
                }
            }
        }

        private void CellButton_Click(object sender, EventArgs e)
        {
            CellButton button = (CellButton)sender;
            int[] coords = (int[])button.Tag;
            int row = coords[0];
            int col = coords[1];

            if (!game.MakeMove(row, col))
            {
                MessageBox.Show("Invalid move!");
            }
        }

        public CellButton GetCellButton(int row, int col)
        {
            return cellButtons[row, col];
        }
    }
}
