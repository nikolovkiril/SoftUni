using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        private int strength;
        private int ability;
        private int intelligence;

        public Item(int strength, int ability, int intelligence)
        {
            this.strength = strength;
            this.ability = ability;
            this.intelligence = intelligence;
        }
        public int Strength { get=>this.strength; set=>this.strength = value; }
        public int Ability { get => this.ability; set => this.ability = value; }
        public int Intelligence { get => this.intelligence; set => this.intelligence = value; }

        public override string ToString()
        {
            return $"Item:" + Environment.NewLine +
                   $"  * Strength: {strength}" + Environment.NewLine +
                   $"  * Ability: {ability}" + Environment.NewLine +
                   $"  * Intelligence: {intelligence}";
        }
    }
}
