using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public class Deck : IDeck
    {
        private Queue<Card> cards;

        public Card NextCard()
        {
            if (cards.Count > 0)
                return cards.Dequeue();
            else
                throw new DeckOutOfCardsException();
        }

        public void Shuffle()
        {
            Card[] cardArray = new Card[52];

            int i = 0;
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cardArray[i] = new Card(rank, suit);
                    i++;
                }
            }

            Random rnd = new Random();
            cards = new Queue<Card>(cardArray.OrderBy(x => rnd.Next()));
        }

        public Deck()
        {
            Shuffle();
        }
    }
}
