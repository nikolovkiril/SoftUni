using System;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfComm = int.Parse(Console.ReadLine());
            string regex = @"([|])(?<boss>[A-Z]{4,})\1\:[#](?<title>[A-Za-z]+\s{1}[A-Za-z]+)[#]";

            for (int i = 0; i < numOfComm; i++)
            {
                string command = Console.ReadLine().Trim();

                Match result = Regex.Match(command, regex);
                string bossName = result.Groups["boss"].Value;
                string title = result.Groups["title"].Value;
                if (result.Success)
                {
                    Console.WriteLine($"{bossName}, The {title}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
