using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : ChessPiece
    {
        public Bishop()
        {
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            availableMoves = new Point[0][];
            availableAttacks = availableMoves;
            return this;
        }
    }
}
