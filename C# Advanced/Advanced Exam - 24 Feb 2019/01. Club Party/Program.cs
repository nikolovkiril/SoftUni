using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();
            var queInt = new Queue<int>();
            int capacity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>(input);

            var res = capacity;

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                bool containsInt = current.Any(char.IsDigit);

                if (!containsInt)
                {
                    queue.Enqueue(current);
                }

                else
                {
                    int num = int.Parse(current);
                    if (queue.Count != 0)
                    {
                        res -= num;
                        if (res >= 0)
                        {
                            queInt.Enqueue(num);
                        }
                        else
                        {
                            if (queInt.Count == 0)
                            {
                                return;
                            }
                            PrintResult(queue, queInt);
                            if (queue.Count != 0)
                            {
                                res = CheckIfQueueIsEmpty(queInt, capacity, num);
                            }
                        }
                    }
                }
            }
        }

        private static void PrintResult(Queue<string> queue, Queue<int> queInt)
        {
            var hall = queue.Dequeue();
            Console.Write($"{hall} -> ");

            Console.WriteLine(string.Join(", ", queInt));
            queInt.Clear();
        }

        private static int CheckIfQueueIsEmpty(Queue<int> queInt, int capacity, int num)
        {
            int res = capacity;
            res -= num;

            if (res >= 0)
            {
                queInt.Enqueue(num);
            }

            return res;
        }
    }
}
