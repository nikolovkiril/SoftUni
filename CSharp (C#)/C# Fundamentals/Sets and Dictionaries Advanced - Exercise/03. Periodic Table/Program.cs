using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var chemicalElements = new HashSet<string>();
            int inputLength = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLength; i++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (var element in elements)
                {
                    chemicalElements.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", chemicalElements.OrderBy(x => x)));
            
        }
    }
}
