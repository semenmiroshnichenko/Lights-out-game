using LightsOutDomain.Types;
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
        public event EventHandler GameFieldChanged;

        public string LevelName { get; private set; }
        public int MoveCounter { get; private set; }
        public event EventHandler MoveCounterChanged;

        public bool Won { get; private set; }
        public event EventHandler WonChanged;

        private int xSize;
        private int ySize;
        
        public void LoadLevel(string levelName, int xSize, int ySize, int[] enabledLampNumbers)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            MoveCounter = 0;
            Won = false;
            GameField = new bool[xSize,ySize];
            foreach(int enabledLampNumber in enabledLampNumbers)
            {
                GameField[enabledLampNumber % xSize, enabledLampNumber / xSize] = true;
            }
            LevelName = levelName;
        }

        private IEnumerable<Position> GetNeighbours(int x, int y)
        {
            foreach (int neighbourX in new int[] { x - 1, x + 1 })
            {
                if (neighbourX >= 0 && neighbourX < xSize)
                    yield return new Position(neighbourX, y);
            }
            foreach (int neighbourY in new int[] { y - 1, y + 1 })
            {
                if (neighbourY >= 0 && neighbourY < ySize)
                    yield return new Position(x, neighbourY);
            }
        }

        public void ProcessToggle(int x, int y)
        {
            GameField[x, y] = !GameField[x, y];
            foreach(Position neighbourPosition in GetNeighbours(x, y))
            {
                GameField[neighbourPosition.X, neighbourPosition.Y] = 
                    !GameField[neighbourPosition.X, neighbourPosition.Y];
            }
            RaiseEvent(GameFieldChanged, null);

            CheckIfWon();
            RefreshMoveCounter();
        }

        private IEnumerable<bool> FlattenGameField()
        {
            for (int row = 0; row < GameField.GetLength(0); row++)
            {
                for (int column = 0; column < GameField.GetLength(1); column++)
                {
                    yield return GameField[row, column];
                }
            }
        }

        private void CheckIfWon()
        {
            if (FlattenGameField().All(x => x == false))
            {
                Won = true;
                RaiseEvent(WonChanged, null);
            }
        }

        private void RefreshMoveCounter()
        {
            MoveCounter++;
            RaiseEvent(MoveCounterChanged, null);
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        private void RaiseEvent(EventHandler eventToRaise, EventArgs args)
        {
            var handler = eventToRaise;
            if (handler != null)
                handler(this, args);
        }
    }
}
