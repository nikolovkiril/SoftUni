using System;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int inpNum =int.Parse(Console.ReadLine());

            for (int i = 0; i < inpNum; i++)
            {
                string command = Console.ReadLine();
                string regex = @"^(.+)>(?<numbers>\d{3})\|(?<lower>\w{3})\|(?<upper>\w{3})\|(?<symbols>[^<>]{3})<\1$";
                Match result = Regex.Match(command, regex);
                string numbers = result.Groups["numbers"].Value;
                string lower = result.Groups["lower"].Value;
                string upper = result.Groups["upper"].Value;
                string symbols = result.Groups["symbols"].Value;
                if (result.Success)
                {
                    Console.WriteLine($"Password: {numbers}{lower}{upper}{symbols}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
                
            }

        }
    }
}
