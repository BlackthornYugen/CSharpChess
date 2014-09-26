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
        public Bishop(int player)
        {
            base.Player = player;
            CalculateMoves();
        }

        public override ChessPiece CalculateMoves()
        {
            availableMoves = new Point[4][];
            availableMoves[0] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.FORWARD_LEFT);
            availableMoves[1] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.FORWARD_RIGHT);
            availableMoves[2] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.BACKWARD_LEFT);
            availableMoves[3] = GetDiagnalMovementArray(MAX_DISTANCE, DiagnalDirection.BACKWARD_RIGHT);
            availableAttacks = availableMoves;
            return this;
        }
    }
}
