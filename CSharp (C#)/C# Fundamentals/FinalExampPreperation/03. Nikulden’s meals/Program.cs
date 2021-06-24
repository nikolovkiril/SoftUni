using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> information = new Dictionary<string, List<string>>();
            string input;
            int count = 0;
            while (!(input = Console.ReadLine()).Contains("Stop"))
            {
                string[] commSplit = input.Split("-");
                string guest = commSplit[1];
                string meal = commSplit[2];
                if (commSplit[0] == "Like")
                {
                    if (!information.ContainsKey(guest))
                    {
                        information[guest] = new List<string>();
                        if (!information[guest].Contains(meal))
                        {
                            information[guest].Add(meal);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (information.ContainsKey(guest))
                    {
                        information[guest].Add(meal);
                    }
                }
                else if (commSplit[0] == "Unlike")
                {
                    
                    if (information.ContainsKey(guest))
                    {
                        if (!information[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else if (information[guest].Contains(meal))
                        {
                            information[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            count++;
                        }
                    }
                    else if (!information.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    
                }
            }
            foreach (var kvp in information.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                Console.Write($"{kvp.Key}: ");
                Console.Write(string.Join(", ",kvp.Value));
                Console.WriteLine();
            }
            Console.WriteLine($"Unliked meals: {count}");
        }
    }
}
