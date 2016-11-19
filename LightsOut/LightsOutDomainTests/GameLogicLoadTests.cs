using NUnit.Framework;
using LightsOutDomain;

namespace LightsOutDomainTests
{
    [TestFixture]
    public class GameLogicLoadTests
    {
        [Test]
        public void WhenLoadLevelShouldInitGameField()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] { 0, 5, 10, 15 });
            Assert.NotNull(sut.GameField);
            Assert.AreEqual(16, sut.GameField.Length);
            Assert.AreEqual(4, sut.GameField.GetLength(0));
            Assert.AreEqual(4, sut.GameField.GetLength(1));
            Assert.AreEqual(0, sut.MoveCounter);
            Assert.AreEqual(false, sut.Won);
        }
        [Test]
        public void WhenLoadLevelShouldFillTheGameField()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[]{ 0, 5, 10, 15});
            Assert.AreEqual(true, sut.GameField[0, 0]);
            Assert.AreEqual(true, sut.GameField[1, 1]);
            Assert.AreEqual(true, sut.GameField[2, 2]);
            Assert.AreEqual(true, sut.GameField[3, 3]);
            Assert.AreEqual(false, sut.GameField[0, 1]);
        }

        [Test]
        public void WhenLoadLevelShouldSetLevelName()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] {});
            Assert.AreEqual("Level1", sut.LevelName);
        }

        [Test]
        public void WhenMakeAMovementShouldUpdateMoveCounter()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] { 0, 5, 10, 15 });
            sut.ProcessToggle(0, 0);
            Assert.AreEqual(1, sut.MoveCounter);
        }

        [Test]
        public void WhenWinShouldUpdateWonFlag()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] { 1, 4, 5, 6, 9 });
            sut.ProcessToggle(1, 1);
            Assert.AreEqual(true, sut.Won);
        }

        [Test]
        public void WhenMakeMovementShouldRaiseGameFieldChangedEvent()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] { 1, 4, 5, 6, 9 });
            var wasCalled = false;
            sut.GameFieldChanged += ((o,e) => { wasCalled = true; });
            sut.ProcessToggle(1, 1);
            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void WhenMakeMovementShouldRaiseMoveCounterChangedEvent()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] { 1, 4, 5, 6, 9 });
            var wasCalled = false;
            sut.MoveCounterChanged += ((o, e) => { wasCalled = true; });
            sut.ProcessToggle(1, 1);
            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void WhenWinShouldRaiseWonEvent()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] { 1, 4, 5, 6, 9 });
            var wasCalled = false;
            sut.WonChanged += ((o, e) => { wasCalled = true; });
            sut.ProcessToggle(1, 1);
            Assert.IsTrue(wasCalled);
        }
    }
}
