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
    public class GamePlayTest
    {
        [TestMethod]
        public void RockWinsScissor()
        {
            var player1 = new Player { Name = "Jose", Strategy = "R" };
            var player2 = new Player { Name = "joão", Strategy = "S" };            
            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_game_winner(new Player[] { player1, player2 });

            Assert.AreEqual(player1, winner);
        }
        [TestMethod]
        public void PaperWinsRock()
        {
            var player1 = new Player { Name = "Jose", Strategy = "P" };
            var player2 = new Player { Name = "joão", Strategy = "R" };
            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_game_winner(new Player[] { player1, player2 });

            Assert.AreEqual(player1, winner);
        }
        [TestMethod]
        public void ScissorWinsPaper()
        {
            var player1 = new Player { Name = "Jose", Strategy = "S" };
            var player2 = new Player { Name = "joão", Strategy = "P" };
            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_game_winner(new Player[] { player1, player2 });

            Assert.AreEqual(player1, winner);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongNumberOfPlayersError), AllowDerivedTypes = true)]
        public void MustCheckNumberOfPlayers()
        {
            var player1 = new Player { Name = "Jose", Strategy = "S" };
            var player2 = new Player { Name = "joão", Strategy = "P" };
            var player3 = new Player { Name = "Intruder", Strategy = "R" };
            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_game_winner(new Player[] { player1, player2, player3 });
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchStrategyError), AllowDerivedTypes = true)]
        public void MustCheckForInvalidStrategy()
        {
            var player1 = new Player { Name = "Jose", Strategy = "S" };
            var player2 = new Player { Name = "joão", Strategy = "X" };            
            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_game_winner(new Player[] { player1, player2 });
        }
    }
}
