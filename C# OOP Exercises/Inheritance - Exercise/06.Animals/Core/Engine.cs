using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals.Core
{
    public class Engine
    {
        private readonly List<Animal> animalss;
        public Engine()
        {
            this.animalss = new List<Animal>();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                var type = input;
                var animal = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = animal[0];
                int age = int.Parse(animal[1]);
                Animal animals;

                try
                {

                    switch (type)
                    {
                        case "Dog":
                            animals = new Dog(name, age, animal[2]);
                            break;
                        case "Cat":
                            animals = new Cat(name, age, animal[2]);
                            break;
                        case "Frog":
                            animals = new Frog(name, age, animal[2]);
                            break;
                        case "Kittens":
                            animals = new Cat(name, age, animal[2]);
                            break;
                        case "Tomcat":
                            animals = new Cat(name, age, animal[2]);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                this.animalss.Add(animals);

            }
            foreach (Animal anim in this.animalss)
            {
                Console.WriteLine(anim);
            }
        }
    }
}