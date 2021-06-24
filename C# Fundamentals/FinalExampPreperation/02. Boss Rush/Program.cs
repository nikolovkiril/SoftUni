using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberBosses = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberBosses; i++)
            {
                string input = Console.ReadLine().Trim();
                string regex = @"\|(?<bossname>[A-Z]{4,})\|:#(?<title>[A-Za-z]+\s{1}[A-Za-z]*)#";
                Match result = Regex.Match(input, regex);
                string bossName = result.Groups["bossname"].Value;
                string title = result.Groups["title"].Value;
                if (bossName.Length > 0 && title.Length > 0)
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
