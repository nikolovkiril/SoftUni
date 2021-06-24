using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine()
                                              .Split('@')
                                              .Select(int.Parse)
                                              .ToList();

            string cmd1;
            string[] commandSplit;
            int currentPosition = 0;

            while (!(cmd1 = Console.ReadLine()).Contains("Love!"))
            {
                commandSplit = cmd1.Split(" ");
                currentPosition = currentPosition + int.Parse(commandSplit[1]) % houses.Count;

                if (commandSplit[0] == "Jump")
                {
                    if (houses[currentPosition] != 0)   
                    {
                        if (houses[currentPosition] >= 0 && houses[currentPosition] < houses.Count)
                        {
                            houses[currentPosition] -= 2;
                        }
                        else
                        {

                            houses[currentPosition] -= 2;

                        }
                    }
                    if (houses[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }
            }
            Console.WriteLine($"Cupid's last position was {currentPosition}.");
            if (houses.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else if (houses.Sum() != 0)
            {
                int num =  houses.Count - 1;
                Console.WriteLine($"Cupid has failed {num} places.");
            }
        }
    }
}

