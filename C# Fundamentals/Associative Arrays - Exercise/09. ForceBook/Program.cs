using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] commSplit = input.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Contains("|"))
                {
                    string side = commSplit[0];
                    string user = commSplit[1];
                    if (!catalog.ContainsKey(side))
                    {
                        catalog[side] = new List<string>();
                    }
                    if (!catalog.Values.Any(l => l.Contains(user)))
                    {
                        catalog[side].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    string user = commSplit[0];
                    string side = commSplit[1];
                    foreach (var item in catalog)
                    {
                        if (item.Value.Contains(user))
                        {
                            item.Value.Remove(user);
                        }
                        if (!catalog.ContainsKey(side))
                        {
                            catalog[side] = new List<string>();
                            catalog[side].Add(user);
                        }
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }
            }
            Dictionary<string, List<string>> currectCatalog = catalog
                .Where(c => c.Value.Count > 0)
                .OrderByDescending(c => c.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var item in currectCatalog)
            {
                string side = item.Key;
                List<string> user = item.Value.OrderBy(x => x).ToList();
                Console.WriteLine($"Side: { side}, Members: {user.Count}");
                foreach (var kvp in user)
                {
                    Console.WriteLine($"! {kvp}");
                }
            }
        }
    }
}
