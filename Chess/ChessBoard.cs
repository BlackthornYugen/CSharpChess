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

        public int GetLength(int l)
        {
            return boardArray.GetLength(l);
        }

        public ChessPiece this[int x, int y]
        {
            get { return boardArray[x, y]; }
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
                // Player 0 pieces
                boardArray[i, 0] =          (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i]));
                boardArray[i, 1] =          (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i + COLUMNS]));
                // Player 1 pieces
                boardArray[i, ROWS - 1] =   (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i]), new object[] { 1 });
                boardArray[i, ROWS - 2] =   (ChessPiece)Activator.CreateInstance(
                                                Type.GetType("Chess." + playerPeices[i + COLUMNS]), new object[] { 1 });
            }
            return this;
        }

        /// <summary>
        /// Calculate the actual actions available for a Chess Piece at a set of coordinates.
        /// </summary>
        /// <param name="x">The number of squares right of the bottom left square</param>
        /// <param name="y">The number of squares above the bottom left square</param>
        /// <param name="ignoreCheck">Do not check for threats to the king</param>
        /// <param name="boardArray">An optional substitute board</param>
        /// <returns>A list of points that can be moved to</returns>
        public List<Point> PieceActions(int x, int y, bool ignoreCheck = false, ChessPiece[,] boardArray = null)
        {
            if (boardArray == null)
            {
                boardArray = this.boardArray;
            }

            bool[,] legalActions = new bool[boardArray.GetLength(0), boardArray.GetLength(1)];
            List<Point> availableActions = new List<Point>();
            ChessPiece movingPeice = boardArray[x, y];
            
            foreach (Point[] direction in movingPeice.AvailableAttacks)
            {
                foreach (Point attackPoint in direction)
                {
                    // If player's king is in check after move, CONTINUE
                    Point adjustedPoint = new Point(attackPoint.x + x, attackPoint.y + y);
                    if (ValidX(adjustedPoint.x) && ValidY(adjustedPoint.y))
                    {
                        availableActions.Add(adjustedPoint);
                    }
                    // If square occupided, BREAK
                }
            }

            if(movingPeice.AvailableAttacks != movingPeice.AvailableMoves)
            {
                foreach (Point[] direction in movingPeice.AvailableMoves)
                {
                    foreach (Point movePoint in direction)
                    {
                        // If player's king is in check after move, CONTINUE
                        // If square occupided, BREAK
                        Point adjustedPoint = new Point(movePoint.x + x, movePoint.y + y);
                        availableActions.Add(movePoint);
                        if (ValidX(adjustedPoint.x) && ValidY(adjustedPoint.y))
                        {
                            availableActions.Add(adjustedPoint);
                        }
                    }
                }
            }

            // If movingPeice is king with "canCastle", alter moves available if conditions met
            if (movingPeice is Pawn)
            {
                Pawn pawn = (Pawn)movingPeice;
                int flipDirection = 1;

                if (pawn.Player == 1) flipDirection = -1;
                if (pawn.CanEnPassantLeft)
                {
                    Point attackPoint;
                    attackPoint = ChessPiece.GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_LEFT)[0];
                    attackPoint.y *= flipDirection;
                    attackPoint.y += y;
                    attackPoint.x += x;
                    if (ValidX(attackPoint.x) && ValidY(attackPoint.y))
                    {
                        availableActions.Add(attackPoint);
                    }
                }
                if (pawn.CanEnPassantRight)
                {
                    Point attackPoint;
                    attackPoint = ChessPiece.GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_RIGHT)[0];
                    attackPoint.y *= flipDirection;
                    attackPoint.y += y;
                    attackPoint.x += x;
                    if (ValidX(attackPoint.x) && ValidY(attackPoint.y))
                    {
                        availableActions.Add(attackPoint);
                    }
                }
            }

            return availableActions;
        }

        public List<Point> PieceActions(Point position, bool ignoreCheck = false, ChessPiece[,] boardArray = null)
        {
            return PieceActions(position.x, position.y, ignoreCheck, boardArray);
        }

        public ChessBoard ActionPiece(int fromX, int fromY, int toX, int toY)
        {
            ChessPiece movingPeice = boardArray[fromX, fromY];
            return this;
        }

        public ChessBoard ActionPiece(Point from, Point to)
        {
            return ActionPiece(from.x, from.y, to.x, to.y);
        }

        /// <summary>
        /// Find out if a square is vulnerable to attacks by another player.
        /// </summary>
        /// <param name="player">The vulnerable player</param>
        /// <param name="boardArray">An optional substitute board for validating moves</param>
        /// <returns>True if square can be attacked</returns>
        public bool CheckSquareVulnerable(int squareX, int squareY, int player, ChessPiece[,] boardArray = null)
        {
            if (boardArray == null)
            {
                boardArray = this.boardArray;
            }

            for (int x = 0; x < boardArray.GetLength(0); x++)
            {
                for (int y = 0; y < boardArray.GetLength(1); y++)
                {
                    foreach (Point point in PieceActions(x,y,false))
                    {
                        if (point.x == squareX && point.y == squareY)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool ValidRange(int value, int high, int low = -1)
        {
            return value > low && value < high;
        }

        public bool ValidX(int value)
        {
            return ValidRange(value, boardArray.GetLength(0));
        }

        public bool ValidY(int value)
        {
            return ValidRange(value, boardArray.GetLength(1));
        }
    }
}
