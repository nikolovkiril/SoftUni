using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var queue = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            string doll = "Doll";
            string train = "Wooden train";
            string bear = "Teddy bear";
            string bicycle = "Bicycle";

            var finalResult = new Dictionary<string, int>
            {
                {"Bicycle",0 },
                {"Doll",0 },
                {"Teddy bear",0 },
                {"Wooden train",0 },
            };

            while (stack.Count > 0 && queue.Count > 0)
            {
                var firstStack = stack.Peek();
                var firstQueue = queue.Peek();
                if (firstStack == 0 || firstQueue == 0)
                {
                    RemoveFromMagic(queue, firstQueue);
                    RemoveFromMaterials(stack, firstStack);
                    continue;
                }
                var result = GetMultiplicationOfMagic(firstStack, firstQueue);
                if (result < 0)
                {
                    var sum = stack.Pop() + queue.Dequeue();
                    stack.Push(sum);
                    continue;
                }
                else
                {
                    switch (result)
                    {
                        case 150:
                            finalResult[doll]++;
                            queue.Dequeue();
                            stack.Pop();
                            break;
                        case 250:
                            finalResult[train]++;
                            queue.Dequeue();
                            stack.Pop();
                            break;
                        case 300:
                            finalResult[bear]++;
                            queue.Dequeue();
                            stack.Pop();
                            break;
                        case 400:
                            finalResult[bicycle]++;
                            queue.Dequeue();
                            stack.Pop();
                            break;
                        default:
                            queue.Dequeue();
                            var materialValue = stack.Pop() + 15;
                            stack.Push(materialValue);
                            break;
                    }

                }
            }

            if (finalResult.Count > 0)
            {
                if (finalResult[doll] > 0 && finalResult[train] > 0 ||
                    finalResult[bear] > 0 && finalResult[bicycle] > 0)
                {
                    Console.WriteLine("The presents are crafted! Merry Christmas!");
                }
                else
                {
                    Console.WriteLine("No presents this Christmas!");
                }
                if (stack.Count > 0)
                {
                    Console.WriteLine($"Materials left: {string.Join(", ", stack)}");
                }
                if (queue.Count > 0)
                {
                    Console.WriteLine($"Materials left: {string.Join(", ", queue)}");
                }
                finalResult = finalResult.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var item in finalResult)
                {
                    if (item.Value > 0)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}".ToString());
                    }
                }
            }
        }

        private static void RemoveFromMagic(Queue<int> queue, int firstQueue)
        {
            if (firstQueue == 0)
            {
                queue.Dequeue();
            }
        }

        private static void RemoveFromMaterials(Stack<int> stack, int firstStack)
        {
            firstStack = stack.Peek();
            if (firstStack == 0)
            {
                stack.Pop();
            }
        }

        public static int GetMultiplicationOfMagic(int firstStack, int firstQueue)
        {
            int result = firstStack * firstQueue;
            return result;
        }
    }
}
