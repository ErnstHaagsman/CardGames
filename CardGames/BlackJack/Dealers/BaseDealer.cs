using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.BlackJack.Dealers
{
    abstract class BaseDealer : Player, IDealer
    {
        private bool played;

        public Card OpenCard
        {
            get
            {
                return this.Hand.GetCards()[1];
            }
        }

        public Card[] GetCards()
        {
            if (played)
                return this.Hand.GetCards();
            else
                return new Card[0];
        }

        public virtual void Play()
        {
            played = true;
        }

        public BaseDealer(IBlackJackHand hand, IDeck deck) 
            : base(hand, deck)
        {

        }
    }
}
