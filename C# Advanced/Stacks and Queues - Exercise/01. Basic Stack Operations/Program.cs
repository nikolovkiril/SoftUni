using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            var elementsToPush = elements[0];
            var elementsToPop = elements[1]; 
            var elementNeeded = elements[2];

            if (numbers.Length != elementsToPush)
            {
                throw new Exception($"Need {elementsToPush} numbers");
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(elementNeeded))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
