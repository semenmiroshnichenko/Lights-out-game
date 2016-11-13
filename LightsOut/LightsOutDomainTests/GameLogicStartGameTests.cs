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
    public class GameLogicStartGameTests
    {
        private GameLogic sut = new GameLogic();
        [SetUp]
        public void Setup()
        {
            sut.LoadLevel("Level1", 4, 4, new int[] { 0, 5, 10, 15 });
        }

        [Test]
        public void WhenClickOnBulb00ShouldToggleItself()
        {
            sut.ProcessToggle(0, 0);
            Assert.AreEqual(false, sut.GameField[0, 0]);
        }

        [Test]
        public void WhenClickOnBulb00ShouldTrigger01And10Bulbs()
        {
            sut.ProcessToggle(0, 0);
            Assert.AreEqual(true, sut.GameField[0, 1]);
            Assert.AreEqual(true, sut.GameField[1, 0]);
        }

        [Test]
        public void WhenClickOnBulb11ShouldTrigger21And01And10And12Bulbs()
        {
            sut.ProcessToggle(1, 1);
            Assert.AreEqual(true, sut.GameField[2, 1]);
            Assert.AreEqual(true, sut.GameField[0, 1]);
            Assert.AreEqual(true, sut.GameField[1, 0]);
            Assert.AreEqual(true, sut.GameField[1, 2]);
        }
    }
}
