using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using CardGames.BlackJack.Dealers;
using CardGames.BlackJack.GameStates;

namespace CardGames.BlackJack
{
    public class Game : IGame, IGameStateInternal
    {
        private IGameState currentState;

        public event EventHandler<GameStateEventArgs> onNextState;

        public IBlackJackHand CurrentHand
        {
            get
            {
                return currentState.CurrentHand;
            }
        }

        public Card[] DealerCards
        {
            get
            {
                return currentState.DealerCards;
            }
        }

        public Card DealerOpenCard
        {
            get
            {
                return currentState.DealerOpenCard;
            }
        }

        public IPlayer Player
        {
            get
            {
                return currentState.Player;
            }
        }

        public GameState State
        {
            get
            {
                return currentState.State;
            }
        }

        public void Hit()
        {
            currentState.Hit();
        }

        public void MoveTo(IGameState next)
        {
            currentState = next;
            RaiseOnNextState(next.State);
        }

        public void SetPlayer(IPlayer player)
        {
            currentState.SetPlayer(player);
        }

        public void Stand()
        {
            currentState.Stand();
        }

        public void StartGame()
        {
            currentState.StartGame();
        }

        private void RaiseOnNextState(GameState next)
        {
            var handler = onNextState;
            if (handler != null)
            {
                handler(this, new GameStateEventArgs(next));
            }
        }

        public Game(IDealerFactory dealerFactory, IDeck deck)
        {
            deck.Shuffle();
            currentState = new PreGameState(this, dealerFactory, deck);
        }
    }
}
