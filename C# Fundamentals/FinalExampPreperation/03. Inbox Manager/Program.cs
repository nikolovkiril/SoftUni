using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> userEmail = new Dictionary<string, List<string>>();

            string input;
            int count = 0;
          

            while (!(input = Console.ReadLine()).Contains("Statistics"))
            {
                string[] commSplit = input.Split("->",StringSplitOptions.RemoveEmptyEntries);
                if (commSplit[0] == "Add")
                {
                    string name = commSplit[1];
                    if (!userEmail.ContainsKey(name))
                    {
                        userEmail[name] = new List<string>();
                    }   
                    else
                    {
                        Console.WriteLine($"{name} is already registered");
                    }
                }
                else if (commSplit[0] == "Send")
                {
                    string name = commSplit[1];
                    string email = commSplit[2];
                    if (userEmail.ContainsKey(name))
                    {
                        userEmail[name].Add(email);
                    }
                }
                else if (commSplit[0] == "Delete")
                {
                    string name = commSplit[1];
                    if (userEmail.ContainsKey(name))
                    {
                        userEmail.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} not found!");
                    }
                }
            }
            for (int i = 0; i < userEmail.Count; i++)
            {
                count++;
            }
            Console.WriteLine($"Users count: {count}");
            foreach (var kvp in userEmail.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($" - {item}");
                }
            }
        }
    }
}
