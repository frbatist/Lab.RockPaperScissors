using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public class Round
    {
        /// <summary>
        /// It can be a list of games or a nested list of rounds
        /// </summary>
        public IList Itens { get; set; }

        public Round()
        {

        }
    }
}