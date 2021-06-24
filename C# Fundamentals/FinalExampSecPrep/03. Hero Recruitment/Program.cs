using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            var record = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commSplit = input.Split(" ");
                string firstComm = commSplit[0];
                string heroName = commSplit[1];
                if (firstComm == "Enroll")
                {
                    if (!record.ContainsKey(heroName))
                    {
                        record[heroName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (firstComm == "Learn")
                {
                    string spellName = commSplit[2];
                    if (record.ContainsKey(heroName))
                    {
                        if (!record[heroName].Contains(spellName))
                        {
                            record[heroName].Add(spellName);
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
                else if (firstComm == "Unlearn")
                {
                    string spellName = commSplit[2];
                    if (record.ContainsKey(heroName))
                    {
                        if (record[heroName].Contains(spellName))
                        {
                            record[heroName].Remove(spellName);
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
            foreach (var kvp in record.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"== {kvp.Key}: ");

                foreach (var item in kvp.Value)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }
    }
}
