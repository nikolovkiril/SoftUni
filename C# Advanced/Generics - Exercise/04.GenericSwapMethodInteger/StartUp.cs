using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listOf = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                listOf.Add(input);
            }
            Box<int> box = new Box<int>(listOf);
            var swapPosition = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(listOf, swapPosition[0], swapPosition[1]);
            Console.WriteLine(box);
        }
    }
}
