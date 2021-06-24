using System;
using System.Text.RegularExpressions;

namespace _02.Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"^([$|%])(?<tag>[A-Z][a-z]{2,})\1:\s?\[(?<num1>[\d]+)\]\|\[(?<num2>[\d]+)\]\|\[(?<num3>[\d]+)\]\|$";

            int numOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfInput; i++)
            {
                string command = Console.ReadLine();
                Match resut = Regex.Match(command, regex);
                string tag = resut.Groups["tag"].Value;
                string num1 = resut.Groups["num1"].Value;
                string num2 = resut.Groups["num2"].Value;
                string num3 = resut.Groups["num3"].Value;
                if (resut.Success)
                {
                    int res1 = int.Parse(num1);
                    int res2 = int.Parse(num2);
                    int res3 = int.Parse(num3);

                    Console.WriteLine($"{tag}: {(char)res1}{(char)res2}{(char)res3} ");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
