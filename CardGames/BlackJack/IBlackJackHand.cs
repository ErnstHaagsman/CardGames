using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public interface IBlackJackHand : IHand, IComparable<IBlackJackHand>
    {
        /// <summary>
        /// The numeric value of all cards in the hand
        /// </summary>
        /// <returns></returns>
        int GetValue();

        /// <summary>
        /// Is the hand still alive?
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

        /// <summary>
        /// This is fired when this hand gets its second card, and becomes blackjack
        /// </summary>
        event Action<IBlackJackHand> onBlackJack;

        /// <summary>
        /// The state of this hand
        /// </summary>
        HandState State { get; set; }

        /// <summary>
        /// The bet made on this hand
        /// </summary>
        decimal Bet { get; }
    }
}
