using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessPiece
    {
        // Pawn fields
        protected bool canEnPassantLeft;
        protected bool canEnPassantRight;
        protected bool canDoubleJump;

        // Other fields
        protected bool canCastle; // For rooks and kings
        protected Point[][] availableMoves; // Jagged array for moves ([direction][distance])
        protected Point[][] availableAttacks; // Same as Moves unless your a pawn.

        public Point[][] AvailableMoves
        {
            get { return availableMoves; }
        }
        
        public ChessPiece()
        {
            CalculateMoves();
        }

        public virtual ChessPiece CalculateMoves()
        {
            // Base piece can't move.
            availableMoves = new Point[0][]; 
            return this;
        }

        /// <summary>
        /// Get relative horizontal or virtical movement coordinates
        /// Used by: King, Queen, Pawn, Rook
        /// </summary>
        /// <param name="distance">How far in the given direction.</param>
        /// <param name="direction">This will probably become an enum</param>
        /// <returns>Return an array for horizontal or virtical movment</returns>
        protected Point[] GetMovementArray(int distance, Direction direction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get relative diagnal movement coordinates
        /// Used by: King, Queen, Pawn, Bishop
        /// </summary>
        /// <param name="distance">How far in the given direction</param>
        /// <param name="direction">Direction relative to player</param>
        /// <returns>Return an array for diagnal movement</returns>
        protected Point[] GetDiagnalMovementArray(int distance, DiagnalDirection direction)
        {
            throw new NotImplementedException();
        }
    }
}
