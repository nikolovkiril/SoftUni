using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get;  }
        int FoodEaten { get; }
        void Feed(IFood food);
        string ProduceSound();

    }
}
