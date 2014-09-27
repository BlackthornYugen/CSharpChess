using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Chess;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    button.Click += Select_Piece;
                }
            }

            DrawPieces(chessBoard);
        }

        private void Select_Piece(object s, EventArgs e)
        {
            DrawPieces(chessBoard);
            if (!(s is Button)) return;
            Button button = (Button)s;
            button.FlatStyle = FlatStyle.Standard;

            if (!(button.Tag is ChessPiece)) return;
            ChessPiece chessPiece = (ChessPiece) button.Tag;
            TableLayoutPanelCellPosition a = boardLayoutPanel.GetPositionFromControl((Control)s);
            Console.WriteLine("({2}, {3}) - {0} from team {1}", chessPiece.GetType(), chessPiece.Player, a.Column - 1, a.Row - 1);

            foreach (Chess.Point point in chessBoard.PieceActions(a.Column - 1, a.Row - 1))
            {
                Button actionButton = (Button)boardLayoutPanel.GetControlFromPosition(point.x + 1, point.y + 1);
                actionButton.FlatStyle = FlatStyle.Standard;
                Console.WriteLine("~({0}, {1})", point.x, point.y);
            }
            Console.WriteLine();
        }

        private void Action_Piece(object s, EventArgs e)
        {
            Button actionButton = (Button)s;
            MessageBox.Show("");
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
                    this.coordinates.SetToolTip(button, String.Format("({0}, {1})", x, y));
                }
            }
        }
    }
}
