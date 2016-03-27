using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public interface IPlayer
    {
        event EventHandler<Card> onReceivedCard;
        event Action<IPlayer> onPlayerDied;
        IBlackJackHand Hand { get; }
        string Name { get; set; }
        bool Alive { get; }
        void Stand();
        Card Hit();
        bool Done { get; }
    }
}
