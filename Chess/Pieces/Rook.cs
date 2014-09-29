using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Rook : CastlePiece
    {
        public Rook()
        {
            this.canCastle = true;
            CalculateMoves();
        }

        public Rook(bool castle)
        {
            this.canCastle = castle;
            CalculateMoves();
        }

        public Rook(bool castle, int player = 0)
        {
            base.Player = player;
            this.canCastle = castle;
            CalculateMoves();
        }

        public Rook(int player)
        {
            base.Player = player;
            this.canCastle = true;
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
    }
}
