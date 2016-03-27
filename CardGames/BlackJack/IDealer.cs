using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public interface IDealer : IPlayer
    {
        /// <summary>
        /// Play the dealer's cards
        /// </summary>
        void Play();
        
        /// <summary>
        /// The open card
        /// </summary>
        Card OpenCard { get; }

        /// <summary>
        /// All the dealer's cards, empty array prior to calling 'Play'
        /// </summary>
        Card[] GetCards();
    }
}
