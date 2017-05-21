using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.Exceptions
{
    public class EmptyRoundError : Exception
    {
        public EmptyRoundError(string message = "Empty round node provided!") : base(message)
        {

        }
    }
}