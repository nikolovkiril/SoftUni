using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }
        public int Comfort { get => this.decorations.Sum(d => d.Comfort); }
        public ICollection<IDecoration> Decorations => this.decorations;
        public ICollection<IFish> Fish => this.fish;
        public void AddFish(IFish fish)
        {
            if (this.Capacity <= this.fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var fishName = new List<string>();
            foreach (var fishInAq in this.Fish)
            {
                fishName.Add(fishInAq.Name);
            }

            string fish = this.Fish.Count > 0 ? string.Join(", ", fishName) : "none";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fish}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }
    }
}
