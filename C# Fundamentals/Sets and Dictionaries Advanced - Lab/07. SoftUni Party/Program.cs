using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestListVip = new HashSet<string>();
            var guestList = new HashSet<string>();
            string command;

            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(command[0]))
                {
                    guestListVip.Add(command);
                }
                else
                {
                    guestList.Add(command);
                }
            }
            while ((command = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(command[0]))
                {
                    guestListVip.Remove(command);
                }
                else
                {
                    guestList.Remove(command);
                }
            }

            Console.WriteLine(guestList.Count + guestListVip.Count);

            foreach (var guest in guestListVip)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
