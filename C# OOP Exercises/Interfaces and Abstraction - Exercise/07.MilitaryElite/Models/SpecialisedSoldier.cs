using System;
using System.Text;
using System.Collections.Generic;
using MilitaryElite.Exeptions;
using MilitaryElite.Enumerators;
using MilitaryElite.MilitaryInterfaces;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsExeptionMsg();
            }
            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"Corps: {this.Corps.ToString()}";
        }
    }
}