using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public interface IGameState
    {
        void SetPlayer(IPlayer player);
        IPlayer Player { get; }
        GameState State { get; }

        Card DealerOpenCard { get; }
        Card[] DealerCards { get; }

        void StartGame();

        IBlackJackHand CurrentHand { get; }
        void Hit();
        void Stand();
    }
}
