using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.Exceptions
{
    public class WrongPlayerStructureError : Exception
    {
        public WrongPlayerStructureError(string message = "Invalid player structure, it must be informed in a[\"Name\", \"Strategy\"] format!") 
            : base(message)
        {
        }
    }
}