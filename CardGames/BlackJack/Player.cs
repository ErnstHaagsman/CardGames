using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public class Player : IPlayer
    {
        private IBlackJackHand hand;
        private IDeck deck;
        private bool done;

        public event EventHandler<Card> onReceivedCard;
        public event Action<IPlayer> onPlayerDied;
        public event Action<IPlayer> onBlackJack;
        public event Action<IPlayer> onTurnFinished;

        public bool Alive
        {
            get
            {
                return hand.IsAlive();
            }
        }

        public IBlackJackHand Hand
        {
            get
            {
                return hand;
            }
        }

        public string Name { get; set; }

        public bool Done
        {
            get
            {
                return done;
            }
        }

        public Card Hit()
        {
            Card newCard = deck.NextCard();

            hand.AddCard(newCard);
            OnRaiseReceivedCard(newCard);

            if (!Alive)
            {
                OnRaisePlayerDied();
                doneWithTurn();
            }

            return newCard;
        }

        protected virtual void OnRaiseReceivedCard(Card card)
        {
            EventHandler<Card> handler = onReceivedCard;
            if(handler != null)
            {
                handler(this, card);
            }
        }

        protected virtual void OnRaisePlayerDied()
        {
            Action<IPlayer> handler = onPlayerDied;
            if (handler != null)
            {
                handler(this);
            }
        }

        protected virtual void OnRaiseBlackJack()
        {
            Action<IPlayer> handler = onBlackJack;
            if (handler != null)
            {
                handler(this);
            }
        }

        protected virtual void OnRaiseTurnFinished()
        {
            Action<IPlayer> handler = onTurnFinished;
            if (handler != null)
            {
                handler(this);
            }
        }

        public void Stand()
        {
            doneWithTurn();
        }

        private void doneWithTurn()
        {
            done = true;
            OnRaiseTurnFinished();
        }

        public void Initialize()
        {
            for (int i = 0; i < 2; i++)
                hand.AddCard(deck.NextCard());

            if (hand.IsBlackJack())
            {
                OnRaiseBlackJack();
            }
        }

        public Player(IBlackJackHand hand, IDeck deck)
        {
            this.hand = hand;
            this.deck = deck;
        }
    }
}
