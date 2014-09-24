using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : ChessPiece
    {
        public Knight()
        {
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            availableMoves = new Point[8][] { 
                new[] { new Point(1, 3) },      new[] {new Point(3, 1)},
                new[] { new Point(-1, -3) },    new[] {new Point(-3, -1)},
                new[] { new Point(-1, 3) },     new[] {new Point(-3, 1)},
                new[] { new Point(1, -3) },     new[] {new Point(3, -1)} };
            availableAttacks = availableMoves;
            return this;
        }
    }
}
