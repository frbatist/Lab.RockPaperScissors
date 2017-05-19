using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.Exceptions
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError(string message = "No such strategy!") : base(message)
        {            
        }
    }
}