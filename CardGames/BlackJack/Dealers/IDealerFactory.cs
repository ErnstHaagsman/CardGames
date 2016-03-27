using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack.Dealers
{
    public interface IDealerFactory
    {
        IDealer getDealer(IBlackJackHand hand, IDeck deck);
    }
}
