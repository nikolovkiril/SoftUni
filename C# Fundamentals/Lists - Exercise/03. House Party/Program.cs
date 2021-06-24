using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guest = new List<string>();
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                ProceedCommand(guest);
            }
            PrintGuest(guest);
        }

        private static void PrintGuest(List<string> guest)
        {
            foreach (var person in guest)
            {
                Console.WriteLine(person);
            }
        }

        private static void ProceedCommand(List<string> guest)
        {
            string command = Console.ReadLine();

            string[] commandArg = command.Split(" ").ToArray();
            string name = commandArg[0];
            if (commandArg.Length == 3)
            {
                AddGuest(guest, name);
            }
            else if (commandArg.Length == 4)
            {
                RemoveGuest(guest, name);
            }
        }

        private static void RemoveGuest(List<string> guest, string name)
        {
            if (guest.Contains(name))
            {
                guest.Remove(name);
            }
            else
            {
                Console.WriteLine($"{name} is not in the list!");
            }
        }

        private static void AddGuest(List<string> guest, string name)
        {
            if (guest.Contains(name))
            {
                Console.WriteLine($"{name} is already in the list!");
            }
            else
            {
                guest.Add(name);
            }
        }
    }
}
