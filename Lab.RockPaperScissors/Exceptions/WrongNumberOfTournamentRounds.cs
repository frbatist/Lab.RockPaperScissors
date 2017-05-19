using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.Exceptions
{
    public class WrongNumberOfTournamentRounds : Exception
    {
        public WrongNumberOfTournamentRounds(string message = "Invalid tournament structure, only 2 inicial rounds permited!")
            : base(message)
        {

        }
    }
}