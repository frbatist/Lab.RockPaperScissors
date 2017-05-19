using Lab.RockPaperScissors.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public class Tournament
    {
        public List<Round> Rounds { get; }

        public Tournament()
        {
            Rounds = new List<Round>();
        }

        public void AddRound(Round round)
        {
            if (Rounds.Count() == 2)
            {
                throw new WrongNumberOfTournamentRounds();
            }
            Rounds.Add(round);
        }
    }
}