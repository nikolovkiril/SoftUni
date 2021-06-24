using System;
using System.Collections.Generic;
using System.Linq;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine()
                                                  .Split('@')
                                                  .Select(int.Parse)
                                                  .ToList();
            int position = 0;
            int lastPosition = 0;

            string cmd;
            string[] commandSplit;
            while (!(cmd = Console.ReadLine()).Contains("Love!"))
            {
                commandSplit = cmd.Split(" ");
                int currLength = int.Parse(commandSplit[1]);
                lastPosition += currLength;
                while (lastPosition >= houses.Count)
                {
                    lastPosition -= houses.Count;
                }
                if (houses[lastPosition] >= 0 && houses[lastPosition] < houses.Count)
                {
                    if (houses[lastPosition] > 2)
                    {
                        houses[lastPosition] -= 2;
                    }
                    else if (houses[lastPosition] == 0)
                    {
                        Console.WriteLine($"Place {lastPosition} already had Valentine's day.");
                    }
                    else
                    {
                        houses[lastPosition] = 0;
                        Console.WriteLine($"Place {lastPosition} has Valentine's day.");
                    }
                }
                else if (houses[lastPosition] == houses.IndexOf(houses.Count - 1))
                {
                    lastPosition = 0;
                    if (houses[lastPosition] > 2)
                    {
                        houses[lastPosition] -= 2;
                    }
                    else if (houses[lastPosition] == 0)
                    {
                        Console.WriteLine($"Place {lastPosition} already had Valentine's day.");
                    }
                    else
                    {
                        houses[lastPosition] = 0;
                        Console.WriteLine($"Place {lastPosition} has Valentine's day.");

                    }
                }
            }
            Console.WriteLine($"Cupid's last position was {lastPosition}.");
            bool successful = true;
            int counter = 0;
            foreach (int heart in houses)
            {
                if (heart > 0)
                {
                    counter += 1;

                }
            }

            if (houses.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
            //  if (houses.Max() < 1)
            //  {
            //      
            //      int[] count = houses.Where(x => x != 0).ToArray();
            //      Console.WriteLine($"Cupid has failed {count.Count()} places.");
            //  }
            //  else
            //  {
            //      Console.WriteLine("Mission was successful.");
            //
            //  }
        }
    }
}

