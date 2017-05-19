using Lab.RockPaperScissors.BusinessLogic;
using Lab.RockPaperScissors.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Tests
{
    [TestClass]
    public class TournamentTests
    {
        [TestMethod]
        [ExpectedException(typeof(WrongNumberOfTournamentRounds))]
        public void MustCheckNumberOfInicialRounds()
        {
            var encodedArray = new StringBuilder();
            encodedArray.Append("[");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Armando\", \"P\"],[\"Dave\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Richard\", \"R\"],[\"Michael\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("   ],");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Allen\", \"S\"],[\"Omer\", \"P\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"David E.\", \"R\"],[\"Richard X.\", \"P\"]");
            encodedArray.Append("       ]");
            encodedArray.Append("   ],");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Batman\", \"S\"],[\"Joker\", \"P\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Luke\", \"R\"],[\"Vader\", \"S\"]");
            encodedArray.Append("       ]");
            encodedArray.Append("   ]");
            encodedArray.Append("]");

            var tournament = Tournament.Parse(encodedArray.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(WrongPlayerStructureError))]
        public void MustCheckStructureOfPlayerNode()
        {
            var encodedArray = new StringBuilder();
            encodedArray.Append("[");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Armando\", \"P\"],[\"Dave\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Richard\", \"R\"],[\"Michael\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("   ],");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Allen\", \"S\"],[\"Omer\", \"P\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"David E.\", \"R\"],[\"Richard X.\", \"P\", \"AAA\"]");
            encodedArray.Append("       ]");
            encodedArray.Append("   ]");
            encodedArray.Append("]");

            var tournament = Tournament.Parse(encodedArray.ToString());
        }

        [TestMethod]
        public void RichardMustBeTheWinner()
        {
            var encodedArray = new StringBuilder();
            encodedArray.Append("[");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Armando\", \"P\"],[\"Dave\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Richard\", \"R\"],[\"Michael\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("   ],");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Allen\", \"S\"],[\"Omer\", \"P\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"David E.\", \"R\"],[\"Richard X.\", \"P\"]");
            encodedArray.Append("       ]");
            encodedArray.Append("   ]");
            encodedArray.Append("]");

            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_tournament_winner(encodedArray.ToString());
            Assert.AreEqual(winner.Name, "Richard");
        }

        [TestMethod]
        [ExpectedException(typeof(WrongEncodedArrayFormat))]
        public void MustRaiseFormatErrorWithNoRoot()
        {
            var encodedArray = new StringBuilder();
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Armando\", \"P\"],[\"Dave\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Richard\", \"R\"],[\"Michael\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("   ],");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Allen\", \"S\"],[\"Omer\", \"P\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"David E.\", \"R\"],[\"Richard X.\", \"P\"]");
            encodedArray.Append("       ]");
            encodedArray.Append("   ]");

            var tournament = Tournament.Parse(encodedArray.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(WrongEncodedArrayFormat))]
        public void MustRaiseFormatErrorWithNoRound()
        {
            var encodedArray = new StringBuilder();
            encodedArray.Append("[");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Armando\", \"P\"],[\"Dave\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Richard\", \"R\"],[\"Michael\", \"S\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Allen\", \"S\"],[\"Omer\", \"P\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"David E.\", \"R\"],[\"Richard X.\", \"P\"]");
            encodedArray.Append("       ]");
            encodedArray.Append("]");

            var tournament = Tournament.Parse(encodedArray.ToString());
        }
    }
}
