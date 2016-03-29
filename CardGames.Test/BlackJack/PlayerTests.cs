using CardGames.BlackJack;
using CardGames.Cards;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Test.BlackJack
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void onTurnFinishedAfterHitTest()
        {
            // Arrange - set up player
            var mocker = new AutoMocker();
            mocker.Use<IBlackJackHand>(x => x.IsAlive() == false);
            var player = mocker.CreateInstance<Player>();

            // Arrange - set up event listener
            int calls = 0;
            player.onTurnFinished += (pl) => calls++;

            // Act
            player.Hit();

            // Assert
            Assert.AreEqual(1, calls);
        }

        [Test]
        public void onTurnFinishedAfterStandTest()
        {
            // Arrange - set up player
            var mocker = new AutoMocker();
            var player = mocker.CreateInstance<Player>();

            // Arrange - set up event listener
            int calls = 0;
            player.onTurnFinished += (pl) => calls++;

            // Act
            player.Stand();

            // Assert
            Assert.AreEqual(1, calls);
        }

        [Test]
        public void PlayerPropagatesOnBlackJack()
        {
            // Arrange - set up player
            var mocker = new AutoMocker();
            var hand = new Mock<IBlackJackHand>();

            mocker.Use(hand);
            var player = mocker.CreateInstance<Player>();

            // Arrange - set up event listener
            int calls = 0;
            player.onBlackJack += (pl) => calls++;

            // Act
            hand.Raise(x => x.onBlackJack += null, hand.Object);

            // Assert
            Assert.AreEqual(1, calls, "Player raises the wrong number of onBlackJack calls");
        }
    }
}
