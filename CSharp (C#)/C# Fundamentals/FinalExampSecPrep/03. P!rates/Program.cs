using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            var citiesPop = new Dictionary<string, long>();
            var citiesGold = new Dictionary<string, long>();
            string firstInput;

            var sum = 0;
            while ((firstInput = Console.ReadLine()) != "Sail")
            {
                AddAndSumCities(citiesPop, citiesGold, firstInput);
            }
            string secInput;
            while ((secInput = Console.ReadLine()) != "End")
            {
                string[] secSplit = secInput.Split("=>".Trim());
                string command = secSplit[0];
                string town = secSplit[1];
                if (command == "Plunder")
                {
                    int peopleKilled = int.Parse(secSplit[2]);
                    int gold = int.Parse(secSplit[3]);
                    citiesPop[town] -= peopleKilled;
                    citiesGold[town] -= gold;
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {peopleKilled} citizens killed.");

                    if (citiesPop[town] <= 0 || citiesGold[town] <= 0)
                    {
                        citiesGold.Remove(town);
                        citiesPop.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                    
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(secSplit[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        citiesGold[town] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {citiesGold[town]} gold.");
                    }

                }
            }
            if (citiesPop.Any())
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesPop.Count} wealthy settlements to go to:");
            }
            else 
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            foreach (var kvp in citiesGold.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> Population: {citiesPop[kvp.Key]} citizens, Gold: {kvp.Value} kg");
            }
        }


        private static void AddAndSumCities(Dictionary<string, long> citiesPop, Dictionary<string, long> citiesGold, string firstInput)
        {
            string[] splitFirst = firstInput.Split("||", StringSplitOptions.RemoveEmptyEntries);
            string name = splitFirst[0];
            long population = int.Parse(splitFirst[1]);
            long gold = int.Parse(splitFirst[2]);
            if (!citiesPop.ContainsKey(name))
            {
                citiesPop[name] = population;
                citiesGold[name] = gold;
            }
            else
            {
                citiesPop[name] += population;
                citiesGold[name] += gold;
            }
        }
    }
}
