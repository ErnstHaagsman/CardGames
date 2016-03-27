using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public interface IDeck
    {
        /// <summary>
        /// Reinitialize the deck
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Get the next card from the deck
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DeckOutOfCardsException">Thrown after the deck has been exhausted (after 52 cards have been drawn)</exception>
        Card NextCard();
    }
}
