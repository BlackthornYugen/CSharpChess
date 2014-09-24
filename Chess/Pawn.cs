using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : ChessPiece
    {
        /// <summary>
        /// Create a new pawn.
        /// </summary>
        /// <param name="doubleJump">Allows the pawn to move two squares.</param>
        /// <param name="enPassantLeft">Allows the pawn to en passant on the left.</param>
        /// <param name="enPassantRight">Allows the pawn to en passant on the right.</param>
        public Pawn(bool doubleJump = true, bool enPassantLeft = false, bool enPassantRight = false)
        {
            this.canDoubleJump = doubleJump;
            this.canEnPassantLeft = enPassantLeft;
            this.canEnPassantRight = enPassantRight;
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            availableMoves = new Point[1][];
            if (this.canDoubleJump)
            {
                availableMoves[0] = GetMovementArray(2, Direction.FORWARD);
            }
            else
            {
                availableMoves[0] = GetMovementArray(1, Direction.FORWARD);
            }
            availableAttacks = new Point[2][];
            availableAttacks[0] = GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_LEFT);
            availableAttacks[1] = GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_RIGHT);
            return this;
        }

        public bool CanDoubleJump 
        {
            get
            {
                return this.canDoubleJump;
            }
            set
            {
                this.canDoubleJump = value;
            }
        }
        public bool CanEnPassantLeft
        {
            get
            {
                return this.canEnPassantLeft;
            }
            set
            {
                this.canEnPassantLeft = value;
            }
        }
        public bool CanEnPassantRight
        {
            get
            {
                return this.canEnPassantRight;
            }
            set
            {
                this.canEnPassantRight = value;
            }
        }
    }
}
