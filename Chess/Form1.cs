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
        ChessPiece pawn = new Pawn();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (bool item in chessPiece.GetAvailableMoves())
            {
                textBox1.Text += item.ToString() + " ";
            }
            //textBox1.Text = chessPiece.Foo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (bool item in pawn.GetAvailableMoves())
            {
                textBox1.Text += item.ToString() + " ";
            }
            //textBox1.Text = pawn.Foo();
        }
    }
}
