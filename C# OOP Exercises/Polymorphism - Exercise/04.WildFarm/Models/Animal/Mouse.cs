using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Mouse : Mammal
    {
        private const double GET_FAT_WITH = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncreaser => GET_FAT_WITH;

        public override ICollection<Type> EatingCertainFood => new List<Type> { typeof(Vegetable),typeof(Fruit)};

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
