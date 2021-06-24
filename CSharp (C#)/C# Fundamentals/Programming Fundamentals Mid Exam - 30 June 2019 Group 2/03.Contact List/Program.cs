using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine()
                                                 .Split(' ')
                                                 .ToList();

            string cmd = Console.ReadLine();
            string[] commandSplit;
            while (true)
            {
                commandSplit = cmd.Split(" ");
                if (commandSplit[0] == "Add")
                {
                    if (contacts.Contains(commandSplit[1]))
                    {
                        int toIndex = int.Parse(commandSplit[2]);

                        if (toIndex >= 0 && toIndex < contacts.Count)
                        {
                            contacts.Insert(toIndex, commandSplit[1]);
                        }
                    }
                    else
                    {
                        contacts.Add(commandSplit[1]);
                    }
                }
                else if (commandSplit[0] == "Remove")
                {
                    int toIndex = int.Parse(commandSplit[1]);
                    contacts.RemoveAt(toIndex);
                }
                else if (commandSplit[0] == "Export")
                {
                    int startIndex = int.Parse(commandSplit[1]);
                    int count = int.Parse(commandSplit[2]);
                    if (count > contacts.Count)
                    {
                        for (int i = startIndex; i < contacts.Count; i++)
                        {
                            Console.Write(string.Join(" ", contacts[i]+ " "));
                        }
                        Console.WriteLine();
                    }
                    else if (startIndex >= 0 && count < contacts.Count)
                    {
                        for (int i = startIndex; i < count; i++)
                        {
                            Console.Write(string.Join(" ", contacts[i] + " "));
                        }
                        Console.WriteLine();
                    }
                }
                else if (commandSplit[0] == "Print")
                {
                    if (commandSplit[1] == "Normal")
                    {
                        Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                    }
                    else if (commandSplit[1] == "Reversed")
                    {
                        contacts.Reverse();
                        Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                    }
                    break;
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
