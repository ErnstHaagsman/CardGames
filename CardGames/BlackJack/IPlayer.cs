﻿using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public interface IPlayer
    {
        /// <summary>
        /// This is fired when a player hits, and receives a new card
        /// </summary>
        event EventHandler<Card> onReceivedCard;

        /// <summary>
        /// This is fired when a player goes over 21
        /// </summary>
        event Action<IPlayer> onPlayerDied;

        /// <summary>
        /// The player's hand
        /// </summary>
        IBlackJackHand Hand { get; }

        /// <summary>
        /// The player's name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Is the player over 21?
        /// </summary>
        bool Alive { get; }

        /// <summary>
        /// When it is the player's turn, call this to stand
        /// </summary>
        void Stand();

        /// <summary>
        /// When it is the player's turn, call this to hit
        /// </summary>
        /// <returns></returns>
        Card Hit();

        /// <summary>
        /// Is the player's turn over?
        /// 
        /// Either the player died, or he stood
        /// </summary>
        bool Done { get; }
    }
}
