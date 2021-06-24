using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestWithPassword = new Dictionary<string, string>();
            var contest = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                var inputSplit = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = inputSplit[0];
                string password = inputSplit[1];
                contestWithPassword[contestName] = password;
            }
            string secInput;
            while ((secInput = Console.ReadLine()) != "end of submissions")
            {
                var secSplit = secInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestToCheck = secSplit[0];
                string passwordToCheck = secSplit[1];
                string username = secSplit[2];
                int points = int.Parse(secSplit[3]);

                //⦁	Check if the contest is valid (if you received it in the first type of input)
                //⦁	Check if the password is correct for the given contest
                if (contestWithPassword.ContainsKey(contestToCheck) &&
                    contestWithPassword[contestToCheck].Contains(passwordToCheck))
                {
                    if (!contest.ContainsKey(username))
                    {
                        contest[username] = new Dictionary<string, int>();
                        contest[username].Add(contestToCheck, points);
                    }
                    else if (contest.ContainsKey(username))
                    {
                        if (!contest[username].ContainsKey(contestToCheck))
                        {
                            contest[username].Add(contestToCheck, points);
                        }

                        if (contest[username][contestToCheck] < points)
                        {
                            contest[username][contestToCheck] = points;
                        }
                    }
                    else
                    {                        
                        if (contest[username][contestToCheck] < points)
                        {
                            contest[username][contestToCheck] = points;
                        }
                    }
                }
            }
            Dictionary<string, int> usersTootalPoints = new Dictionary<string, int>();
            foreach (var kvp in contest)
            {
                usersTootalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            int maxPoints = usersTootalPoints
                .Values
                .Max();
            
            foreach (var kvp in usersTootalPoints)
            {
                if (kvp.Value == maxPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }
            Console.WriteLine("Ranking:");
            foreach (var (name, course) in contest.OrderBy(x => x.Key))
            {
                Console.WriteLine(name);
                foreach (var item in course.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
