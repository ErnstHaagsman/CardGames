using CardGames.BlackJack.Dealers;
using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public class Game
    {
        private IDeck deck;
        private IDealer dealer;

        private IPlayer player;
        public IPlayer Player
        {
            get
            {
                return player;
            }
            set
            {
                if (player != null)
                    player.onTurnFinished -= Player_onTurnFinished;

                player = value;
                player.onTurnFinished += Player_onTurnFinished;
            } 
        }

        private void Player_onTurnFinished(IPlayer obj)
        {
            dealer.Play();
        }

        public event EventHandler<IPlayer> onPlayerWins;
        public event EventHandler<IPlayer> onPlayerTies;

        private void resolveWinner()
        {
            int compare = Player.Hand.CompareTo(dealer.Hand);
            if (compare == 1)
            {
                onPlayerWins(this, Player);
            }
            else if (compare == -1)
            {
                onPlayerWins(this, dealer);
            }
            else
            {
                onPlayerTies(this, Player);
            }
        }

        public void StartGame()
        {
            // Initial deal
            dealer.Initialize();
            Player.Initialize();

            if (Player.Hand.IsBlackJack() || dealer.Hand.IsBlackJack())
                resolveWinner();
        }

        public Card DealerOpenCard()
        {
            return dealer.OpenCard;
        }

        public Card[] GetDealerCards()
        {
            return dealer.GetCards();
        }

        public Game(IDeck deck, IDealerFactory dealerFactory)
        {
            this.deck = deck;
            dealer = dealerFactory.getDealer(new BlackJackHand(), deck);
            dealer.Name = "Dealer";

            dealer.onTurnFinished += Dealer_onTurnFinished; ;
        }

        private void Dealer_onTurnFinished(IPlayer obj)
        {
            resolveWinner();
            dealer.onTurnFinished -= Dealer_onTurnFinished;
        }
    }
}
