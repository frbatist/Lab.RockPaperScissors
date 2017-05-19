using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public class Round
    {
        public List<Game> Games { get; set; }
        public Round()
        {
            Games = new List<Game>();
        }
    }
}