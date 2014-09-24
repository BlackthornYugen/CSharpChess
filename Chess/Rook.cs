using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : ChessPiece
    {
        public Rook(bool castle = true)
        {
            this.canCastle = castle;
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            availableMoves = new Point[0][];
            availableAttacks = availableMoves;
            return this;
        }

        public bool CanCastle
        {
            get
            {
                return this.canCastle;
            }
            set
            {
                this.canCastle = value;
            }
        }
    }
}
