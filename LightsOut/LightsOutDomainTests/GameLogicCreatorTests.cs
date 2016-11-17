using LightsOutDomain;
using LightsOutDomain.GameLogicCreator;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutDomainTests
{
    [TestFixture]
    public class GameLogicCreatorTests
    {
        private const string singleLevelJson = "[{\"name\": \"Level 0\", \"columns\": 4, \"rows\": 4,\"on\": [ 0, 5, 10, 15 ]}]";
        private const string doubleLevelJson = "[{\"name\": \"Level 0\", \"columns\": 4, \"rows\": 4,\"on\": [ 0, 5, 10, 15 ]}, { \"name\": \"Level 1\", \"columns\": 5, \"rows\": 5, \"on\": [ 0, 5, 7, 9, 10, 11, 12, 13, 15, 16, 17, 20, 22, 23 ] }]";


        [Test]
        public void CanCreateGameLogic()
        {
            var downloader = Substitute.For<IHttpDownloader>();
            downloader.GetData(Arg.Any<String>()).Returns(singleLevelJson);
            var gameLogics = GameLogicCreator.CreateFromUri(downloader, null);
            Assert.AreEqual(1, gameLogics.Count);
        }

        [Test]
        public void WhenCreateLevelFromJsonHasCorrectLevelName()
        {
            var downloader = Substitute.For<IHttpDownloader>();
            downloader.GetData(Arg.Any<String>()).Returns(singleLevelJson);
            var gameLogics = GameLogicCreator.CreateFromUri(downloader, null);
            Assert.AreEqual("Level 0", gameLogics.First().LevelName);
        }

        [Test]
        public void WhenCreateLevelFromJsonHasCorrectGameFieldSize()
        {
            var downloader = Substitute.For<IHttpDownloader>();
            downloader.GetData(Arg.Any<String>()).Returns(singleLevelJson);
            var gameLogics = GameLogicCreator.CreateFromUri(downloader, null);
            Assert.AreEqual(16, gameLogics.First().GameField.Length);
            Assert.AreEqual(4, gameLogics.First().GameField.GetLength(0));
            Assert.AreEqual(4, gameLogics.First().GameField.GetLength(1));
        }

        [Test]
        public void WhenCreateLevelFromJsonGameFieldIsFilledCorrectly()
        {
            var downloader = Substitute.For<IHttpDownloader>();
            downloader.GetData(Arg.Any<String>()).Returns(singleLevelJson);
            var gameLogics = GameLogicCreator.CreateFromUri(downloader, null);

            Assert.AreEqual(true, gameLogics.First().GameField[0, 0]);
            Assert.AreEqual(true, gameLogics.First().GameField[1, 1]);
            Assert.AreEqual(true, gameLogics.First().GameField[2, 2]);
            Assert.AreEqual(true, gameLogics.First().GameField[3, 3]);
            Assert.AreEqual(false, gameLogics.First().GameField[0, 1]);
        }

        [Test]
        public void CanCreateMultipleLevels()
        {
            var downloader = Substitute.For<IHttpDownloader>();
            downloader.GetData(Arg.Any<String>()).Returns(doubleLevelJson);
            var gameLogics = GameLogicCreator.CreateFromUri(downloader, null);
            Assert.AreEqual(2, gameLogics.Count);
        }
    }
}
