using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WildFarm.Core.Engine.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animal;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Core.Engine
{
    public class IEngine : IEngiine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;
        public IEngine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                
                var animalsArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                IAnimal animal = CreateAnimal(animalsArgs);

                var foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();                
                IFood food = this.foodFactory.CreateFood(foodArgs);
                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (IAnimal animal1 in this.animals)
            {
                //Console.WriteLine(animal1.ProduceSound());
                Console.WriteLine(animal1);
            }
        }

        private IAnimal CreateAnimal(string[] animalsArgs)
        {
            string type = animalsArgs[0];
            string name = animalsArgs[1];
            double weight = double.Parse(animalsArgs[2]);
            IAnimal animal = null;
            if (type == "Owl")
            {
                double wingSize = double.Parse(animalsArgs[3]);
                animal = new Owl(name, weight, wingSize);
                animals.Add(animal);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalsArgs[3]);
                animal = new Hen(name, weight, wingSize);
                animals.Add(animal);
            }
            else if (type == "Mouse")
            {
                string livingRegion = animalsArgs[3];
                animal = new Mouse(name, weight, livingRegion);
                animals.Add(animal);
            }
            else if (type == "Dog")
            {
                string livingRegion = animalsArgs[3];
                animal = new Dog(name, weight, livingRegion);
                animals.Add(animal);
            }
            else if (type == "Cat")
            {
                string livingRegion = animalsArgs[3];
                string breed = animalsArgs[4];
                animal = new Cat(name, weight, livingRegion, breed);
                animals.Add(animal);
            }
            else if (type == "Tiger")
            {
                string livingRegion = animalsArgs[3];
                string breed = animalsArgs[4];
                animal = new Tiger(name, weight, livingRegion, breed);
                animals.Add(animal);
            }

            return animal;
        }
    }
}
