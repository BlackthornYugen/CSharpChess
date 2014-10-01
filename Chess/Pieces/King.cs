using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King : CastlePiece
    {
        public King()
        {
            this.canCastle = true;
            CalculateMoves();
        }

        public King(int player)
        {
            base.Player = player;
            this.canCastle = true;
            CalculateMoves();
        }

        public King(bool castle)
        {
            this.canCastle = castle;
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            if (this.canCastle)
            {
                availableMoves = new Point[10][];
                availableMoves[8] = new[] { new Point(2, 0) };
                availableMoves[9] = new[] { new Point(-2, 0) };
            }
            else
            {
                availableMoves = new Point[8][];
            }
            availableMoves[0] = GetMovementArray(1, Direction.FORWARD);
            availableMoves[1] = GetMovementArray(1, Direction.BACKWARD);
            availableMoves[2] = GetMovementArray(1, Direction.LEFT);
            availableMoves[3] = GetMovementArray(1, Direction.RIGHT);

            availableMoves[4] = GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_LEFT);
            availableMoves[5] = GetDiagnalMovementArray(1, DiagnalDirection.FORWARD_RIGHT);
            availableMoves[6] = GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_LEFT);
            availableMoves[7] = GetDiagnalMovementArray(1, DiagnalDirection.BACKWARD_RIGHT);

            availableAttacks = new Point[8][];
            Array.Copy(availableMoves, 0, availableAttacks, 0, 8);
            return this;
        }
    }
}
