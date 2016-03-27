using CardGames.BlackJack;
using CardGames.Cards;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Test.BlackJack
{
    [TestFixture]
    public class BlackJackHandTest
    {
        private IBlackJackHand sut;

        [SetUp]
        public void Init()
        {
            sut = new BlackJackHand();
        }

        [Test]
        public void IsBlackJack()
        {
            // Arrange
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));

            // Assert
            Assert.True(sut.IsBlackJack(), "BlackJackHand fails to identify blackjack");
            Assert.True(sut.IsAlive(), "BlackJackHand says a blackjack is dead");
            Assert.AreEqual(21, sut.GetValue(), "BlackJackHand can't count to 21");
        }

        [Test]
        public void DetectsDeadHand()
        {
            // Arrange
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Three, Suit.Clubs));
            sut.AddCard(new Card(Rank.Nine, Suit.Clubs));

            // Assert
            Assert.AreEqual(22, sut.GetValue(), "BlackJackHand can't count");
            Assert.False(sut.IsAlive(), "BlackJackHand thinks a player is alive with 22 points");
        }


        [Test]
        public void CanCountAces()
        {
            // Arrange
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Nine, Suit.Clubs));
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));

            // Assert
            Assert.AreEqual(20, sut.GetValue(), "BlackJackHand can't count aces");
            Assert.True(sut.IsAlive(), "BlackJackHand has no respect for aces");
        }
    }
}
