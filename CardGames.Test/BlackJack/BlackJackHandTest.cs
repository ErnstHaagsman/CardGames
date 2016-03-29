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
        public void FaceCardBlackJack()
        {
            // Arrange
            sut.AddCard(new Card(Rank.King, Suit.Clubs));
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));

            // Assert
            Assert.True(sut.IsBlackJack(), "BlackJackHand fails to identify blackjack with a face card");
            Assert.True(sut.IsAlive(), "BlackJackHand says a blackjack is dead");
            Assert.AreEqual(21, sut.GetValue(), "BlackJackHand can't count to 21");
        }

        [Test]
        public void TwoAceIsntBlackJack()
        {
            // Arrange
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));

            // Assert
            Assert.False(sut.IsBlackJack(), "BlackJackHand falsely identifies blackjack");
            Assert.True(sut.IsAlive(), "BlackJackHand says a blackjack is dead");
            Assert.AreEqual(12, sut.GetValue(), "Ace count wrong");
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

        [Test]
        public void CompareBlackJacks()
        {
            // Arrange this
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));
            
            // Arrange other
            IBlackJackHand other = new BlackJackHand();
            other.AddCard(new Card(Rank.Ten, Suit.Clubs));
            other.AddCard(new Card(Rank.Ace, Suit.Clubs));

            // Assert
            Assert.AreEqual(0, sut.CompareTo(other), "BlackJacks not equal");
        }

        [Test]
        public void CompareBlackJackTo21()
        {
            // Arrange this
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));

            // Arrange other
            IBlackJackHand other = new BlackJackHand();
            other.AddCard(new Card(Rank.Ten, Suit.Clubs));
            other.AddCard(new Card(Rank.Nine, Suit.Clubs));
            other.AddCard(new Card(Rank.Two, Suit.Clubs));

            // Assert
            Assert.AreEqual(1, sut.CompareTo(other), "BlackJack doesn't win over 21");
        }

        [Test]
        public void CompareValues()
        {
            // Arrange this
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Two, Suit.Clubs));

            // Arrange other
            IBlackJackHand other = new BlackJackHand();
            other.AddCard(new Card(Rank.Eight, Suit.Clubs));
            other.AddCard(new Card(Rank.Nine, Suit.Clubs));

            // Assert
            Assert.AreEqual(-1, sut.CompareTo(other), "Values don't compare well");
        }

        [Test]
        public void LiveHandWinsOverDead()
        {
            // Arrange this
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Two, Suit.Clubs));

            // Arrange other
            IBlackJackHand other = new BlackJackHand();
            other.AddCard(new Card(Rank.Eight, Suit.Clubs));
            other.AddCard(new Card(Rank.Nine, Suit.Clubs));
            other.AddCard(new Card(Rank.Seven, Suit.Clubs));

            // Assert
            Assert.AreEqual(1, sut.CompareTo(other), "Zombie hands win!");
        }

        [Test]
        public void DeadHandsTie()
        {
            // Arrange this
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Two, Suit.Clubs));
            sut.AddCard(new Card(Rank.Queen, Suit.Clubs));

            // Arrange other
            IBlackJackHand other = new BlackJackHand();
            other.AddCard(new Card(Rank.Eight, Suit.Clubs));
            other.AddCard(new Card(Rank.Nine, Suit.Clubs));
            other.AddCard(new Card(Rank.Seven, Suit.Clubs));

            // Assert
            Assert.AreEqual(0, sut.CompareTo(other), "Dead Hands Don't Tie");
        }

        [Test]
        public void BlackJackHand_onBlackJackTest()
        {
            // Arrange
            int calls = 0;
            sut.onBlackJack += (o) => calls++;

            // Act
            sut.AddCard(new Card(Rank.Ten, Suit.Clubs));
            sut.AddCard(new Card(Rank.Ace, Suit.Clubs));

            // Assert
            Assert.AreEqual(1, calls, "Hand onBlackJack called the wrong amount of times");
        }
    }
}
