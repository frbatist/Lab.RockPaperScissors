using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public class Player
    {
        public string Name { get; set; }
        public string Strategy { get; set; }

        public static Player ParsePlayerArray(string[] player)
        {
            return new Player { Name = player[0], Strategy = player[1] };
        }
    }
}