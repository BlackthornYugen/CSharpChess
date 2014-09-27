using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Knight : ChessPiece
    {
        public Knight()
        {
            CalculateMoves();
        }
        public Knight(int player)
        {
            base.Player = player;
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            availableMoves = new Point[8][] { 
                new[] { new Point(1, 2) },      new[] {new Point(2, 1)},
                new[] { new Point(-1, -2) },    new[] {new Point(-2, -1)},
                new[] { new Point(-1, 2) },     new[] {new Point(-2, 1)},
                new[] { new Point(1, -2) },     new[] {new Point(2, -1)} };
            availableAttacks = availableMoves;
            return this;
        }
    }
}
