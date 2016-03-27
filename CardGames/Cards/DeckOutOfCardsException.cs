using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    /// <summary>
    /// This exception is thrown when a card is requested from the deck after it has
    /// been exhausted. A deck has 52 cards, therefore the 53rd 'NextCard' call will
    /// result in this exception.
    /// </summary>
    public class DeckOutOfCardsException : CardGameException
    {
    }
}
