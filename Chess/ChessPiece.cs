using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class ChessPiece
    {
        protected const int MAX_DISTANCE = 7;

        // Pawn fields
        protected bool canEnPassantLeft;
        protected bool canEnPassantRight;
        protected bool canDoubleJump;

        // Other fields
        protected bool canCastle; // For rooks and kings
        protected Point[][] availableMoves; // Jagged array for moves ([direction][distance])
        protected Point[][] availableAttacks; // Same as Moves unless your a pawn.
        private int player;

        public Point[][] AvailableMoves
        {
            get { return availableMoves; }
        }

        public Point[][] AvailableAttacks
        {
            get { return availableAttacks; }
        }

        public int Player
        {
            get { return player; }
            set { player = value; }
        } 

        public abstract ChessPiece CalculateMoves();

        /// <summary>
        /// Get relative horizontal or virtical movement coordinates
        /// Used by: King, Queen, Pawn, Rook
        /// </summary>
        /// <param name="distance">How far in the given direction.</param>
        /// <param name="direction">Direction relative to player</param>
        /// <returns>Return an array for horizontal or virtical movment</returns>
        public static Point[] GetMovementArray(int distance, Direction direction)
        {
            Point[] movement = new Point[distance];
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case Direction.FORWARD:
                        yPosition++;
                        break;
                    case Direction.BACKWARD:
                        yPosition--;
                        break;
                    case Direction.LEFT:
                        xPosition++;
                        break;
                    case Direction.RIGHT:
                        xPosition--;
                        break;
                    default:
                        break;
                }
                movement[i] = new Point(xPosition, yPosition);
            }
            return movement;
        }

        /// <summary>
        /// Get relative diagnal movement coordinates
        /// Used by: King, Queen, Pawn, Bishop
        /// </summary>
        /// <param name="distance">How far in the given direction</param>
        /// <param name="direction">Direction relative to player</param>
        /// <returns>Return an array for diagnal movement</returns>
        public static Point[] GetDiagnalMovementArray(int distance, DiagnalDirection direction)
        {
            Point[] attack = new Point[distance];
            int xPosition = 0;
            int yPosition = 0;

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case DiagnalDirection.FORWARD_LEFT:
                        xPosition--;
                        yPosition++;
                        break;
                    case DiagnalDirection.FORWARD_RIGHT:
                        xPosition++;
                        yPosition++;
                        break;
                    case DiagnalDirection.BACKWARD_LEFT:
                        xPosition--;
                        yPosition--;
                        break;
                    case DiagnalDirection.BACKWARD_RIGHT:
                        xPosition++;
                        yPosition--;
                        break;
                    default:
                        break;
                }
                attack[i] = new Point(xPosition, yPosition);
            }
            return attack;
        }
    }
}
