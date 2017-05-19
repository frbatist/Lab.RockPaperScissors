using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public interface IMove
    {
        String CurrentStrategy { get; }
        /// <summary>
        /// Compare the players strategies, and returns the winner
        /// </summary>
        /// <param name="opponent"></param>
        /// <returns></returns>
        bool Compete(IMove opponent);
    }
}