using CardGames.BlackJack;
using CardGames.BlackJack.Dealers;
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
    public class StandOn17DealerTests
    {
        [Test]
        public void StandsOn17()
        {
            // Arrange - set up dealer
            var mocker = new AutoMocker();
            var blackJackHandMock = new Mock<IBlackJackHand>();
            blackJackHandMock.Setup(x => x.GetValue()).Returns(17);
            blackJackHandMock.Setup(x => x.IsAlive()).Returns(true);
            mocker.Use(blackJackHandMock.Object);
            var deckMock = new Mock<IDeck>();
            mocker.Use(deckMock);
            var dealer = mocker.CreateInstance<StandOn17Dealer>();

            // Arrange - set up event listener
            int calls = 0;
            dealer.onTurnFinished += (pl) => calls++;

            // Act
            dealer.Play();

            // Assert
            Assert.AreEqual(1, calls);
            deckMock.Verify(x => x.NextCard(), Times.Never());
        }

        [Test]
        public void HitsOn16()
        {
            // Arrange - set up dealer
            var mocker = new AutoMocker();
            IBlackJackHand hand = new BlackJackHand();
            hand.AddCard(new Card(Rank.Jack, Suit.Diamonds));
            hand.AddCard(new Card(Rank.Six, Suit.Diamonds));
            mocker.Use(hand);
            var deckMock = new Mock<IDeck>();
            deckMock.Setup(x => x.NextCard()).Returns(new Card(Rank.Three, Suit.Spades));
            mocker.Use(deckMock);
            var dealer = mocker.CreateInstance<StandOn17Dealer>();

            // Arrange - set up event listener
            int calls = 0;
            dealer.onTurnFinished += (pl) => calls++;

            // Act
            dealer.Play();

            // Assert
            Assert.AreEqual(1, calls);
            deckMock.Verify(x => x.NextCard(), Times.Once);
        }

        [Test]
        public void BustsOn16()
        {
            // Arrange - set up dealer
            var mocker = new AutoMocker();
            IBlackJackHand hand = new BlackJackHand();
            hand.AddCard(new Card(Rank.Jack, Suit.Diamonds));
            hand.AddCard(new Card(Rank.Six, Suit.Diamonds));
            mocker.Use(hand);
            var deckMock = new Mock<IDeck>();
            deckMock.Setup(x => x.NextCard()).Returns(new Card(Rank.Queen, Suit.Spades));
            mocker.Use(deckMock);
            var dealer = mocker.CreateInstance<StandOn17Dealer>();

            // Arrange - set up event listener
            int calls = 0;
            dealer.onTurnFinished += (pl) => calls++;

            // Act
            dealer.Play();

            // Assert
            Assert.AreEqual(1, calls);
            deckMock.Verify(x => x.NextCard(), Times.Once);
        }
    }
}
