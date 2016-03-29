using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.BlackJack
{
    public class GameStateEventArgs : EventArgs
    {
        public GameState NextState { get; set; }

        public GameStateEventArgs(GameState nextState)
        {
            NextState = nextState;
        }
    }
}
