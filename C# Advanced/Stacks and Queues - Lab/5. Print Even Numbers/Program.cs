using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currNum = input[i];
                if (currNum % 2 == 0)
                {
                    queue.Enqueue(currNum);
                    if (queue.Count > 1)
                    {
                        Console.Write(queue.Dequeue() + ", ");
                    }
                }
                
            }
            Console.WriteLine(queue.Peek());
        }
    }
}
