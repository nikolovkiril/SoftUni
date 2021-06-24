using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainerList = new List<Trainer>();
            string information;

            while ((information = Console.ReadLine()) != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                var tokens = information.Split();

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                if (!trainerList.Any(t => t.Name == trainerName))
                {
                    trainerList.Add(new Trainer(trainerName));
                }
                var trainer = trainerList.First(t => t.Name == trainerName);
                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            string elements;
            while ((elements = Console.ReadLine()) != "End")
            {
                //For every command you must check if a trainer has at least 1 pokemon with the given element
                //    .If he does, he receives 1 badge.Otherwise, all of his pokemon lose 10 health.
                //    If a pokemon falls to 0 or less health, he dies and must be deleted from the trainer’s collection. 
                //    In the end, you should print all of the trainers, sorted by the amount of badges they have in 
                //    descending order(if two trainers have the same amount of badges, 
                //    they should be sorted by order of appearance in the input) in the format: 
                foreach (var trainer in trainerList)
                {
                    if (trainer.Pokemons.Any(t => t.Element == elements))
                    {
                        trainer.NnumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(t => t.Health -= 10);
                    }

                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }
            trainerList = trainerList.OrderByDescending(t => t.NnumberOfBadges).ToList();
            foreach (var trainer in trainerList)
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
