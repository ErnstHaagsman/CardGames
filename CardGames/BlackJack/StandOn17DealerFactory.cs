using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.BlackJack
{
    public class StandOn17DealerFactory : IDealerFactory
    {
        public IDealer getDealer(IBlackJackHand hand, IDeck deck, IPlayerDone done)
        {
            return new StandOn17Dealer(hand, deck, done);
        }
    }
}
