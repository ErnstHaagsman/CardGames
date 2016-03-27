using CardGames.Cards;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Test.Cards
{
    [TestFixture]
    public class DeckTests
    {
        private IDeck sut;

        [SetUp]
        public void Init()
        {
            sut = new Deck();
        }

        [Test]
        public void GetsCards()
        {
            // Act
            for (int i = 0; i < 52; i++)
                sut.NextCard();
        }

        [Test]
        public void OutOfCards()
        {
            // Act
            for (int i = 0; i < 52; i++)
                sut.NextCard();
            Assert.Throws<DeckOutOfCardsException>(() => sut.NextCard(), "Got a 53rd card from the deck");
        }

        [Test]
        public void NoDuplicates()
        {
            List<Card> cards = new List<Card>(52);
            for (int i = 0; i < 52; i++)
                cards.Add(sut.NextCard());

            Assert.AreEqual(52, cards.Count);
            Assert.AreEqual(52, cards.Distinct().Count(), "Duplicate cards in the deck");
        }
    }
}
