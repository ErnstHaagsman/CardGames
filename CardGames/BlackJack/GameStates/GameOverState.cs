using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;
using CardGames.BlackJack.Dealers;

namespace CardGames.BlackJack.GameStates
{
    public class GameOverState : IGameState
    {
        private IDealer dealer;
        private IPlayer player;

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
                return dealer.GetCards();
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
                return GameState.GameOver;
            }
        }

        public void Hit()
        {
            throw new InvalidOperationException();
        }

        public void SetPlayer(IPlayer player)
        {
            throw new InvalidOperationException();
        }

        public void Stand()
        {
            throw new InvalidOperationException();
        }

        public void StartGame()
        {
            throw new InvalidOperationException();
        }

        public GameOverState(IDealer dealer, IPlayer player)
        {
            this.player = player;
            this.dealer = dealer;

            // Handle wins and losses
            int compare = Player.Hand.CompareTo(dealer.Hand);
            if (compare == 1)
            {
                Player.Hand.State = HandState.Won;
                Player.Balance += Player.Hand.Bet * 2;
            }
            else if (compare == -1)
            {
                Player.Hand.State = HandState.Lost;
            }
            else
            {
                Player.Hand.State = HandState.Tied;
                Player.Balance += Player.Hand.Bet;
            }
        }
    }
}
