using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, double>();

            string[] players = Console.ReadLine()
                .Split(", ");

            foreach (string player in players)
            {
                if (!dict.ContainsKey(player))
                {
                    dict[player] = 0;
                }
            }
            string input;

            while (!(input = Console.ReadLine()).Contains("end of race"))
            {
                string name = "";
                int total = 0;


                Regex regex = new Regex(@"[A-Za-z]");
                MatchCollection result = regex.Matches(input);

                foreach (Match letter in result)
                {
                    name += letter.Value;
                }
                if (dict.ContainsKey(name))
                {
                    MatchCollection matchesForDistance = Regex.Matches(input, @"[0-9]");

                    foreach (Match item in matchesForDistance)
                    {
                        total += int.Parse(item.Value);
                    }

                    dict[name] += total;
                }
               
            }
            int counter = 1;
            dict = dict.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach (var kvp in dict)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {kvp.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {kvp.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {kvp.Key}");
                }
                else
                {
                    break;
                }
                counter++;
            }
        }
    }
}
