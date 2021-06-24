using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> information = new Dictionary<string, List<int>>();

            string input;
            while (!(input=Console.ReadLine()).Contains("Log out"))
            {
                string[] commSplit = input.Split(":",StringSplitOptions.RemoveEmptyEntries);
                string username = commSplit[1];

                if (commSplit[0] == "New follower")
                {
                    if (!information.ContainsKey(username))
                    {
                        information[username] = new List<int>();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commSplit[0] == "Like")
                {
                    int count =int.Parse(commSplit[2]);
                    if (!information.ContainsKey(username))
                    {
                        information[username] = new List<int>();
                        information[username].Add(count);
                    }
                    else
                    {
                        information[username].Add(count);
                    }
                }
                else if (commSplit[0] == "Comment")
                {
                    if (!information.ContainsKey(username))
                    {
                        information[username] = new List<int>();
                        information[username].Add(1);
                    }
                    else
                    {
                        information[username].Add(1);
                    }

                }
                else if (commSplit[0] == "Blocked")
                {
                    if (information.ContainsKey(username))
                    {
                        information.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");                
                    }
                }
            }
            int sum = information.Count;
            Console.WriteLine($"{sum} followers");
            foreach (var kvp in information.OrderByDescending(x => x.Value.Sum()).ThenBy(x => x.Key))
            {
                Console.Write($"{kvp.Key}: ");
                Console.WriteLine(string.Join("", kvp.Value.Sum()));
            }
        }
    }
}
