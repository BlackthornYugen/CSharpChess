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
        protected bool canCastle;
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
