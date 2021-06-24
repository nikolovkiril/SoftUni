using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> train = Console.ReadLine()
                                     .Split(' ')
                                     .Select(int.Parse)
                                     .ToList();
            int tmp = train[0];
            train[0] = train[2];
            train[2] = tmp;

            Console.WriteLine(string.Join(" " , train));

        }
    }
}
