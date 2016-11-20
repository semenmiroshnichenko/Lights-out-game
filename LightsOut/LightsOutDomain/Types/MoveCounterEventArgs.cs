using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutDomain.Types
{
    public class MoveCounterEventArgs : EventArgs
    {
        public readonly int Value;
        public MoveCounterEventArgs(int value)
        {
            Value = value;
        }
    }
}
