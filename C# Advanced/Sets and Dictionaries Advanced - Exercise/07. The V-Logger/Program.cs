using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vLogger = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commSplit = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commSplit[0];
                string command = commSplit[1];

                if (command == "joined")
                {
                    if (!vLogger.ContainsKey(name))
                    {
                        vLogger.Add(name, new Dictionary<string, HashSet<string>>());
                        vLogger[name].Add("followers", new HashSet<string>());
                        vLogger[name].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string followed = commSplit[2];
                    if (name != followed && vLogger.ContainsKey(name) && vLogger.ContainsKey(followed))
                    {
                        vLogger[name]["following"].Add(followed);
                        vLogger[followed]["followers"].Add(name);
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");
            int position = 1;
            foreach (var vlogger in vLogger.OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{position}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (position == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                position++;
            }
        }
    }
}

