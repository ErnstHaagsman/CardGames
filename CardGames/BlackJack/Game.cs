using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public class Game : IPlayerDone
    {
        private IDeck deck;
        private Card dealerOpenCard = null;
        public IPlayer Dealer
        {
            get; set;
        }

        public IPlayer Player
        {
            get; set; 
        }

        public event EventHandler<IPlayer> onPlayerWins;
        public event EventHandler<IPlayer> onPlayerTies;

        public void PlayerDone(IPlayer player)
        {
            if(player == Dealer)
            {
                int compare = Player.Hand.CompareTo(Dealer.Hand);
                if(compare == 1)
                {
                    onPlayerWins(this, Player);
                } else if (compare == -1)
                {
                    onPlayerWins(this, Dealer);
                } else
                {
                    onPlayerTies(this, Player);
                }
            }
            else
            {
                // We should play as the dealer
                while (Dealer.Hand.GetValue() < 17)
                {
                    Dealer.Hit();
                }
                Dealer.Stand();
            }
        }

        public void StartGame()
        {
            // Initial deal
            Dealer.Hand.AddCard(deck.NextCard());
            dealerOpenCard = deck.NextCard();
            Dealer.Hand.AddCard(dealerOpenCard);
            Player.Hand.AddCard(deck.NextCard());
            Player.Hand.AddCard(deck.NextCard());
        }

        public Card DealerOpenCard()
        {
            return dealerOpenCard;
        }

        public Game(IDeck deck)
        {
            this.deck = deck;
            Dealer = new Player(new BlackJackHand(), deck, this);
            Dealer.Name = "Dealer";
            Player = new Player(new BlackJackHand(), deck, this);
            Player.Name = "Player";
        }
    }
}
