﻿using CardGames.BlackJack.Dealers;
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

        public IPlayer Player
        {
            get; set; 
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
            Player = new Player(new BlackJackHand(), deck);
            Player.Name = "Player";

            dealer.onTurnFinished += (pl) => resolveWinner();
            Player.onTurnFinished += (pl) => dealer.Play();
        }
    }
}
