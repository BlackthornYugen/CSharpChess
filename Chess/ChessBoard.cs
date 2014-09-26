using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessBoard
    {
        private ChessPiece[,] boardArray;
        private const int COLUMNS = 8;
        private int ROWS = 8; 
        
        public ChessBoard()
        {
            SetupBoard();
        }

        public ChessPiece[,] BoardArray
        {
            get { return boardArray; } // TODO: Get rid of this method. Should not expose boardArray.
        }

        private ChessBoard SetupBoard()
        {
            boardArray = new ChessPiece[COLUMNS, ROWS];
            string[] playerPeices = {
                "Rook", "Knight", "Bishop", "Queen",
                "King", "Bishop", "Knight", "Rook",
                "Pawn", "Pawn", "Pawn", "Pawn",
                "Pawn", "Pawn", "Pawn", "Pawn" };

            for (int i = 0; i < COLUMNS; i++)
            {
                boardArray[i, 0] =          (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i]));
                boardArray[i, 1] =          (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i + COLUMNS]));
                boardArray[i, ROWS - 1] =   (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i]), new object[] { 1 });
                boardArray[i, ROWS - 2] =   (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i + COLUMNS]), new object[] { 1 });
            }
            return this;
        }
    }
}
