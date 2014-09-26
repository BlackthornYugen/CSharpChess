using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : ChessPiece
    {
        public Pawn()
        {
            this.canDoubleJump = true;
            CalculateMoves();
        }

        public Pawn(int player)
        {
            base.Player = player;
            this.canDoubleJump = true;
            CalculateMoves();
        }
        
        /// <summary>
        /// Create a new pawn.
        /// </summary>
        /// <param name="doubleJump">Allows the pawn to move two squares.</param>
        /// <param name="enPassantLeft">Allows the pawn to en passant on the left.</param>
        /// <param name="enPassantRight">Allows the pawn to en passant on the right.</param>
        public Pawn(int player = 0, bool doubleJump = true, bool enPassantLeft = false, bool enPassantRight = false)
        {
            base.Player = player;
            this.canDoubleJump = doubleJump;
            this.canEnPassantLeft = enPassantLeft;
            this.canEnPassantRight = enPassantRight;
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            Direction forward;
            DiagnalDirection forwardLeft, forwardRight;
            if (base.Player == 1)
            {
                forward = Direction.BACKWARD;
                forwardLeft = DiagnalDirection.BACKWARD_LEFT;
                forwardRight = DiagnalDirection.BACKWARD_RIGHT;
            }
            else
            {
                forward = Direction.FORWARD;
                forwardLeft = DiagnalDirection.FORWARD_LEFT;
                forwardRight = DiagnalDirection.FORWARD_RIGHT;
            }

            availableMoves = new Point[1][];
            if (this.canDoubleJump)
            {
                availableMoves[0] = GetMovementArray(2, forward);
            }
            else
            {
                availableMoves[0] = GetMovementArray(1, forward);
            }
            availableAttacks = new Point[2][];
            availableAttacks[0] = GetDiagnalMovementArray(1, forwardLeft);
            availableAttacks[1] = GetDiagnalMovementArray(1, forwardRight);
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
