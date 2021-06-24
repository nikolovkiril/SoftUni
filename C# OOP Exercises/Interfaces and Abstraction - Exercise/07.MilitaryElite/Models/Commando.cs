using MilitaryElite.MilitaryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMissions> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMissions>();
        }

        public IReadOnlyCollection<IMissions> Missions => (IReadOnlyCollection<IMissions>)this.missions;
        public void AddMission(IMissions mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}