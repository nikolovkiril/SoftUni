using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        private string name;
        private int level;
        private Item item;

        public Hero(string name, int level, Item item)
        {
            this.name = name;
            this.level = level;
            this.item = item;
        }
        public string Name { get => this.name; set => this.name = value; }
        public int Level { get => this.level; set => this.level = value; }
        public Item Item{ get => this.item; set => this.item = value; }
            
        public override string ToString()
        {
            return $"Hero: {name} – {level}lvl" + Environment.NewLine +
                   $"Item:" + Environment.NewLine +
                   $"  * Strength: {item.Strength}" + Environment.NewLine +
                   $"  * Ability: {item.Ability}" + Environment.NewLine +
                   $"  * Intelligence: {item.Intelligence}";
            ;
        }
    }
}
