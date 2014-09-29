using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class CastlePiece : ChessPiece
    {
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
