using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", Rank, Suit);
        }

        public override int GetHashCode()
        {
            return (int)Suit * 13 + (int)Rank;
        }
    }
}
