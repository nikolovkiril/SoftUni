using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> trakedHeroes = new Dictionary<string, List<string>>();
            string input;
            while (!(input = Console.ReadLine()).Contains("End"))
            {
                string[] commSplit = input.Split(" ").ToArray();

                string heroName = commSplit[1];

                if (commSplit[0] == "Enroll")
                {
                    if (!trakedHeroes.ContainsKey(heroName))
                    {
                        trakedHeroes[heroName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (commSplit[0] == "Learn")
                {
                    if (trakedHeroes.ContainsKey(heroName))
                    {
                        string spellName = commSplit[2];
                        if (!trakedHeroes[heroName].Contains(spellName))
                        {
                            trakedHeroes[heroName].Add(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
                else if (commSplit[0] == "Unlearn")
                {
                    string spellName = commSplit[2];

                    if (trakedHeroes.ContainsKey(heroName))
                    {
                        if (trakedHeroes[heroName].Contains(spellName))
                        {
                            trakedHeroes[heroName].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
            }
            Console.WriteLine("Heroes:");
            foreach (var item in trakedHeroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"== {item.Key}:");
                foreach (var kvp in item.Value)
                {
                    Console.Write($" {kvp}");
                }
                Console.WriteLine();
            }
        }
    }
}
