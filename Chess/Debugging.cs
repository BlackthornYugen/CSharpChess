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
    public partial class Debugging : Form
    {
        ChessPiece[] chessPieces = { new Knight(), new Pawn(), new Bishop(), new Queen(), new King(), new Rook() };
        ChessPiece pawn = new Pawn(doubleJump: false);

        public Debugging()
        {
            InitializeComponent();
            int buttonPositionX = 41;
            int buttonPositionY = 250;
            this.SuspendLayout();
            
            noDoubleJumpPawnButton.Tag = pawn;

            for (int i = 0; i < chessPieces.Length; i++)
            {
                Button loopButton = new System.Windows.Forms.Button();
                ChessPiece loopPiece = chessPieces[i];
                loopButton.Location = new System.Drawing.Point(buttonPositionX, buttonPositionY);
                loopButton.Name = "chessButton" + (i + 1);
                loopButton.Size = new System.Drawing.Size(337, 23);
                loopButton.Text = "Get Available moves for " + loopPiece.GetType();
                loopButton.Tag = loopPiece;
                loopButton.UseVisualStyleBackColor = true;
                loopButton.Click += new System.EventHandler(this.ChessPiece_Click);
                buttonPositionY += 29;
                this.Controls.Add(loopButton);
            }

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ChessPiece_Click(object sender, EventArgs e)
        {
            ChessPiece senderPiece = (ChessPiece)((Button)sender).Tag;
            textBox1.Text = "Movement\r\n" + DumpAvailableMoves(senderPiece);
            textBox1.Text += "Attack\r\n" + DumpAttackMoves(senderPiece);
        }

        private string DumpAvailableMoves(ChessPiece chessPiece)
        {
            string movesList = "";
            for (int i = 0; i < chessPiece.AvailableMoves.Length; i++)
            {
                for (int j = 0; j < chessPiece.AvailableMoves[i].Length; j++)
                {
                    movesList += chessPiece.AvailableMoves[i][j].ToString() + ", ";
                }
                movesList += "\r\n";
            }
            return movesList;
        }

        private string DumpAttackMoves(ChessPiece chessPiece)
        {
            string movesList = "";
            for (int i = 0; i < chessPiece.AvailableAttacks.Length; i++)
            {
                for (int j = 0; j < chessPiece.AvailableAttacks[i].Length; j++)
                {
                    movesList += chessPiece.AvailableAttacks[i][j].ToString() + ", ";
                }
                movesList += "\r\n";
            }
            return movesList;
        }
    }
}
