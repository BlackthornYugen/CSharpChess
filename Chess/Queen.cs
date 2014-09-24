using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : ChessPiece
    {
        public Queen()
        {
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            availableMoves = new Point[8][];
            availableMoves[0] = GetMovementArray(MAX_DISTANCE, Direction.FORWARD);
            availableMoves[1] = GetMovementArray(MAX_DISTANCE, Direction.BACKWARD);
            availableMoves[2] = GetMovementArray(MAX_DISTANCE, Direction.LEFT);
            availableMoves[3] = GetMovementArray(MAX_DISTANCE, Direction.RIGHT);

            availableMoves[4] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.FORWARD_LEFT);
            availableMoves[5] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.FORWARD_RIGHT);
            availableMoves[6] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.BACKWARD_LEFT);
            availableMoves[7] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.BACKWARD_RIGHT);
            availableAttacks = availableMoves;
            return this;
        }
    }
}
