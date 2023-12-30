using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game3
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private Game game;
        private GameBoard gameBoard;

        public MainForm()
        {
            InitializeComponent();
            game = new Game(10);
            gameBoard = new GameBoard(10, this, game);
        }
    }

}
