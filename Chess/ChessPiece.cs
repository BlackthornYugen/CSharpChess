using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessPiece
    {
        protected bool canEnPassant;
        protected bool canCastle;

        public ChessPiece()
        {
        }

        public virtual string Foo()
        {
            return "Foo " + canEnPassant;
        }

        public virtual bool[,] GetAvailableMoves()
        {
            bool[,] moveList = new bool[8, 8];
            if (canEnPassant)
            {
                moveList[2, 2] = true;
            }
            return moveList;
        }
        public virtual bool[,] GetAvailableAttacks()
        {
            bool[,] moveList = new bool[8, 8];
            if (canEnPassant)
            {
                moveList[2, 2] = true;
            }
            return moveList;
        }
    }
}
