using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess;

namespace FormClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 1; x < tableLayoutPanel1.ColumnCount; x++)
            {
                for (int y = 1; y < tableLayoutPanel1.RowCount; y++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    if ((x + y) % 2 == 1) button.BackColor = Color.Gray;
                    tableLayoutPanel1.Controls.Add(button);
                }
            }

            ChessBoard chessBoard = new ChessBoard();
            
        }
    }
}
