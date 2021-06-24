using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                                              .Split('!')
                                              .ToList();

            string cmd;
            string[] commandSplit;
            while (!(cmd = Console.ReadLine()).Contains("Go Shopping!"))
            {
                commandSplit = cmd.Split(" ");

                if (commandSplit[0] == "Urgent")
                {
                    if (!shoppingList.Contains(commandSplit[1]))
                    {
                        shoppingList.Insert(0, commandSplit[1]);

                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commandSplit[0] == "Unnecessary")
                {
                    if (shoppingList.Contains(commandSplit[1]))
                    {
                        shoppingList.Remove((commandSplit[1]));
                    }
                }
                else if (commandSplit[0] == "Correct")
                {
                    if (shoppingList.Contains(commandSplit[1]))
                    {
                        string old = commandSplit[1];
                        string newOne = commandSplit[2];
                        int indexFirstBook = shoppingList.IndexOf(commandSplit[1]);

                        //int oldIndex = int.Parse(commandSplit[1]);  
                        shoppingList[indexFirstBook] = commandSplit[2];
                    
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commandSplit[0] == "Rearrange")
                {
                    if (shoppingList.Contains(commandSplit[1]))
                    {
                        shoppingList.Remove(commandSplit[1]);
                        shoppingList.Add(commandSplit[1]);
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            Console.WriteLine(string.Join(", " , shoppingList));

        }
    }
}