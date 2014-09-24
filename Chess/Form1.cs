using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        ChessPiece chessPiece = new ChessPiece();
        ChessPiece pawn = new Pawn(doubleJump: false);
        ChessPiece king = new King();
        ChessPiece rook = new Rook();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            for (int i = 0; i < chessPiece.AvailableMoves.Length; i++)
            {
                for (int j = 0; j < chessPiece.AvailableMoves[i].Length; j++)
                {
                    textBox1.Text += chessPiece.AvailableMoves[i][j].ToString() + ", ";
                }
                textBox1.Text += "\r\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            for (int i = 0; i < pawn.AvailableMoves.Length; i++)
            {
                for (int j = 0; j < pawn.AvailableMoves[i].Length; j++)
                {
                    textBox1.Text += pawn.AvailableMoves[i][j].ToString() + ", ";
                }
                textBox1.Text += "\r\n";
            }
        }
    }
}
