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
            catch (Exception)
            {
                throw new WrongEncodedArrayFormat();
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
            var round = new Round();
            round.Games = new List<Game>();
            JArray games = (JArray)itemRound;
            foreach (var itemGame in games.Children())
            {
                var game = BuildGame(itemGame);
                round.Games.Add(game);
            }
            return round;
        }

        private static Game BuildGame(JToken itemGame)
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