using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {
        private string name;
        private string species;
        private bool available; //true by default
        public Rabbit(string name, string species)
        {
            this.name = name;
            this.species = species;
            this.available = true;
        }
        public string Name { get=> this.name; set=>this.name = value; }
        public string Species { get => this.species; set => this.species = value; }
        public bool Available { get => this.available; set => this.available = value; }
        public override string ToString()
        {
            return $"Rabbit ({species}): {name}";
            
        }
    }
}
