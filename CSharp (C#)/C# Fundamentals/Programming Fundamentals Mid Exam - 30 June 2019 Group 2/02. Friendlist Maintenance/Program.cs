using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> userNames = Console.ReadLine()
                                     .Split(", ")
                                     .ToList();

            List<string> blackList = new List<string>();
            List<string> lost = new List<string>();

            string command;
            string[] commandSplit;
            while (!(command = Console.ReadLine()).Contains("Report"))
            {
                commandSplit = command.Split(" ");
                if (commandSplit[0] == "Blacklist")
                {
                    if (userNames.Contains(commandSplit[1]))
                    {
                        blackList.Add(commandSplit[1]);
                        int indexFirstUserNumber = userNames.IndexOf(commandSplit[1]);
                        userNames[indexFirstUserNumber] = "Blacklisted";
                        Console.WriteLine($"{commandSplit[1]} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{commandSplit[1]} was not found.");
                    }
                }
                else if (commandSplit[0] == "Error")
                {
                    int num = int.Parse(commandSplit[1]);
                    int indexUserNumber = num;

                    if (userNames[indexUserNumber] != "Blacklisted" && userNames[indexUserNumber] != "Lost")
                    {
                        lost.Add(userNames[indexUserNumber]);
                        Console.WriteLine($"{userNames[indexUserNumber]} was lost due to an error.");
                        userNames[indexUserNumber] = "Lost";
                    }
                }
                else if (commandSplit[0] == "Change")
                {
                    int num = int.Parse(commandSplit[1]);
                    string name = userNames.ElementAt(num);
                    int indexUserNumber = num;
                    if (num >= 0 && num < userNames.Count)
                    {
                        userNames[indexUserNumber] = commandSplit[2];
                        Console.WriteLine($"{name} changed his username to {userNames[indexUserNumber]}. ");
                    }
                }
            }
            Console.WriteLine($"Blacklisted names: {blackList.Count} ");
            Console.WriteLine($"Lost names: {lost.Count} ");
            Console.WriteLine(string.Join(" ", userNames));
        }
    }
}
