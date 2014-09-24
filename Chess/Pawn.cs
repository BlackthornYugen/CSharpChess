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
            availableMoves[0] = new Point[1] {new Point(0, 1)};
            if (this.canDoubleJump)
            {
                Array.Resize<Point>(ref availableMoves[0], 2);
                availableMoves[0][1] = new Point(0, 2);
            }
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
