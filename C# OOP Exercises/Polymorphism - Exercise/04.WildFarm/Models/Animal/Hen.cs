using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.CustomExceptions;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        private const double GET_FAT_WITH = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightIncreaser => GET_FAT_WITH;

        public override ICollection<Type> EatingCertainFood =>
            new List<Type> { typeof(Fruit), typeof(Meat), typeof(Seeds),typeof(Vegetable) }; 

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
