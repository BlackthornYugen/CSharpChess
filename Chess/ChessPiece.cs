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

        public bool CanEnPassantLeft
        {
            get { return canEnPassantLeft; }
            set { canEnPassantLeft = value; }
        }

        public bool CanEnPassantRight
        {
            get { return canEnPassantRight; }
            set { canEnPassantRight = value; }
        }

        // Other fields
        protected bool canCastle;

        public bool CanCastle
        {
            get { return canCastle; }
            set { canCastle = value; }
        }
        protected Point[][] availableMoves; //[direction, time, coordinate

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
    }
}
