using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
namespace DataLayer
{
    public class Reprezentation
    {
        public string teamName { get; set; }
        public string teamCode { get; set; }
        public List<string> firsteleven = new List<string>();
        public List<string> substitutions = new List<string>();
        public Dictionary<string, PlayerInfo> players = new Dictionary<string, PlayerInfo>();
        public List<Match> matches = new List<Match>();
        public string goals_for { get; set; }
        public string goals_against { get; set; }
        public string goals_difference { get; set; }
        public string wins { get; set; }
        public string draws { get; set; }
        public string losses { get; set; }


        public Reprezentation(string tName, string tCode)
        {
            teamName = tName;
            teamCode = tCode;
        }

        public string GetPlayerNumber(string p) => players[p].player_number;

        public string GetPlayerPosition(string p) => players[p].position;

        public bool IsPlayerCaptain(string p) => players[p].is_captain;

        public int GetPlayerGoals(string p) => players[p].num_of_goals;

        public int GetPlayerCards(string p) => players[p].num_of_cards;


        public async Task SetUp()
        {
            dynamic response = await Contributor.GetCountryMatches(teamCode);

            if (response[0].home_team.code == teamCode)
            {
                foreach (var pl in response[0].home_team_statistics.starting_eleven)
                {
                    firsteleven.Add((string)pl.name);
                    players.Add((string)pl.name, new PlayerInfo()
                    {
                        player_name = (string)pl.name,
                        player_number = (string)pl.shirt_number,
                        position = (string)pl.position,
                        is_captain = Convert.ToBoolean(pl.captain),
                        num_of_cards = 0,
                        num_of_goals = 0
                    });
                }
                foreach (var pl in response[0].home_team_statistics.substitutes)
                {
                    substitutions.Add((string)pl.name);
                    players.Add((string)pl.name, new PlayerInfo()
                    {

                        player_name = (string)pl.name,
                        player_number = (string)pl.shirt_number,
                        position = (string)pl.position,
                        is_captain = Convert.ToBoolean(pl.captain),
                        num_of_cards = 0,
                        num_of_goals = 0
                    });
                }

            }
            else
            {
                foreach (var pl in response[0].away_team_statistics.starting_eleven)
                {
                    firsteleven.Add((string)pl.name);
                    players.Add((string)pl.name, new PlayerInfo()
                    {

                        player_name = (string)pl.name,
                        player_number = (string)pl.shirt_number,
                        position = (string)pl.position,
                        is_captain = Convert.ToBoolean(pl.captain),
                        num_of_cards = 0,
                        num_of_goals = 0
                    });
                }
                foreach (var pl in response[0].away_team_statistics.substitutes)
                {
                    substitutions.Add((string)pl.name);
                    players.Add((string)pl.name, new PlayerInfo()
                    {

                        player_name = (string)pl.name,
                        player_number = (string)pl.shirt_number,
                        position = (string)pl.position,
                        is_captain = Convert.ToBoolean(pl.captain),
                        num_of_cards = 0,
                        num_of_goals = 0
                    });
                }
            }
            try
            {
                foreach (var match in response)
                {
                    matches.Add(new Match()
                    {
                        attendance = (string)match.attendance,
                        away_team = (string)match.away_team.country,
                        home_team = (string)match.home_team.country,
                        location = (string)match.location,
                        score = $"{match.home_team.goals}:{match.away_team.goals}",
                        winner = (string)match.winner,
                        id = (string)match.fifa_id
                    });
                    if (match.home_team.code == teamCode)
                    {
                        foreach (var ev in match.home_team_events)
                        {
                            if (ev.type_of_event == "goal")
                            {
                                players[(string)ev.player].num_of_goals++;
                                if (matches[matches.Count - 1].players.ContainsKey((string)ev.player))
                                {
                                    matches[matches.Count - 1].players[(string)ev.player].num_of_goals++;
                                }
                                else
                                {
                                    matches[matches.Count - 1].players.Add((string)ev.player, new PlayerInfo { num_of_goals = 1, num_of_cards = 0, player_name = ev.player });
                                }
                            }
                            else if (ev.type_of_event == "yellow-card")
                            {
                                players[(string)ev.player].num_of_cards++;
                                if (matches[matches.Count - 1].players.ContainsKey((string)ev.player))
                                {
                                    matches[matches.Count - 1].players[(string)ev.player].num_of_cards++;
                                }
                                else
                                {
                                    matches[matches.Count - 1].players.Add((string)ev.player, new PlayerInfo { num_of_goals = 0, num_of_cards = 1, player_name = (string)ev.player });
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var ev in match.away_team_events)
                        {
                            if (ev.type_of_event == "goal")
                            {
                                players[(string)ev.player].num_of_goals++;
                                if (matches[matches.Count - 1].players.ContainsKey((string)ev.player))
                                {
                                    matches[matches.Count - 1].players[(string)ev.player].num_of_goals++;
                                }
                                else
                                {
                                    matches[matches.Count - 1].players.Add((string)ev.player, new PlayerInfo { num_of_goals = 1, num_of_cards = 0, player_name = (string)ev.player });
                                }
                            }
                            else if (ev.type_of_event == "yellow-card")
                            {
                                players[(string)ev.player].num_of_cards++;
                                if (matches[matches.Count - 1].players.ContainsKey((string)ev.player))
                                {
                                    matches[matches.Count - 1].players[(string)ev.player].num_of_cards++;
                                }
                                else
                                {
                                    matches[matches.Count - 1].players.Add((string)ev.player, new PlayerInfo { num_of_goals = 0, num_of_cards = 1, player_name = ev.player });
                                }
                            }
                        }
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Typo in api..");
            }
            dynamic results = await Contributor.CountryMatchResults(teamName);

            goals_against = results.goals_against;
            goals_difference = results.goal_differential;
            goals_for = results.goals_for;
            wins = results.wins;
            losses = results.losses;
            draws = results.draws;
        }
    }
}
