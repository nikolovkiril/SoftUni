using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    {
                        aquariums.Add(new FreshwaterAquarium(aquariumName));
                        break;
                    }
                case "SaltwaterAquarium":
                    {
                        aquariums.Add(new SaltwaterAquarium(aquariumName));
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
                        break;
                    }
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            switch (decorationType)
            {
                case "Ornament":
                    {
                        decorations.Add(new Ornament());
                        break;
                    }
                case "Plant":
                    {
                        decorations.Add(new Plant());
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
                        break;
                    }
            }
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorations.FindByType(decorationType) != null)
            {
                foreach (var aquarium in aquariums)
                {
                    if (aquarium.Name == aquariumName)
                    {
                        var decoration = decorations.FindByType(decorationType);
                        aquarium.AddDecoration(decoration);
                        decorations.Remove(decoration);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException
                (string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.First(n => n.Name == aquariumName);
            switch (fishType)
            {
                case "FreshwaterFish":
                    {
                        if (aquarium.GetType().Name != "FreshwaterAquarium")
                        {
                            return OutputMessages.UnsuitableWater;
                        }
                        aquarium.AddFish(new FreshwaterFish(fishName,fishSpecies,price));
                        break;
                    }
                case "SaltwaterFish":
                    {
                        if (aquarium.GetType().Name != "SaltwaterAquarium")
                        {
                            return OutputMessages.UnsuitableWater;
                        }
                        aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
                    }
            }

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            aquariums.First(n => n.Name == aquariumName).Feed();
            return string.Format(OutputMessages.FishFed, aquariums.First(n=>n.Name == aquariumName).Fish.Count);

        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            decimal sum = 0;
            foreach (var fish in aquarium.Fish)
            {
                sum += fish.Price;
            }

            sum += aquarium.Decorations.Sum(d => d.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
