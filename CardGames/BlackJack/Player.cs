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
        private IPlayerDone playerDone;

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

        public Card Hit()
        {
            Card newCard = deck.NextCard();

            hand.AddCard(newCard);
            if (!Alive)
                playerDone.PlayerDone(this);

            return newCard;
        }

        public void Stand()
        {
            playerDone.PlayerDone(this);
        }

        public Player(IBlackJackHand hand, IDeck deck, IPlayerDone playerDone)
        {
            this.hand = hand;
            this.deck = deck;
            this.playerDone = playerDone;
        }
    }
}
