using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var queue = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {                               
                if (input == "Paid")
                {
                    while (queue.Count != 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else if(input != "Paid")
                {
                    queue.Enqueue(input);
                }
            }
            var num = queue.Count();
            Console.WriteLine($"{num} people remaining.");
        }
    }
}
