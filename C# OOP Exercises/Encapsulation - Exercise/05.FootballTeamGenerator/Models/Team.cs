using FootballTeamGenerator.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(GlobalException.InvalidTeamNameExceptionMessage));
                }
                name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                var overall = Math.Round(this.players.Sum(p => p.OverallSkill) / this.players.Count);
                return (int)overall;
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);
            if (playerToRemove == null)
            {
                string ioeMsg = String.Format(GlobalException.RemovingMessingPlayerExceptionMessage, name, this.Name);

                throw new InvalidOperationException(ioeMsg);
            }

            this.players.Remove(playerToRemove);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

    }
}
