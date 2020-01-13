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
    public static class Contributor
    {

        private const string RepUrl = "https://world-cup-json-2018.herokuapp.com/teams";
        private const string MatchesUrl = "https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        private const string ResultsUrl = "https://world-cup-json-2018.herokuapp.com/teams/results";

        public static async Task<string> GetUrl (string url)
        {
            var client = new RestClient(url);
            var response = await client.ExecuteTaskAsync(new RestRequest());

            return response.Content;
        }

        public static async Task<List<string>> ReprezentationNames()
        {
            dynamic response = JsonConvert.DeserializeObject(await Task.Run(() => GetUrl(RepUrl)));
            List<string> country = new List<string>();
            foreach (var s in response)
            {
                country.Add((string)s.country);
            }
            return country;
        }

        public static async Task<string> CountryFifaCode(string chosenTeam)
        {
            await GetUrl(RepUrl);
            dynamic response = JsonConvert.DeserializeObject(await Task.Run(() => GetUrl(RepUrl)));
            foreach (var s in response)
            {
                if (s.country == chosenTeam)
                {
                    return s.fifa_code;
                }
            }
            throw new System.ArgumentException($"Country: {chosenTeam} doesn't exist");
        }

        public static async Task<List<string>> GetMatchFirstEleven(string fifa_id, string fifa_code)
        {
            dynamic response = JsonConvert.DeserializeObject(await Task.Run(() => GetUrl(MatchesUrl + fifa_code)));
            List<string> starting_eleven = new List<string>();
            foreach (var match in response)
            {
                if (match.fifa_id == fifa_id)
                {

                    if (match.home_team.code == fifa_code)
                    {
                        foreach (var player in match.home_team_statistics.starting_eleven)
                        {
                            starting_eleven.Add((string)player.name);
                        }
                        return starting_eleven;
                    }
                    else
                    {
                        foreach (var player in match.away_team_statistics.starting_eleven)
                        {

                            starting_eleven.Add((string)player.name);
                        }
                        return starting_eleven;
                    }
                }
            }
            throw new ArgumentException("Problems fetching first eleven, maybe your fifa_id is wrong?");
        }

        public static async Task<dynamic> GetCountryMatches(string fifa_code)
        {
            return JsonConvert.DeserializeObject(await Task.Run(() => GetUrl(MatchesUrl + fifa_code)));
        }

        public static async Task<dynamic> CountryMatchResults(string countryName)
        {
            dynamic response = JsonConvert.DeserializeObject(await Task.Run(() => GetUrl(ResultsUrl)));
            foreach (var s in response)
            {
                if (s.country == countryName)
                {
                    return s;
                }
            }
            throw new ArgumentException($"Cant find {countryName} results");
        }

        /// <summary>
        /// Reads config file, returns List<string> [0] language | [1] name | [2] fav players(split with ,)
        /// </summary>
        public static List<string> ReadConfigFile()
        {
            List<string> r = File.ReadAllText(@"..\..\..\config.txt").Split('|').ToList();
            Console.WriteLine($"Found existing config file\n Language: {r[0]}\n Team: {r[1]} \nFavorite players: {r[2]}\n");
            return r;
        }

        /// <summary>
        /// Saves app data to config file
        /// </summary>
        public static void SaveDataToFile(Reprezentation r, string lng)
        {
            string favPlayers = "";
            foreach (var p in r.players)
            {
                if (p.Value.is_fav_player)
                {
                    favPlayers += p.Value.player_name + ",";
                }
            }
            favPlayers = favPlayers.Remove(favPlayers.Length - 1);

            FileStream fs = new FileStream(@"..\..\..\config.txt", FileMode.Create, FileAccess.Write, FileShare.Write);
            fs.Close();
            using (StreamWriter sw = new StreamWriter(@"..\..\..\config.txt", true, Encoding.ASCII))
            {
                sw.Write($"{lng}|{r.teamName}|{favPlayers}");
            }
            Console.WriteLine($"Wrote new config to config.txt\n{lng}|{r.teamName}|{favPlayers}");
        }
    }

}