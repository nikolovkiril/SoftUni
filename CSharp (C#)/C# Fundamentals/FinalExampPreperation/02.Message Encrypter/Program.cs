using System;
using System.Text.RegularExpressions;

namespace _02.Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"([@|*])(?<tag>[A-Z][a-z]{2,})\1:\s?\[(?<letter1>[A-Z]|[a-z])\]\|\[(?<sec>[A-Z]|[a-z])\]\|\[(?<third>[A-Z]|[a-z])\]\|$";

            int numOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfInput; i++)
            {
                string command = Console.ReadLine();
                Match resut = Regex.Match(command, regex);
                string letter = resut.Groups[""].Value;
                string letter1 = resut.Groups["sec"].Value;
                string letter2 = resut.Groups["third"].Value;
                string tag = resut.Groups["tag"].Value;
                if (resut.Success)
                {
                    char num = char.Parse(letter);
                    char num1 = char.Parse(letter1);
                    char num2 = char.Parse(letter2);
                    
                    Console.WriteLine($"{tag}: {(int)num} {(int)num1} {(int)num2} ");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
