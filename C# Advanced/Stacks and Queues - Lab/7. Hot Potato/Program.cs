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
            var passes = int.Parse(Console.ReadLine());
            var kidsList = new Queue<string>(kids);
            int counter = 1;
            while (kidsList.Count > 1)
            {
                var curent = kidsList.Dequeue();
                GetName(passes, kidsList, counter, curent);
                counter++;
            }
            Console.WriteLine($"Last is {kidsList.Dequeue()}");
        }

        private static void GetName(int passes, Queue<string> kidsList, int counter, string curent)
        {
            if (counter % passes != 0)
            {
                kidsList.Enqueue(curent);
            }
            else
            {
                Console.WriteLine($"Removed {curent}");
            }
        }
    }
}
