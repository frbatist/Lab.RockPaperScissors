﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public class ScissorMove : IMove
    {
        public string CurrentStrategy { get { return Strategy.SCISSOR; } }

        public bool Compete(IMove opponent)
        {
            return opponent.CurrentStrategy.ToUpper() == Strategy.PAPER;
        }
    }
}