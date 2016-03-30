using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using CardGames.BlackJack.Dealers;

namespace CardGames.BlackJack.GameStates
{
    public class InGameState : IGameState
    {
        private IDeck deck;
        private IDealer dealer;
        private IPlayer player;
        private IGameStateInternal gameStateInternal;

        public IBlackJackHand CurrentHand
        {
            get
            {
                return Player.Hand;
            }
        }

        public Card[] DealerCards
        {
            get
            {
                throw new InvalidOperationException();
            }
        }

        public Card DealerOpenCard
        {
            get
            {
                return dealer.OpenCard;
            }
        }

        public IPlayer Player
        {
            get
            {
                return player;
            }
        }

        public GameState State
        {
            get
            {
                return GameState.InGame;
            }
        }

        public void Hit()
        {
            player.Hit();

            if (player.Done)
                nextState();
        }

        public void SetPlayer(IPlayer player)
        {
            throw new InvalidOperationException();
        }

        public void Stand()
        {
            player.Stand();
            nextState();
        }

        private void nextState()
        {
            dealer.Play();
            gameStateInternal.MoveTo(new GameOverState(dealer, player));
        }

        public void StartGame()
        {
            throw new InvalidOperationException();
        }

        public InGameState(IGameStateInternal gameStateInternal, IDealer dealer, IPlayer player, IDeck deck)
        {
            this.gameStateInternal = gameStateInternal;
            this.dealer = dealer;
            this.player = player;
            this.deck = deck;
        }
    }
}
