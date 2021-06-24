using FootballTeamGenerator.Comman;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        
        private const int OVERALL_SKILL_LEVEL = 0; // To check 

        private string name;
        private List<Stats> stats;
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public Stats Stats{ get; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(GlobalException.InvalidTeamNameExceptionMessage));
                }
               this.name = value;
            }
        }

        public double OverallSkill => this.Stats.AverageStats;
    }
}
