using PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                string[] doughInfo = Console.ReadLine().Split();

                Dough dough = CreateDough(doughInfo);               

                Pizza  pizza = CreatePizza(pizzaInfo, dough);

                string comman;
                while ((comman = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = comman.Split();

                    Toppings topping = CreateTopping(toppingInfo);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private Pizza CreatePizza(string[] pizzaInfo, Dough dough)
        {
            string pizzaName = pizzaInfo[1];

            Pizza pizza = new Pizza(pizzaName, dough);

            return pizza;
        }

        private Toppings CreateTopping(string[] toppingInformation)
        {
            string toppingType = toppingInformation[1];
            double toppingWeight = double.Parse(toppingInformation[2]);

            Toppings topping = new Toppings(toppingType, toppingWeight);

            return topping;
        }

        private Dough CreateDough(string[] doughInformation)
        {
            string flourType = doughInformation[1];
            string bakingTechnique = doughInformation[2];
            double flourWeight = double.Parse(doughInformation[3]);

            Dough dough = new Dough(flourType, bakingTechnique, flourWeight);

            return dough;
        }
    }
}