
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(orders);


            Console.WriteLine(queue.Max());

            while (queue.Count != 0)
            {
                var currOrder = queue.Peek();
                if (quantityOfFood >= currOrder)
                {
                    quantityOfFood -= currOrder;
                    queue.Dequeue();
                }
                else if (queue.Count != 0)
                {
                    Console.Write($"Orders left: ");
                    Console.Write(string.Join(" ", queue));
                    return;
                }
            }
            Console.WriteLine("Orders complete");

        }
    }
}

