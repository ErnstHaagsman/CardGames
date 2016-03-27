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
        void AddCard(Card card);
        int GetValue();
        bool IsAlive();
        bool IsBlackJack();
    }
}
