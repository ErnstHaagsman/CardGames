using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public class Hand : IHand
    {
        private List<Card> cards = new List<Card>(5);

        public int Count
        {
            get
            {
                return cards.Count;
            }
        }

        public virtual void AddCard(Card card)
        {
            cards.Add(card);
        }

        public Card[] GetCards()
        {
            return cards.ToArray();
        }

        public virtual IEnumerator<Card> GetEnumerator()
        {
            return cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
