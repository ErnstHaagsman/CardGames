using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.BlackJack.Dealers
{
    public class StandOn17DealerFactory : IDealerFactory
    {
        public IDealer getDealer(IBlackJackHand hand, IDeck deck)
        {
            return new StandOn17Dealer(hand, deck);
        }
    }
}
