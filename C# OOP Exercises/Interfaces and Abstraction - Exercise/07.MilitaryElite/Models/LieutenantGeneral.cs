using MilitaryElite.Interfaces;
using MilitaryElite.MilitaryInfo;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldiers> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldiers>();
        }

        public IReadOnlyCollection<ISoldiers> Privates => (IReadOnlyCollection<IPrivate>)this.privates;
        public void AddPrivate(ISoldiers @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var soldier in this.privates)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}