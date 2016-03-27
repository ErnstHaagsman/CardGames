using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    class PlayerFactory : IPlayerFactory
    {
        private IPlayerDone playerDone;
        private IDeck deck;

        public IPlayer newPlayer()
        {
            return new Player(new BlackJackHand(), deck, playerDone);
        }

        public PlayerFactory(IPlayerDone playerDone, IDeck deck)
        {
            this.playerDone = playerDone;
            this.deck = deck;
        }
    }
}
