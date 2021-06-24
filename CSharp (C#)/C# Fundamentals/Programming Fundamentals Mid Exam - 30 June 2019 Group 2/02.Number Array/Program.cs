using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                        .Split(' ')
                                        .Select(int.Parse)
                                        .ToList();

            string cmd;
            string[] commandSplit;
            int sum = 0;

            while (!(cmd = Console.ReadLine()).Contains("End"))
            {
                commandSplit = cmd.Split(" ");
                if (commandSplit[0] == "Switch")
                {
                    int num = int.Parse(commandSplit[1]);
                    if (num >= 0 && num < numbers.Count)
                    {
                        int switchNum = numbers[num] * -1;
                        //switchNum = numbers[num];
                        numbers[num] = switchNum;
                    }
                }
                else if (commandSplit[0] == "Change")
                {
                    int changeIndex = int.Parse(commandSplit[1]);

                    if (changeIndex >= 0 && changeIndex < numbers.Count)
                    {
                        int changeNumber = int.Parse(commandSplit[2]);
                        numbers[changeIndex] = changeNumber;
                    }
                }
                else if (commandSplit[0] == "Sum")
                {
                    if (commandSplit[1] == "Negative")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < 0)
                            {
                                sum += numbers[i];
                                //int totalNegative = numbers.Sum();
                            }
                        }
                        Console.WriteLine(sum);

                    }
                    else if (commandSplit[1] == "Positive")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] >= 0)
                            {
                                sum += numbers[i];
                            }
                        }
                        Console.WriteLine(sum);

                    }
                    else if (commandSplit[1] == "All")
                    {
                        int total = numbers.Sum();
                        Console.WriteLine(total);
                    }
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}
