using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutDomain
{
    public class GameLogic
    {
        public bool[,] GameField { get; private set; }
        public string LevelName { get; private set; }

        private int xSize;
        private int ySize;

        public void LoadLevel(string levelName, int xSize, int ySize, int[] enabledLampNumbers)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            GameField = new bool[xSize,ySize];
            foreach(int enabledLampNumber in enabledLampNumbers)
            {
                GameField[enabledLampNumber % xSize, enabledLampNumber / xSize] = true;
            }
            LevelName = levelName;
        }

        private IEnumerable<Tuple<int,int>> GetNeighbours(int x, int y)
        {
            foreach (int neighbourX in new int[] { x - 1, x + 1 })
            {
                if (neighbourX >= 0
                        && neighbourX < xSize)
                    yield return new Tuple<int, int>(neighbourX, y);
            }
            foreach (int neighbourY in new int[] { y - 1, y + 1 })
            {
                if (neighbourY >= 0
                    && neighbourY < ySize)
                    yield return new Tuple<int, int>(x, neighbourY);
            }
            
        }

        public void ProcessToggle(int x, int y)
        {
            GameField[x, y] = !GameField[x, y];
            foreach(Tuple<int, int> neighbourPosition in GetNeighbours(x, y))
            {
                GameField[neighbourPosition.Item1, neighbourPosition.Item2] = 
                    !GameField[neighbourPosition.Item1, neighbourPosition.Item2];
            }
        }
    }
}
