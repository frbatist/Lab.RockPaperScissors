using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public static class MoveFactory
    {
        public static IMove Create(Player player)
        {
            switch (player.Strategy)
            {
                case Strategy.ROCK:
                    return new RockMove();
                case Strategy.PAPER:
                    return new PaperMove();
                case Strategy.SCISSOR:
                    return new ScissorMove();
                default:
                    return null;
            }
        }
    }
}