using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutDomain
{
    public class GameLogic
    {
        public int[,] GameField { get; private set; }
        public string LevelName { get; private set; }

        public void LoadLevel(string levelName, int xSize, int ySize, int[] enabledLampNumbers)
        {
            GameField = new int[xSize,ySize];
            foreach(int enabledLampNumber in enabledLampNumbers)
            {
                GameField[enabledLampNumber % xSize, enabledLampNumber / xSize] = 1;
            }
            LevelName = levelName;
        }
    }
}
