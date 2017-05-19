using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public Game()
        {
            Players = new List<Player>();
        }
    }
}