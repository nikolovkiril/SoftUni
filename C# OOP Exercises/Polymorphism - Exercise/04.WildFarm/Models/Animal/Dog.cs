using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        private const double GET_FAT_WITH = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncreaser => GET_FAT_WITH;

        public override ICollection<Type> EatingCertainFood => new List<Type> { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
