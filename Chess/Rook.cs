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
            availableMoves = new Point[4][];
            availableMoves[0] = GetMovementArray(MAX_DISTANCE, Direction.FORWARD);
            availableMoves[1] = GetMovementArray(MAX_DISTANCE, Direction.BACKWARD);
            availableMoves[2] = GetMovementArray(MAX_DISTANCE, Direction.LEFT);
            availableMoves[3] = GetMovementArray(MAX_DISTANCE, Direction.RIGHT);
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
