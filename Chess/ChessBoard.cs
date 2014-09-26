using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessBoard
    {
        ChessPiece[,] boardArray;
        private const int COLUMNS = 8;
        private int ROWS = 8; 
        
        public ChessBoard()
        {
            SetupBoard();
        }

        private ChessBoard SetupBoard()
        {
            ChessPiece[] rearRow = new ChessPiece[] { new Rook(), new Knight(), new Bishop(), new Queen(), new King(), new Bishop(), new Knight(), new Rook() };
            ChessPiece[] frontRow = new ChessPiece[] { new Pawn(), new Pawn(), new Pawn(), new Pawn() };

            for (int i = 0, j; i < COLUMNS; i++)
            {
                Console.WriteLine(rearRow[i%rearRow.Length]);
            }
            return this;
        }
    }
}
