using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLenght = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputLenght[0];
            int m = inputLenght[1];
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int firstSet = int.Parse(Console.ReadLine());
                set1.Add(firstSet);
            }
            for (int i = 0; i < m; i++)
            {
                int secSet = int.Parse(Console.ReadLine());
                set2.Add(secSet);
            }
            Console.WriteLine(string.Join(" " , set1.Intersect(set2)));
        }
    }
}
