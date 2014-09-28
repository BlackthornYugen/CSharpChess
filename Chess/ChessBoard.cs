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
        /// <param name="attackActions">Calculate attacks</param>
        /// <param name="moveActions">Calculate movement</param>
        /// <param name="boardArray">An optional substitute board</param>
        /// <returns>A list of points that can be moved to</returns>
        public IEnumerable<Point> PieceActions(int x, int y, bool ignoreCheck = false, bool attackActions = true, bool moveActions = true, ChessPiece[,] boardArray = null)
        {
            if (boardArray == null)
            {
                boardArray = this.boardArray;
            }

            bool[,] legalActions = new bool[boardArray.GetLength(0), boardArray.GetLength(1)];
            List<Point> availableActions = new List<Point>();
            ChessPiece movingPeice = boardArray[x, y];
            
            if (attackActions)
            {
                foreach (Point[] direction in movingPeice.AvailableAttacks)
                {
                    foreach (Point attackPoint in direction)
                    {
                        Point adjustedPoint = new Point(attackPoint.x + x, attackPoint.y + y);
                        if (ValidatePoint(adjustedPoint))
                        {
                            if (boardArray[adjustedPoint.x, adjustedPoint.y] != null
                                && boardArray[adjustedPoint.x, adjustedPoint.y].Player ==
                                movingPeice.Player) break;
                            // TODO: If player's king is in check after move, CONTINUE
                            if (boardArray[adjustedPoint.x, adjustedPoint.y] != null)
                            {
                                availableActions.Add(adjustedPoint);
                                break;
                            }
                        }
                    }
                }
            }

            if (moveActions)
            {
                foreach (Point[] direction in movingPeice.AvailableMoves)
                {
                    foreach (Point movePoint in direction)
                    {
                        Point adjustedPoint = new Point(movePoint.x + x, movePoint.y + y);
                        if (ValidatePoint(adjustedPoint))
                        {
                            // TODO: If player's king is in check after move, CONTINUE
                            if (boardArray[adjustedPoint.x, adjustedPoint.y] != null) break;
                            availableActions.Add(adjustedPoint);
                        }
                    }
                }
            }

            if (movingPeice is King && ((King)movingPeice).CanCastle)
            {
                // TODO: If movingPeice is king with "canCastle", alter moves available if conditions met                
            }

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
                    if (ValidatePoint(attackPoint))
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
                    if (ValidatePoint(attackPoint))
                    {
                        availableActions.Add(attackPoint);
                    }
                }
            }

            return availableActions;
        }

        public IEnumerable<Point> PieceActions(Point position, bool ignoreCheck = false, bool attackActions = true, bool moveActions = true, ChessPiece[,] boardArray = null)
        {
            return PieceActions(position.x, position.y, ignoreCheck, attackActions, moveActions, boardArray);
        }

        /// <summary>
        /// Move a peice from one location on the board to another.
        /// </summary>
        /// <param name="fromX">The x coordinate of the piece that is moving.</param>
        /// <param name="fromY">The y coordinate of the piece that is moving.</param>
        /// <param name="toX">The x coordinate of the destination.</param>
        /// <param name="toY">The y coordinate of the destination.</param>
        /// <returns>Returns true on success or false on failure.</returns>
        public bool ActionPiece(int fromX, int fromY, int toX, int toY)
        {
            return ActionPiece(new Point(fromX, fromY), new Point(toX, toY));
        }

        /// <summary>
        /// Move a peice from one location on the board to another.
        /// </summary>
        /// <param name="from">The location of the piece that is moving.</param>
        /// <param name="to">The location to move to.</param>
        /// <returns>Returns true on success or false on failure.</returns>
        public bool ActionPiece(Point from, Point to)
        {
            if (PieceActions(from).Contains(to))
            {
                ChessPiece movingPeice = boardArray[from.x, from.y];
                if (movingPeice is Pawn)
                {
                    Pawn pawn = (Pawn)movingPeice;
                    // If this was a double jump, check enpassant
                    if (Math.Abs(from.y - to.y) == 2)
                    {
                        int adjasentX = to.x - 1;
                        if (adjasentX > -1
                            && boardArray[adjasentX, to.y] != null
                            && boardArray[adjasentX, to.y].Player != movingPeice.Player
                            && boardArray[adjasentX, to.y] is Pawn)
                        {
                            ((Pawn)boardArray[adjasentX, to.y]).CanEnPassantRight = true;
                        }
                        adjasentX += 2;
                        if (adjasentX < COLUMNS
                            && boardArray[adjasentX, to.y] != null
                            && boardArray[adjasentX, to.y].Player != movingPeice.Player
                            && boardArray[adjasentX, to.y] is Pawn)
                        {
                            ((Pawn)boardArray[adjasentX, to.y]).CanEnPassantLeft = true;
                        }
                    }
                    // If this was a sideways jump to null, it was enpassant!
                    if (from.x != to.x && boardArray[to.x, to.y] == null)
                    {
                        boardArray[to.x, from.y] = null;
                    }
                    // Pawns can't double jump after they move.
                    pawn.CanDoubleJump = false;
                }
                if (movingPeice is Rook)
                {
                    Rook rook = (Rook)movingPeice;
                    // Castling can't be done after moving
                    rook.CanCastle = false;
                }
                if (movingPeice is King)
                {
                    King king = (King)movingPeice;
                    // Castling can't be done after moving
                    king.CanCastle = false;
                }
                movingPeice.CalculateMoves();
                boardArray[from.x, from.y] = null;
                boardArray[to.x, to.y] = movingPeice;
                return true;
            }
            return false;
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
                    if (boardArray[x, y].Player != player)
                    {
                        foreach (Point point in PieceActions(x, y, true, true, false, boardArray))
                        {
                            if (point.x == squareX && point.y == squareY)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool ValidateRange(int value, int high, int low = -1)
        {
            return value > low && value < high;
        }

        public bool ValidateX(int value)
        {
            return ValidateRange(value, boardArray.GetLength(0));
        }

        public bool ValidateY(int value)
        {
            return ValidateRange(value, boardArray.GetLength(1));
        }

        public bool ValidatePoint(Point point)
        {
            return ValidateX(point.x) && ValidateY(point.y);
        }
    }
}
