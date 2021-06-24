using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;
        private string repository;
        public int Count => this.data.Count;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }
        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }
        public void Remove(string name)
        {
            this.data = this.data.Where(n => n.Name != name).ToList();
        }
        public Hero GetHeroWithHighestStrength()
        {
            var highestStrength = this.data.OrderByDescending(x => x.Item.Strength).First();
            return highestStrength;
        }
        public Hero GetHeroWithHighestAbility()
        {
            var heroWithHighestAbility = this.data.OrderByDescending(x => x.Item.Ability).First();
            return heroWithHighestAbility;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var heroWithHighestIntelligence = this.data.OrderByDescending(x => x.Item.Intelligence).First();
            return heroWithHighestIntelligence;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in data)
            {
                sb.Append(hero);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();

        }
    }
}
