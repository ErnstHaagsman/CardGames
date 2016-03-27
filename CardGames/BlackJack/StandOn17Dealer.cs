using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.BlackJack
{
    class StandOn17Dealer : Player, IDealer
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

        public void Play()
        {
            while (Hand.GetValue() < 17)
            {
                Hit();
            }
            Stand();
            played = true;
        }

        public StandOn17Dealer(IBlackJackHand hand, IDeck deck, IPlayerDone done) 
            : base(hand, deck, done)
        {

        }
    }
}
