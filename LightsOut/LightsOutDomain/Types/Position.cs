using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutDomain.Types
{
    public class Position
    {
        public readonly int X;
        public readonly int Y;
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
