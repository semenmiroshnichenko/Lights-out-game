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
        private GameLogic sut;
        [SetUp]
        public void Setup()
        {
            GameLogic sut = new GameLogic();
            sut.LoadLevel("Level1", 4, 4, new int[] { 0, 5, 10, 15 });
        }

        [Test]
        public void WhenClickOnBulb00ShouldTriggerOnly01And10Bulbs()
        {
            Assert.Fail();
        }
    }
}
