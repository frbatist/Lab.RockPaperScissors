using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.Exceptions
{
    public class WrongEncodedArrayFormat : Exception
    {
        public WrongEncodedArrayFormat(string message = "Invalid encoded bracketed array format!", Exception innerException = null) 
            : base(message, innerException)
        {
        }
    }
}