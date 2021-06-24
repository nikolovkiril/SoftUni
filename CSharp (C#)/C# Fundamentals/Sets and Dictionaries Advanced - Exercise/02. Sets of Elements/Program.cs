using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new HashSet<int>();
            var m = new HashSet<int>();
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = input[0];
            int sec = input[1];
            for (int i = 0; i < first; i++)
            {
                n.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < sec; i++)
            {
                m.Add(int.Parse(Console.ReadLine()));
            }
            Console.Write(string.Join(" ", n.Intersect(m)));
        }
    }
}
