using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd;
            string[] commandSplit;

            while (!(cmd = Console.ReadLine()).Contains("Finish"))
            {
                commandSplit = cmd.Split(" ");
                if (commandSplit[0] == "Replace")
                {
                    char old = char.Parse(commandSplit[1]);
                    char newOne = char.Parse(commandSplit[2]);

                    input = input.Replace(old, newOne);
                    Console.WriteLine(input);
                }
                else if (commandSplit[0] == "Cut")
                {
                    int startIndex = int.Parse(commandSplit[1]);
                    int endIndex = int.Parse(commandSplit[2]);
                    if (startIndex >= 0 && endIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (commandSplit[0] == "Make")
                {
                    if (commandSplit[1] == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    else if (commandSplit[1] == "Lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }
                else if (commandSplit[0] == "Check")
                {
                    if (input.Contains(commandSplit[1]))
                    {
                        Console.WriteLine($"Message contains {commandSplit[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {commandSplit[1]}");
                    }
                }
                else if (commandSplit[0] == "Sum")
                {
                    int startIndex = int.Parse(commandSplit[1]);
                    int endIndex = int.Parse(commandSplit[2]);
                    int totalSum = 0;

                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        string Subbed = input.Substring(startIndex, endIndex);
                        for (int i = startIndex - 1; i < endIndex; i++)
                        {
                            char temp = Subbed[i];
                            totalSum += temp;
                        }
                        Console.WriteLine(totalSum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}
