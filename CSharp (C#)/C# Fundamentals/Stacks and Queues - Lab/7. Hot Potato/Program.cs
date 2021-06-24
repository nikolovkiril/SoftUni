using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var kids = Console.ReadLine().Split();
            var times = int.Parse(Console.ReadLine());
            var kidsList = new Queue<string>(kids);
            int counter = 1;
            while (kidsList.Count > 1)
            {
                var curent = kidsList.Dequeue();
                if (counter % times != 0)
                {
                    kidsList.Enqueue(curent);
                }
                else
                {
                    Console.WriteLine($"Removed {curent}");
                }
                counter++;
            }
            Console.WriteLine($"Last is {kidsList.Dequeue()}");
        }
    }
}
