using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.BlackJack
{
    public class BlackJackHand : IBlackJackHand
    {
        private List<Card> cards = new List<Card>(5);

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int CompareTo(IBlackJackHand other)
        {
            // First, handle dead hands
            if (!this.IsAlive())
            {
                if (other.IsAlive())
                {
                    return -1;
                } 
                else
                {
                    return 0;
                }
            } else if (!other.IsAlive())
            {
                return 1;
            }

            // Then, handle blackjacks
            if (this.IsBlackJack())
            {
                if (other.IsBlackJack())
                    return 0;
                else
                    return 1;
            }
            else if (other.IsBlackJack())
            {
                return -1;
            }

            // If neither party has blackjack, compare values
            int thisValue = this.GetValue();
            int otherValue = other.GetValue();

            if (thisValue > otherValue)
                return 1;
            if (thisValue < otherValue)
                return -1;
            else
                return 0;
        }

        public int GetValue()
        {
            // We need to sum the ranks of the cards
            // Ace can count as 11 or 1, so let's count them as 11 first
            // If we end up over 21, and we have one or more aces, try
            // to reduce the value by 10 for each until we are under 21

            int value = 0;
            int aces = cards.Where(x => x.Rank == Rank.Ace).Count();
            
            foreach (Card card in cards)
            {
                switch(card.Rank)
                {
                    case Rank.Ace:
                        value += 11;
                        break;
                    case Rank.Jack:
                    case Rank.Queen:
                    case Rank.King:
                        value += 10;
                        break;
                    default:
                        value += (int)card.Rank;
                        break;
                }
            }

            // Now we have the rough count, let's see if we need to reduce it for aces
            while (value > 21 && aces > 0)
            {
                value -= 10;
                aces--;
            }

            return value;
        }

        public bool IsAlive()
        {
            return GetValue() <= 21;
        }

        public bool IsBlackJack()
        {
            if (cards.Count != 2)
                return false;

            if (cards.Where(x => x.Rank == Rank.Ace).Count() == 1 &&
                cards.Where(x => x.Rank == Rank.Ten).Count() == 1)
               return true;

            return false;
        }
    }
}
