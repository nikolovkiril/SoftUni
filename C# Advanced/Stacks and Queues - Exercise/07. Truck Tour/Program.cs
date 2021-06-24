﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var pumps = new Queue<Tuple<int, int, int>>();

            for (int i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int petrol = numbers[0];
                int distance = numbers[1];
                int index = i;

                pumps.Enqueue(new Tuple<int, int, int>(petrol,distance,index));
            }


            while (true)
            {
                long totalGas = 0;
                Tuple<int, int, int> startPump = pumps.Dequeue();
                int startIndex = startPump.Item3;
                totalGas += startPump.Item1;
                totalGas -= startPump.Item2;
                pumps.Enqueue(startPump);

                while (totalGas >= 0)
                {
                    startPump = pumps.Dequeue();
                    totalGas += startPump.Item1;
                    totalGas -= startPump.Item2;
                    int currentIndex = startPump.Item3;

                    if (currentIndex == startIndex)
                    {
                        if (totalGas >= 0)
                        {
                            Console.WriteLine(startIndex);
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }

                    pumps.Enqueue(startPump);
                }
            }
        }
    }
}