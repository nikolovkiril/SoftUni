using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.CustomExceptions;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Owl : Bird
    {
        private const double GET_FAT_WITH = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightIncreaser => GET_FAT_WITH;

        public override ICollection<Type> EatingCertainFood => new List<Type> { typeof(Food.Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
