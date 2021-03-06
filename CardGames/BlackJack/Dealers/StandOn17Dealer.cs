﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.BlackJack.Dealers
{
    public class StandOn17Dealer : BaseDealer
    {
        public override void Play()
        {
            base.Play();

            while (Hand.GetValue() < 17)
            {
                Hit();
            }

            if(Alive)
                Stand();
        }

        public StandOn17Dealer(IBlackJackHand hand, IDeck deck) 
            : base(hand, deck)
        {

        }
    }
}
