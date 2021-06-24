using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //-2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3
            //-2.5 - 3 times
            var input = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int count = 0;

            var numbersCout = new Dictionary<double, int>();

            foreach (var number in input)
            {
                if (!numbersCout.ContainsKey(number))
                {
                    numbersCout.Add(number,0);
                }
                numbersCout[number]++;
            }

            foreach (var number in numbersCout)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }

        }
    }
}
