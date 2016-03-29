using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    public interface IHand : IEnumerable<Card>
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
        /// The amount of cards in the hand
        /// </summary>
        int Count { get; }
    }
}
