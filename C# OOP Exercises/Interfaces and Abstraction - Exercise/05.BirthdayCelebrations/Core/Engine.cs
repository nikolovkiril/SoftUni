using BorderControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly List<IBirthdates> birthdates;
        public Engine()
        {
            this.birthdates = new List<IBirthdates>();
        }
        public void Run()
        {
            var comman = string.Empty;

            while ((comman = Console.ReadLine()) != "End")
            {
                var tokens = comman.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var identity = tokens[0];

                if (identity == "Citizen")
                {
                    this.CreateCitizen(tokens);
                }
                else if (identity == "Pet")
                {
                    this.CreatePet(tokens);
                }
                else
                {
                    this.CreateRobot(tokens);
                }
            }

            var date = Console.ReadLine();

            birthdates.Where(c => c.Birthdates.EndsWith(date))
                .Select(c => c.Birthdates)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private void CreateCitizen(string[] tokens)
        {
            var name = tokens[1];
            var age = int.Parse(tokens[2]);
            var id = tokens[3];
            var bDay = tokens[4];

            var citizen = new Citizen(name, age, id, bDay);

            birthdates.Add(citizen);

        }

        private void CreatePet(string[] tokens)
        {
            var name = tokens[1];
            var bDay = tokens[2];

            var pet = new Pet(name, bDay);

            birthdates.Add(pet);

        }

        private void CreateRobot(string[] tokens)
        {
            var name = tokens[0];
            var id = tokens[1];

            var robot = new Robot(name, id);

        }
    }
}