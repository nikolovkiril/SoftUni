using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLenght = int.Parse(Console.ReadLine());
            var uniqueOnes = new HashSet<string>();
            for (int i = 0; i < inputLenght; i++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (var item in elements)
                {
                    uniqueOnes.Add(item);
                }
            }
            Console.Write(string.Join(" " , uniqueOnes.OrderBy(x => x)));
        }
    }
}
