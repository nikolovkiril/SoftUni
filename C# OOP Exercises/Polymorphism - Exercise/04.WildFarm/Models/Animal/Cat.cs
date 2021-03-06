using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        private const double GET_FAT_WITH = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightIncreaser => GET_FAT_WITH;

        public override ICollection<Type> EatingCertainFood => new List<Type> { typeof(Meat) , typeof(Vegetable) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
