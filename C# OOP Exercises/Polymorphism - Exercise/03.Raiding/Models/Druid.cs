using System;
using System.Text;
using Raiding.Models.Contracts;
using System.Collections.Generic;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int HERO_POWER = 80;

        public Druid(string name) 
            : base(name,HERO_POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
