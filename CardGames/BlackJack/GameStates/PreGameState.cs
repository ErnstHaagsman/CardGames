using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using CardGames.BlackJack.Dealers;

namespace CardGames.BlackJack.GameStates
{
    class PreGameState : IGameState
    {
        private IDealer dealer;
        private IDeck deck;
        private IGameStateInternal gameStateInternal;

        public IBlackJackHand CurrentHand
        {
            get
            {
                throw new InvalidOperationException();
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
                throw new InvalidOperationException();
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
                return GameState.PreGame;
            }
        }

        public void Hit()
        {
            throw new InvalidOperationException();
        }

        private IPlayer player;
        public void SetPlayer(IPlayer player)
        {
            this.player = player;
        }

        public void Stand()
        {
            throw new InvalidOperationException();
        }

        public void StartGame()
        {
            // Initial deal
            dealer.Initialize();
            Player.Initialize();

            if (dealer.Hand.IsBlackJack() || player.Hand.IsBlackJack())
                gameStateInternal.MoveTo(new GameOverState(dealer, player));
            else
                gameStateInternal.MoveTo(new InGameState(gameStateInternal, dealer, player, deck));
        }

        public PreGameState(IGameStateInternal gameStateInternal, IDealerFactory dealerFactory, IDeck deck)
        {
            this.gameStateInternal = gameStateInternal;
            this.deck = deck;

            dealer = dealerFactory.getDealer(new BlackJackHand(), deck);
        }
    }
}
