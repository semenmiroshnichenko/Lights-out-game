using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LightsOutDomain;

namespace LightsOutDomainTests
{
    [TestFixture]
    public class GameLogicLoadTests
    {
        [Test]
        public void WhenLoadLevelShouldSetTheGameField()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[]{ 0, 5, 10, 15});
            Assert.AreEqual(1, sut.GameField[0, 0]);
            Assert.AreEqual(1, sut.GameField[1, 1]);
            Assert.AreEqual(1, sut.GameField[2, 2]);
            Assert.AreEqual(1, sut.GameField[3, 3]);
            Assert.AreEqual(0, sut.GameField[0, 1]);
        }
        [Test]
        public void WhenLoadLevelShouldSetLevelName()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] {});
            Assert.AreEqual("Level1", sut.LevelName);
        }
    }
}
