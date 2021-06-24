using System;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int inpNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inpNum; i++)
            {
                string inputMassage = Console.ReadLine();
                string regex = @"[!](?<command>[A-Z][a-z]{2,})[!]:[\[](?<message>[A-Za-z]{8,})[\]]";
                Match result = Regex.Match(inputMassage, regex);
                string command = result.Groups["command"].Value;
                string message = result.Groups["message"].Value;
                if (result.Success)
                {
                    char[] messRes = message.ToCharArray();
                    Console.Write($"{command}: ");
                    for (int j = 0; j < messRes.Length; j++)
                    {
                        int num = (int)messRes[j];
                        Console.Write($"{num} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
