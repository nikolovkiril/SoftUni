using System;
using System.Collections.Generic;
using System.Linq;

namespace Try
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                     .Split(' ')
                                     .Select(int.Parse)
                                     .ToList();
            nums.Remove(30);

            nums.Add(100);

            nums.Insert(0, -100);

            Console.WriteLine(string.Join(", ", nums));

            Console.WriteLine($"Count: {nums.Count}");
        }
    }
}
