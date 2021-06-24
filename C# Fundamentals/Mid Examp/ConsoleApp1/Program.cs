﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main()
        {
            List<int> houses = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToList();

            string currentJumpCommand = Console.ReadLine();

            int lastPosition = 0;
            while (currentJumpCommand != "Merry Xmas!")
            {
                int currLength = int.Parse((currentJumpCommand.Split())[1]);

                lastPosition += currLength;

                while (lastPosition >= houses.Count)
                {
                    lastPosition -= houses.Count;
                }

                if (houses[lastPosition] == 0)
                {
                    Console.WriteLine($"House {lastPosition} will have a Merry Christmas.");
                }
                else if (houses[lastPosition] > 2)
                {
                    houses[lastPosition] -= 2;
                }
                else
                {
                    houses[lastPosition] = 0;
                }
                currentJumpCommand = Console.ReadLine();
            }

            Console.WriteLine("Santa's last position was {0}.", lastPosition);

            bool successfulChristmas = true;
            int counter = 0;
            foreach (int presents in houses)
            {
                if (presents > 0)
                {
                    counter += 1;
                    successfulChristmas = false;
                }
            }

            if (successfulChristmas)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {counter} houses.");
            }
            //if (houses.Max() < 1)
            //{
            //    Console.WriteLine("Mission was successful.");
            //}
            //else
            //{
            //    int[] count = houses.Where(x => x != 0).ToArray();
            //    Console.WriteLine($"Santa has failed {count.Count()} houses.");
            //}
        }
    }
}