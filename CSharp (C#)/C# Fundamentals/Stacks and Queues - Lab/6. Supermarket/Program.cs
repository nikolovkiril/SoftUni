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
            var customers = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (customers.Count != 0)
                    {
                        Console.WriteLine(customers.Dequeue() + " ");
                    }
                }
                else
                {
                    customers.Enqueue(input);
                }
            }
            Console.WriteLine($"{customers.Count()} people remaining.");

        }
    }
}
