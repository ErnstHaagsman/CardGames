using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public interface IBlackJackHand : IComparable<IBlackJackHand>
    {
        /// <summary>
        /// Add a card to the hand
        /// </summary>
        /// <param name="card"></param>
        void AddCard(Card card);

        /// <summary>
        /// Returns an array of all cards currently in the hand
        /// </summary>
        /// <returns></returns>
        Card[] GetCards();

        /// <summary>
        /// The numeric value of all cards in the hand
        /// </summary>
        /// <returns></returns>
        int GetValue();

        /// <summary>
        /// Is the player still alive?
        /// 
        /// False if value of hand over 21
        /// </summary>
        /// <returns></returns>
        bool IsAlive();

        /// <summary>
        /// Does the player have blackjack?
        /// 
        /// Meaning, a ten and an ace
        /// </summary>
        /// <returns></returns>
        bool IsBlackJack();
    }
}
