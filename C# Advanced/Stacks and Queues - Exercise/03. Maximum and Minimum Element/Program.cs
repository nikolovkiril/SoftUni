using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var result = new List<string>();

            for (int i = 0; i < queries; i++)
            {
                var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var queryCommand = query[0];
                if (queryCommand == 1)
                {
                    var pushEle = query[1];
                    stack.Push(pushEle);
                }
                else if (queryCommand == 2)
                {
                    stack.Pop();
                }
                else if (queryCommand == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (queryCommand == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            
            Console.Write(string.Join(", ", stack));

        }
    }
}
