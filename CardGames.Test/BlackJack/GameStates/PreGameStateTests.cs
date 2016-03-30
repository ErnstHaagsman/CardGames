using CardGames.BlackJack;
using CardGames.BlackJack.Dealers;
using CardGames.BlackJack.GameStates;
using CardGames.Cards;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Test.BlackJack.GameStates
{
    [TestFixture]
    public class PreGameStateTests
    {
        IFixture fixture; 

        [SetUp]
        public void Init()
        {
            fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        [Test]
        public void GameOverOnDealerBlackJack()
        {
            // Arrange
            var dealer = fixture.Freeze<Mock<IDealer>>();
            dealer.Setup(x => x.Hand.IsBlackJack()).Returns(true);
            var gameStateInternal = fixture.Freeze<Mock<IGameStateInternal>>();

            // Arrange, get sut
            var sut = fixture.Create<PreGameState>();
            sut.SetPlayer(fixture.Create<IPlayer>());

            // Act
            sut.StartGame();

            // Assert
            gameStateInternal
                .Verify(x => x.MoveTo(It.IsAny<GameOverState>()), Times.Once);
        }
    }
}
