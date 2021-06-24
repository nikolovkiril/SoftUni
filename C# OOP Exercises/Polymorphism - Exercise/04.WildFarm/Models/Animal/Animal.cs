using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.CustomExceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name , double weight )
        {
            this.Name = name;
            this.Weight = weight;

        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public void Feed(IFood food)
        {
            if (!this.EatingCertainFood.Contains(food.GetType()))
            {
                throw new Exception
                    (string.Format(ExceptionMsg.DOESNT_EAT_MSG, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += this.WeightIncreaser * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        //Abstract Becouse they are different for every animal
        public abstract string ProduceSound();

        public abstract double WeightIncreaser { get; }
        public abstract ICollection<Type> EatingCertainFood { get;  }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
