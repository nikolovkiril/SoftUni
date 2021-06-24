using Raiding.Core.Contracts;
using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding.Core
{

    public class Engine : IEngine
    {
        private ICollection<BaseHero> baseHeroes;
        public Engine()
        {
            baseHeroes = new List<BaseHero>();
        }

        public void Run()
        {
            int counter = 0;
            int inputLenght = int.Parse(Console.ReadLine());

            while (inputLenght != counter)
            {
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();
                try
                {
                    BaseHero hero = FactoryHeroes.CreateHero(typeHero, name);
                    baseHeroes.Add(hero);
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            double bossPower = double.Parse(Console.ReadLine());

            foreach (var hero in baseHeroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int sum = baseHeroes.Sum(h => h.Power);

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
