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
        ChessBoard chessBoard = new ChessBoard();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 1; x < boardLayoutPanel.ColumnCount; x++)
            {
                for (int y = 1; y < boardLayoutPanel.RowCount; y++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    if ((x + y) % 2 == 1) button.BackColor = Color.Gray;
                    else button.BackColor = Color.DarkGray;
                    boardLayoutPanel.Controls.Add(button);
                    button.Click += new EventHandler(Click_Piece);
                }
            }

            DrawPieces(chessBoard);
        }

        private void Click_Piece(object s, EventArgs e)
        {
            DrawPieces(chessBoard);
            if (!(s is Button)) return;
            Button button = (Button)s;
            button.FlatStyle = FlatStyle.Standard;

            if (!(button.Tag is ChessPiece)) return;
            ChessPiece chessPiece = (ChessPiece) button.Tag;

            Console.WriteLine("{0}", s);
            var moves = chessPiece.AvailableMoves;
            var attacks = chessPiece.AvailableAttacks;

            foreach (var item in moves)
            {
                foreach (var item2 in item)
                {
                    var buttonPosition = boardLayoutPanel.GetPositionFromControl((Control)s);
                    int x = item2.x + buttonPosition.Column;
                    int y = item2.y + buttonPosition.Row;
                    if (x > 0 && x < 9 && y > 0 && y < 9)
                    {
                        boardLayoutPanel.GetControlFromPosition(x, y).ForeColor = Color.Yellow;
                        boardLayoutPanel.GetControlFromPosition(x, y).Text = "x";
                    }
                }
            }

            foreach (var item in attacks)
            {
                foreach (var item2 in item)
                {
                    var buttonPosition = boardLayoutPanel.GetPositionFromControl((Control)s);
                    int x = item2.x + buttonPosition.Column;
                    int y = item2.y + buttonPosition.Row;
                    if (x > 0 && x < 9 && y > 0 && y < 9)
                    {
                        boardLayoutPanel.GetControlFromPosition(x, y).ForeColor = Color.Red;
                        boardLayoutPanel.GetControlFromPosition(x, y).Text = "x";
                    }
                }
            }
            Console.WriteLine();
        }

        private void DrawPieces(ChessBoard board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Button button = (Button)boardLayoutPanel.GetControlFromPosition(x + 1, y + 1);
                    button.FlatStyle = FlatStyle.Flat;
                    if (board[x, y] != null)
                    {
                        ChessPiece chessPiece = board[x, y];
                        button.Tag = chessPiece;
                        button.Text = chessPiece.ToString().Replace("Chess.", "");
                        if (chessPiece.Player == 1) button.ForeColor = Color.White;
                        else button.ForeColor = Color.Black;
                    }
                    else
                    {
                        button.Text = "";
                    }
                }
            }
        }
    }
}
