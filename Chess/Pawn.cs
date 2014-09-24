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
            this.canEnPassant = true;
        }

        public override string Foo()
        {
            return "Foo " + canEnPassant;
        }

        public override bool[,] GetAvailableMoves()
        {
            return base.GetAvailableMoves();
        }
    }
}
