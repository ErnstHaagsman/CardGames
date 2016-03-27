using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public interface IPlayerDone
    {
        /// <summary>
        /// This function should be called to indicate that a player is done
        /// with their turn
        /// </summary>
        void PlayerDone(IPlayer player);
    }
}
