using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private string name;
        private int capacity;
        private List<Rabbit> rabbits;

        public int Count => this.rabbits.Count;

        public Cage(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            this.rabbits = new List<Rabbit>(this.Capacity);
        }
        public int Capacity { get=>this.capacity; set=> this.capacity = value; }
        public string Name { get=>this.name; set=> this.name = value; }

        public Rabbit SellRabbit(string name)
        {
            var rabbitToSell = this.rabbits.FirstOrDefault(x => x.Name == name);
            rabbitToSell.Available = false;
            return rabbitToSell;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var filtered = this.rabbits
                .Where(r => r.Species == species)
                .ToArray();

            foreach (var rabbit in filtered)
            {
                rabbit.Available = false;
            }

            return filtered;
        }
        public void Add(Rabbit rabbit)
        {
            if (capacity > Count)
            {
               this.rabbits.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            int removed = this.rabbits.RemoveAll(r => r.Name == name);
            if (removed > 0)
            {
                return true;
            }

            return false;

        }
        public void RemoveSpecies(string species)
        {
            this.rabbits.RemoveAll(x => x.Species == species);               
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.rabbits)
            {
                if (rabbit.Available)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }

}
