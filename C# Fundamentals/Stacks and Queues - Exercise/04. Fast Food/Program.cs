using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountFood = int.Parse(Console.ReadLine());

            var amountOrders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //var ordersCount = new Queue<int>();
            var ordersResult = new Queue<int>(amountOrders);

            Console.WriteLine(ordersResult.Max());

            while (ordersResult.Count > 0)
            {
                var portion = ordersResult.Peek();
                if (amountFood >= portion)
                {
                    ordersResult.Dequeue();
                    amountFood -= portion;
                }
                else if (ordersResult.Count != 0)
                {
                    Console.Write($"Orders left: ");
                    Console.Write(string.Join(" ", ordersResult));
                    return;
                }

            }
            Console.WriteLine("Orders complete");
        }
    }
}
