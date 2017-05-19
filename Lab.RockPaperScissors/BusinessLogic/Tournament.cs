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

        public static Tournament Parse(string data)
        {
            JArray rounds;
            try
            {
                rounds = JsonConvert.DeserializeObject<JArray>(data);
            }
            catch (Exception)
            {
                throw new WrongEncodedArrayFormat();
            }
            var tournament = new Tournament();

            //CheckNodeChildren(rounds);
            foreach (var itemRound in rounds.Children())
            {
                var round = new Round();
                round.Games = new List<Game>();
                JArray games = (JArray)itemRound;
                foreach (var itemGame in games.Children())
                {
                    var game = new Game();
                    game.Players = new List<Player>();
                    var players = (JArray)itemGame;
                    foreach (var player in players)
                    {
                        var playerStructure = GetPlayerStructure(player);
                        CheckPlayerStructure(playerStructure);
                        game.Players.Add((Player.ParsePlayerArray(((JArray)playerStructure).Select(d => (string)d).ToArray())));
                    }
                    round.Games.Add(game);
                }
                tournament.AddRound(round);
            }
            return tournament;
        }

        private static JArray GetPlayerStructure(JToken player)
        {
            try
            {
                return (JArray)player;
            }
            catch (Exception)
            {
                throw new WrongEncodedArrayFormat();
            }
        }

        public void AddRound(Round round)
        {
            if (Rounds.Count() == 2)
            {
                throw new WrongNumberOfTournamentRounds();
            }
            Rounds.Add(round);
        }

        private static void CheckPlayerStructure(JArray playerStructure)
        {
            if (playerStructure.Count() != 2)
            {
                throw new WrongPlayerStructureError();
            }
        }
    }
}