using Lab.RockPaperScissors.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public static class TournamentFactory
    {
        public static Tournament Parse(string data)
        {
            JArray rounds;
            try
            {
                rounds = JsonConvert.DeserializeObject<JArray>(data);
            }
            catch (Exception ex)
            {
                throw new WrongEncodedArrayFormat(innerException: ex);
            }
            var tournament = new Tournament();            
            foreach (var itemRound in rounds.Children())
            {
                var round = BuildRound(itemRound);
                tournament.AddRound(round);
            }
            return tournament;
        }

        private static Round BuildRound(JToken itemRound)
        {
            bool arrayOfRounds = false;
            try
            {
                if()

                //if value of third level node is of value type, it means that it's a game node
                arrayOfRounds = !(itemRound.First().First().First() is JValue);
            }
            catch (Exception ex)
            {
                throw new WrongEncodedArrayFormat(innerException:ex);
            }

            if (arrayOfRounds)
                return NestRound(itemRound);
            else
                return BuildGameList(itemRound);
        }

        private static Round NestRound(JToken itemRound)
        {
            var round = new Round()
            {
                Itens = new List<Round>()
            };
            JArray rounds = (JArray)itemRound;
            foreach (var item in rounds.Children())
            {
                var newRound = BuildRound(item);
                round.Itens.Add(newRound);
            }
            return round;
        }

        private static Round BuildGameList(JToken itemRound)
        {
            var round = new Round()
            {
                Itens = new List<Game>()
            };
            JArray games = (JArray)itemRound;
            foreach (var itemGame in games.Children())
            {
                var game = BuildGame(itemGame);
                round.Itens.Add(game);
            }
            return round;
        }

        private static Game BuildGame(JToken itemGame)
        {
            var game = new Game()
            {
                Players = new List<Player>()
            };
            var players = (JArray)itemGame;
            foreach (var player in players)
            {
                var playerStructure = GetPlayerStructure(player);
                CheckPlayerStructure(playerStructure);
                game.Players.Add((Player.ParsePlayerArray(((JArray)playerStructure).Select(d => (string)d).ToArray())));
            }
            return game;
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

        private static void CheckPlayerStructure(JArray playerStructure)
        {
            if (playerStructure.Count() != 2)
            {
                throw new WrongPlayerStructureError();
            }
        }
    }
}