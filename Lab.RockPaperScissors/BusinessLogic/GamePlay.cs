using Lab.RockPaperScissors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.RockPaperScissors.BusinessLogic
{
    public class GamePlay
    {
        /// <summary>
        /// Returns the winner in a RPS match 
        /// </summary>
        /// <param name="players">List of two players</param>
        /// <returns>Returns winner of type Player</returns>
        public Player rps_game_winner(Player[] players)
        {
            CheckPlayersQuantity(players);
            return GetWinner(players[0], players[1]);
        }

        /// <summary>
        /// Returns the winner in a RPS tournament, assumes that the first list of rounds in the tournament are of two members
        /// </summary>
        /// <param name="tournamentArray">Receives the tournament encoded as a brackted array string</param>
        /// <returns>Returns winner of type Playe</returns>
        public Player rps_tournament_winner(string tournamentArray)
        {
            var tournament = TournamentFactory.Parse(tournamentArray);
            var finals = new Game()
            {
                Players = new List<Player>()
                {
                    GetRoundWinner(tournament.Rounds[0]),
                    GetRoundWinner(tournament.Rounds[1])
                }
            };
            return rps_game_winner(finals.Players.ToArray());
        }

        private Player GetRoundWinner(Round round)
        {
            if (round.Itens is List<Game>)
            {
                return GetGamesWinner((round.Itens as List<Game>).ToArray());
            }
            foreach (var item in round.Itens)
            {
                if (item is List<Round>)
                {
                    return GetRoundsCollectionWinner((Round[])item);                    
                }
            }
            throw new EmptyRoundError();
        }

        private Player GetRoundsCollectionWinner(Round[] rounds)
        {
            List<Player> winners = new List<Player>();
            foreach (var item in rounds)
            {
                winners.Add(GetRoundWinner(item));
            }
            var newRound = MakeNewRound(winners.ToArray());
            return GetGamesWinner(newRound);
        }

        private Player GetGamesWinner(Game[] games)
        {
            if (games.Count() == 1)
            {                
                return rps_game_winner(games[0].Players.ToArray());
            }
            Player[] winners = GetGamesWinners(games);
            var newRound = MakeNewRound(winners);
            return GetGamesWinner(newRound);
        }

        private Game[] MakeNewRound(Player[] winners)
        {
            var newRound = new List<Game>
            {
                new Game()
            };
            int gameIndex = 1;
            int playersIndex = 1;
            foreach (var item in winners)
            {
                if (gameIndex == 1)
                {
                    newRound.First().Players.Add(item);
                    gameIndex++;
                }
                else
                {
                    newRound.First().Players.Add(item);
                    if (playersIndex < winners.Count())
                    {
                        newRound.Add(new Game());
                        gameIndex = 1;
                    }
                }
                playersIndex++;
            }
            return newRound.ToArray();
        }

        private Player[] GetGamesWinners(Game[] games)
        {
            var winners = new List<Player>();
            foreach (var game in games)
            {
                winners.Add(rps_game_winner(game.Players.ToArray()));
            }
            return winners.ToArray();
        }

        private Player GetWinner(Player player1, Player player2)
        {
            var move1 = MoveFactory.Create(player1);
            var move2 = MoveFactory.Create(player2);
            CheckStrategies(move1, move2);
            if (move1.CurrentStrategy.Equals(move2.CurrentStrategy))
            {
                return player1;
            }            
            if (move1.Compete(move2))
            {
                return player1;
            }
            else
            {
                return player2;
            }            
        }

        private void CheckStrategies(IMove move1, IMove move2)
        {
            if (move1 == null || move2 == null)
            {
                throw new NoSuchStrategyError();
            }
        }

        private void CheckPlayersQuantity(IEnumerable<Player> players)
        {
            if (players.Count() != 2)
            {
                throw new WrongNumberOfPlayersError();
            }
        }
    }
}