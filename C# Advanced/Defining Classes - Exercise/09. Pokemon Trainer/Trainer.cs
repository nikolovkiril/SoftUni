using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;
        //All values are mandatory. Every Trainer starts with 0 badges.
        public Trainer(string name)
        {
            this.Name = name;
            this.NnumberOfBadges = 0;
            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get => this.name; set => this.name = value; }
        public int NnumberOfBadges { get => this.numberOfBadges; set => this.numberOfBadges = value; }
        public List<Pokemon> Pokemons { get => this.pokemons; set => this.pokemons = value; }

        public override string ToString()
        {
            return $"{Name} {numberOfBadges} {Pokemons.Count}";
        }
    }
}
