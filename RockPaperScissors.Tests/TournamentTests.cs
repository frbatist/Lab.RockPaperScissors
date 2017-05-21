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
    [TestClass()]
    public class TournamentTests
    {
        [TestMethod()]
        //[ExpectedException(typeof(WrongNumberOfTournamentRounds))]
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

            try
            {
                var tournament = TournamentFactory.Parse(encodedArray.ToString());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(WrongNumberOfTournamentRounds), ex.GetType());
            }            
        }

        [TestMethod]
        //[ExpectedException(typeof(WrongPlayerStructureError))]
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

            try
            {
                var tournament = TournamentFactory.Parse(encodedArray.ToString());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(WrongPlayerStructureError), ex.GetType());
            }
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
        public void LinkMustBeTheWinner()
        {
            var encodedArray = new StringBuilder();
            encodedArray.Append("[");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [");
            encodedArray.Append("               [");
            encodedArray.Append("                   [\"Link\", \"P\"],[\"Ganon\", \"R\"]");
            encodedArray.Append("               ],");
            encodedArray.Append("               [");
            encodedArray.Append("                   [\"Batman\", \"R\"],[\"Joker\", \"S\"]");
            encodedArray.Append("               ]");
            encodedArray.Append("           ],");
            encodedArray.Append("           [");
            encodedArray.Append("               [");
            encodedArray.Append("                   [\"Cloud\", \"R\"],[\"Sephiroth\", \"S\"]");
            encodedArray.Append("               ],");
            encodedArray.Append("               [");
            encodedArray.Append("                   [\"Luke\", \"S\"],[\"Vader\", \"P\"]");
            encodedArray.Append("               ]");
            encodedArray.Append("           ]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [");
            encodedArray.Append("               [\"Armando\", \"P\"],[\"Dave\", \"S\"]");
            encodedArray.Append("           ],");
            encodedArray.Append("           [");
            encodedArray.Append("               [\"Richard\", \"R\"],[\"Michael\", \"S\"]");
            encodedArray.Append("           ]");
            encodedArray.Append("       ]");
            encodedArray.Append("   ],");
            encodedArray.Append("   [");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"Allen\", \"S\"],[\"Omer\", \"P\"]");
            encodedArray.Append("       ],");
            encodedArray.Append("       [");
            encodedArray.Append("           [\"David E.\", \"R\"],[\"Richard X.\", \"S\"]");
            encodedArray.Append("       ]");
            encodedArray.Append("   ]");
            encodedArray.Append("]");

            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_tournament_winner(encodedArray.ToString());
            Assert.AreEqual(winner.Name, "Link");
        }

        [TestMethod]
        //[ExpectedException(typeof(WrongEncodedArrayFormat))]
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

            try
            {
                var tournament = TournamentFactory.Parse(encodedArray.ToString());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(WrongEncodedArrayFormat), ex.GetType());
            }
        }
        [TestMethod]
        //[ExpectedException(typeof(WrongEncodedArrayFormat))]
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

            try
            {
                var tournament = TournamentFactory.Parse(encodedArray.ToString());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(WrongEncodedArrayFormat), ex.GetType());
            }
        }
    }
}
