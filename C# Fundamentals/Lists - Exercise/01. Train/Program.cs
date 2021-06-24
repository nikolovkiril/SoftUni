using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                                     .Split(' ')
                                     .Select(int.Parse)
                                     .ToList();
            int capacity = int.Parse(Console.ReadLine());

            WhileMain(train, capacity);
            Console.WriteLine(string.Join(" ", train));
        }

        private static void WhileMain(List<int> train, int capacity)
        {
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmgArg = command
                     .Split(' ')
                     .ToArray();
                if (cmgArg[0] == "Add")
                {
                    AddWagon(train, cmgArg);
                }
                else
                {
                    int currentCapacity = int.Parse(cmgArg[0]);
                    AddPasangers(train, capacity, currentCapacity);
                }
            }
        }

        private static void AddPasangers(List<int> train, int capacity, int currentCapacity)
        {
            for (int i = 0; i < train.Count; i++)
            {
                int currentWagon = train[i];
                if (currentWagon + currentCapacity <= capacity)
                {
                    train[i] += currentCapacity;
                    break;
                }
            }
        }

        private static void AddWagon(List<int> train, string[] cmgArg)
        {
            int addNumber = int.Parse(cmgArg[1]);
            train.Add(addNumber);
        }
    }
}
