using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var delivery = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var toStoreAtRackS = new Stack<int>(delivery);
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 1;

            while (toStoreAtRackS.Count != 0)
            {
                sum += toStoreAtRackS.Peek();

                if (sum <= capacity)
                {
                    toStoreAtRackS.Pop();
                }
                else
                {
                    count++;
                    sum = 0;
                }
            }
            Console.WriteLine(count);
        }
    }
}
