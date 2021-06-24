using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Factories
{
    class FoodFactory
    {
        public IFood CreateFood (string[] foodArgs)
        {
            string type = foodArgs[0];
            int quantity =int.Parse(foodArgs[1]);
            IFood food = null;
            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
