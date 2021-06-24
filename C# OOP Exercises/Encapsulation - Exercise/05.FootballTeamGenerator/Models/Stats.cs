using FootballTeamGenerator.Comman;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MIN_STATS_RANGE = 0;
        private const int MAX_STATS_RANGE = 100;

        private const double STATS_COUNT = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get => this.endurance;
            set
            {
                this.ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            set
            {
                this.ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            set
            {
                this.ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }
        public double AverageStats => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / STATS_COUNT;
        private void ValidateStat(int value, string statName)
        {
            if (value < MIN_STATS_RANGE || MAX_STATS_RANGE < value)
            {
                string aeMsg = String.Format(GlobalException.InvalidTypeOfStatsExceptionMessage, statName, MIN_STATS_RANGE, MAX_STATS_RANGE);
                throw new ArgumentException(aeMsg);
            }
        }
    }

}
