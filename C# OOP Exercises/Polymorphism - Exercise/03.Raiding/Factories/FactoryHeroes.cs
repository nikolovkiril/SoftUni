using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class FactoryHeroes
    {
        public static BaseHero CreateHero(string heroType, string name)
        {
            BaseHero baseHero;

            if (heroType == "Druid")
            {
                baseHero = new Druid(name);
            }
            else if (heroType == "Paladin")
            {
                baseHero = new Paladin(name);
            }
            else if (heroType == "Rogue")
            {
                baseHero = new Rogue(name);
            }
            else if(heroType == "Warrior")
            {
                baseHero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }
            return baseHero;
        }
    }
}
