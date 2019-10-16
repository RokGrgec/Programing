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

        private const string TeamsUrl = "https://world-cup-json-2018.herokuapp.com/teams";
        private const string MatchesUrl = "https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        private const string ResultsUrl = "https://world-cup-json-2018.herokuapp.com/teams/results";

        public static async Task<string> GetUrl (string url)
        {
            var client = new RestClient(url);
            var response = await client.ExecuteTaskAsync(new RestRequest());

            return response.Content;
        }

        public static async Task<List<string>> TeamNames()
        {
            dynamic response = JsonConvert.DeserializeObject(await Task.Run(() => GetUrl(TeamsUrl)));
            List<string> country = new List<string>();
            foreach (var s in response)
            {
                country.Add((string)s.country);
            }
            return country;
        }

        public static async Task<string> CountryFifaCode(string chosenTeam)
        {
            await GetUrl(TeamsUrl);
            dynamic response = JsonConvert.DeserializeObject(await Task.Run(() => GetUrl(TeamsUrl)));
            foreach (var s in response)
            {
                if (s.fifa_code == chosenTeam)
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


    }

}