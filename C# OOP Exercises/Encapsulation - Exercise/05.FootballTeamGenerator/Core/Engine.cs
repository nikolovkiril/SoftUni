using FootballTeamGenerator.Comman;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }
        public void Run()
        {
            string comman;

            while ((comman = Console.ReadLine()) != "END")
            {
                try
                {
                    var tokens = comman.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (tokens[0] == "Team")
                    {
                        string teamInfo = tokens[1];
                        CreateTeam(teamInfo);
                    }
                    else if (tokens[0] == "Add")
                    {
                        AddPlayer(tokens);
                    }
                    else if (tokens[0] == "Remove")
                    {
                        RemovePlayer(tokens);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        PrintRating(tokens);
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);

                }
            }

        }
        private void RemovePlayer(string[] tokens)
        {
            string teamName = tokens[1];
            string playerName = tokens[2];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void AddPlayer(string[] playerInformation)
        {
            string teamToAdd = playerInformation[1];
            string playerNameToAdd = playerInformation[2];

            this.ValidateTeamExists(teamToAdd);

            Team team = this.teams.First(x => x.Name == teamToAdd);
            Stats stats = this.CreateStats(playerInformation.Skip(3).ToArray());

            Player player = new Player(playerNameToAdd, stats);
            team.AddPlayer(player);
            
        }
        private Stats CreateStats(string[] tokkens)
        {
            int endurance = int.Parse(tokkens[0]);
            int sprint = int.Parse(tokkens[1]);
            int dribble = int.Parse(tokkens[2]);
            int passing = int.Parse(tokkens[3]);
            int shooting = int.Parse(tokkens[4]);
            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;
        }
        private void PrintRating(string[] tokens)
        {
            string teamName = tokens[1];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }
        private void ValidateTeamExists(string name)
        {
            if (!this.teams.Any(t => t.Name == name))
            {
                throw new ArgumentException(String.Format(GlobalException.MissingTeamExceptionMessage, name));
            }
        }
        private void CreateTeam(string teamInformation)
        {
            string teamName = teamInformation;

            Team team = new Team(teamName);

            this.teams.Add(team);
        }
    }
}
