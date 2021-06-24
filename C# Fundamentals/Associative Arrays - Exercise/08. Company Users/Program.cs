using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {

            var company = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commSplit = input.Split(" -> ");
                string com = commSplit[0];
                string value = commSplit[1];
                if (!company.ContainsKey(com))
                {
                    company[com] = new List<string>();
                }
                if (!company[com].Contains(value))
                {
                    company[com].Add(value);
                }
            }
            foreach (var item in company.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}
