using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace PizzaCalories.Models
{
    public class Toppings
    {
        private const int BASE_CALORIES_PER_GRAM = 2;
        private const int TOPPING_MIN_VALUE = 1;
        private const int TOPPING_MAX_VALUE = 50;

        private string type;
        private double weight;

        public Toppings(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get => this.type;
            private set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format
                    (GlobalException.Exceptions.InvalidToppingTypeExceptionMessage, value));
                }

                this.type = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < TOPPING_MIN_VALUE || value > TOPPING_MAX_VALUE)
                {
                    throw new ArgumentException(string.Format
                    (GlobalException.Exceptions.InvalidWeightOfToppingExceptionMessage, this.Type));
                }

                this.weight = value;
            }
        }
        public double GetCaloriesPerGram => this.CalculateCalories();

        private double CalculateCalories()
        {
            double toppingModifier = CalculateToppingModifier();

            double totalCalories = BASE_CALORIES_PER_GRAM * this.Weight * toppingModifier;

            return totalCalories;
        }

        private double CalculateToppingModifier()
        {
            double toppingModifier = 0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    toppingModifier = 1.2;
                    break;
                case "veggies":
                    toppingModifier = 0.8;
                    break;
                case "cheese":
                    toppingModifier = 1.1;
                    break;
                case "sauce":
                    toppingModifier = 0.9;
                    break;
            }

            return toppingModifier;
        }
    }
}