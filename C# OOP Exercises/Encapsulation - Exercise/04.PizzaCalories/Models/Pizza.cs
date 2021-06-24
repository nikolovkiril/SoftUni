using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const int TOPPINGS_MAX_COUNT = 10;
        private const int PIZZA_MAX_NAME_SIZE = 15;
        private const int PIZZA_MIN_NAME_SIZE = 1;

        private string name;
        private readonly List<Toppings> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Toppings>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length > PIZZA_MAX_NAME_SIZE ||
                    value.Length < PIZZA_MIN_NAME_SIZE)
                {
                    throw new ArgumentException(GlobalException.Exceptions.InvalidPizzaNameExceptionMessage);
                }

                name = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                return toppings.Sum(t => t.GetCaloriesPerGram) + Dough.GetCaloriesPerGram;
            }
        }

        public Dough Dough { get; private set; }

        public void AddTopping(Toppings topping)
        {
            if (toppings.Count == TOPPINGS_MAX_COUNT)
            {
                throw new ArgumentException(GlobalException.Exceptions.InvalidNumberOfToppingsExceptionMessage);
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}